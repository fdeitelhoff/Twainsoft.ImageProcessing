#region Namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Twainsoft.ImageProcessing.EBC.Contracts;
using System.Windows.Forms;
using Twainsoft.ImageProcessing.EBC.Contracts.Vocabulary.Messages;
using Twainsoft.ImageProcessing.EBC.Components.Vocabulary.Messages;
using Twainsoft.ImageProcessing.EBC.Contracts.Base;
using System.Reflection;
using System.Drawing;
using Twainsoft.ImageProcessing.Shapes.Components.Vocabulary.Messages;
using Twainsoft.ImageProcessing.Shapes.Contracts.Vocabulary.Messages;
using Twainsoft.ImageProcessing.Shapes.Contracts;
using Twainsoft.ImageProcessing.Shapes.Components;
using Twainsoft.ImageProcessing.Shapes.Components.Connection;
using Twainsoft.ImageProcessing.Shapes.Contracts.Base;
using Twainsoft.ImageProcessing.Shapes.Components.Vocabulary.Data;
using Twainsoft.ImageProcessing.Common.Components.Vocabulary.Messages;
using Twainsoft.ImageProcessing.Common.Contracts.Vocabulary.Messages;
using Twainsoft.ImageProcessing.EBC.Components.Vocabulary.Exceptions;
using System.Drawing.Drawing2D;

#endregion

namespace Twainsoft.ImageProcessing.EBC.Components.Shapes
{
    public class ShapeController : IShapeController
    {
        private List<Guid> ShapeLevels { get; set; }
        private Dictionary<Guid, IShapeBase> Shapes { get; set; }

        private List<IShapeBase> SelectedShapes { get; set; }

        private List<IEBCBase> EBCs { get; set; }
        private Dictionary<Guid, IEBCBase> ShapeToEBC { get; set; }
        private Dictionary<IEBCBase, Guid> EBCtoShape { get; set; }

        private Action<MouseEventArgs> LastConnectionTmpMouseMove { get; set; }
        private IShapeBase LastClickedShape { get; set; }

        private PinTypes LastPinType { get; set; }
        private ConnectionShape LastConnection { get; set; }

        private Dictionary<IShapeBase, List<ConnectionShape>> ConnectionStartShapes { get; set; }
        private Dictionary<IShapeBase, List<ConnectionShape>> ConnectionEndShapes { get; set; }

        private Dictionary<IShapeBase, Dictionary<string, Action<MouseEventArgs>>> MouseEvents { get; set; }

        private bool IsDragging { get; set; }
        private bool IsMultiSelect { get; set; }

        private bool EBCConnectionsAllowed { get; set; }

        private event Action<IChangeShapeStatusMessage> Inner_ChangeShapeStatus;

        private Dictionary<Type, int> ShapeTypeCount { get; set; }

        public ShapeController()
        {
            this.ShapeLevels = new List<Guid>();
            this.Shapes = new Dictionary<Guid, IShapeBase>();

            this.SelectedShapes = new List<IShapeBase>();

            this.EBCs = new List<IEBCBase>();
            this.ShapeToEBC = new Dictionary<Guid, IEBCBase>();
            this.EBCtoShape = new Dictionary<IEBCBase, Guid>();

            this.ConnectionStartShapes = new Dictionary<IShapeBase, List<ConnectionShape>>();
            this.ConnectionEndShapes = new Dictionary<IShapeBase, List<ConnectionShape>>();

            this.MouseEvents = new Dictionary<IShapeBase, Dictionary<string, Action<MouseEventArgs>>>();

            this.EBCConnectionsAllowed = true;

            this.ShapeTypeCount = new Dictionary<Type, int>();
        }

        private void AddShape(IShapeBase shapeBase)
        {
            this.AddShape(shapeBase, null, Point.Empty);
        }
        
        private void AddShape(IShapeBase shape, IEBCBase ebc, Point shapeLocation)
        {
            try
            {
                if (!(shape is ConnectionShape))
                {
                    this.Out_STEAutoConnect(new STEConnectMessage(shape, ebc));

                    shape.Out_PinClicked += new Action<IEBCPinClickedMessage>(shapeBase_Out_PinClicked);

                    if (!shapeLocation.IsEmpty)
                        shape.SetInitialPosition(shapeLocation);

                    this.EBCs.Add(ebc);
                    this.ShapeToEBC.Add(shape.ID, ebc);
                    this.EBCtoShape.Add(ebc, shape.ID);

                    shape.Out_StartProcess += () => this.Out_ExecuteFirstEBC(new ExecuteFirstEBCMessage(this.ShapeToEBC[shape.ID])); // this.StartProcessEvents[shape];

                    this.Inner_ChangeShapeStatus += (IChangeShapeStatusMessage changeShapeStatus) => shape.In_ChangeShapeStatus(changeShapeStatus); // this.ChangeShapeStatusEvents[shape];
                }

                Dictionary<string, Action<MouseEventArgs>> mouseEvents = new Dictionary<string, Action<MouseEventArgs>>();

                Action<MouseEventArgs> mouseClickEvent = (MouseEventArgs mouseEventArgs) => shape.In_MouseClick(mouseEventArgs);
                Action<MouseEventArgs> mouseDoubleClickEvent = (MouseEventArgs mouseEventArgs) => shape.In_MouseDoubleClick(mouseEventArgs);
                Action<MouseEventArgs> mouseMoveEvent = (MouseEventArgs mouseEventArgs) => shape.In_MouseMove(mouseEventArgs);
                Action<MouseEventArgs> mouseUpEvent = (MouseEventArgs mouseEventArgs) => shape.In_MouseUp(mouseEventArgs);
                Action<MouseEventArgs> mouseDownEvent = (MouseEventArgs mouseEventArgs) => shape.In_MouseDown(mouseEventArgs);

                mouseEvents.Add("MouseMove", mouseMoveEvent);
                mouseEvents.Add("MouseUp", mouseUpEvent);
                mouseEvents.Add("MouseDown", mouseDownEvent);
                mouseEvents.Add("MouseClick", mouseClickEvent);
                mouseEvents.Add("MouseDoubleClick", mouseDoubleClickEvent);

                this.Out_MouseClick += mouseClickEvent;
                this.Out_MouseMove += mouseMoveEvent;
                this.Out_MouseUp += mouseUpEvent;
                this.Out_MouseDown += mouseDownEvent;
                this.Out_MouseDoubleClick += mouseDoubleClickEvent;

                shape.Out_PaintRequest += () => this.Out_PaintRequest();

                this.MouseEvents.Add(shape, mouseEvents);

                this.ShapeLevels.Insert(0, shape.ID);
                this.Shapes.Add(shape.ID, shape);

                if (!(shape is ConnectionShape))
                {
                    this.Out_EBCAdded(ebc);

                    // use the EBC type for counting.
                    Type ebcType = ebc.GetType();

                    if (this.ShapeTypeCount.ContainsKey(ebcType))
                    {
                        this.ShapeTypeCount[ebcType]++;

                        // Only add the type number, if there is a minimum of two EBCs with this type.
                        shape.Name += " " + this.ShapeTypeCount[ebcType];
                        ebc.Name = shape.Name;
                    }
                    else
                    {
                        this.ShapeTypeCount.Add(ebcType, 1);
                    }
                }
            }
            catch (TargetException targetException)
            {
                this.OnOut_ReportError(new STEAutoConnectionException("Die Automatische Verbindung von Shape und EBC ist fehlgeschlagen!",
                    targetException));
            }
        }
        
        void shapeBase_Out_PinClicked(IEBCPinClickedMessage ebcPinClickedMessage)
        {
            if (!this.EBCConnectionsAllowed || this.IsMultiSelect || this.IsDragging)
            {
                return;
            }

            this.HandlePinClicked(ebcPinClickedMessage.PinType, ebcPinClickedMessage.Shape);
        }

        private void HandlePinClicked(PinTypes pinType, IShapeBase shape)
        {
            if (this.LastClickedShape == null)
            {
                this.OnInner_ChangeShapeStatus(false);

                this.LastClickedShape = shape;

                this.LastConnection = new ConnectionShape();
                this.LastPinType = pinType;

                if (pinType == PinTypes.Input)
                    this.LastConnection.SetInputShape(this.LastClickedShape);
                else if (pinType == PinTypes.Output)
                    this.LastConnection.SetOutputShape(this.LastClickedShape);

                this.AddShape(this.LastConnection);
            }
            else if (this.LastClickedShape != null && this.LastPinType != pinType && this.LastClickedShape != shape)
            {
                if (pinType == PinTypes.Input)
                    this.LastConnection.SetInputShape(shape);
                else if (pinType == PinTypes.Output)
                    this.LastConnection.SetOutputShape(shape);

                if (this.ConnectEBCs(this.LastConnection))
                {
                    this.SetConnectionShapes(this.LastConnection);
                }

                this.CancelConnection(false);

                this.Out_PaintRequest();
            }
        }

        private void SetConnectionShapes(ConnectionShape connectionShape)
        {
            // All start-connections: They are the start of an ebc message.
            if (!this.ConnectionStartShapes.ContainsKey(connectionShape.OutputShape))
            {
                List<ConnectionShape> connections = new List<ConnectionShape>();
                connections.Add(connectionShape);
                this.ConnectionStartShapes.Add(connectionShape.OutputShape, connections);
            }
            else
            {
                this.ConnectionStartShapes[connectionShape.OutputShape].Add(connectionShape);
            }

            // All end-connections: They are the target of an ebc message.
            if (!this.ConnectionEndShapes.ContainsKey(connectionShape.InputShape))
            {
                List<ConnectionShape> connections = new List<ConnectionShape>();
                connections.Add(connectionShape);
                this.ConnectionEndShapes.Add(connectionShape.InputShape, connections);
            }
            else
            {
                this.ConnectionEndShapes[connectionShape.InputShape].Add(connectionShape);
            }
        }

        private bool ConnectEBCs(ConnectionShape connection)
        {
            try
            {
                IShapeBase outputShape = connection.OutputShape;
                IShapeBase inputShape = connection.InputShape;

                IEBCBase outputEBC = this.ShapeToEBC[outputShape.ID];
                IEBCBase inputEBC = this.ShapeToEBC[inputShape.ID];

                this.Out_ConnectEBCs(new ConnectEBCMessage(outputEBC, inputEBC));

                return true;
            }
            catch (ShapeConnectionException shapeConnectionException)
            {
                this.CancelConnection();

                this.OnOut_ReportError(shapeConnectionException);

                return false;
            }
            catch (CircularConnectionException circularConnectionException)
            {
                this.CancelConnection();

                this.OnOut_ReportError(circularConnectionException);

                return false;
            }
        }

        public void In_MouseMove(MouseEventArgs mouseEventArgs)
        {
            if (!this.IsDragging)
            {
                //Console.WriteLine("MouseMove");
                bool itemHover = false;

                bool itemHoverEnterState = false;
                bool itemHoverLeaveState = false;

                foreach (var shapeGuid in this.ShapeLevels)
                {
                    IShapeBase shape = this.Shapes[shapeGuid];

                    if (!itemHover && !(shape is ConnectionShape))
                    {
                        if (shape.IsHovered && !itemHoverEnterState)
                        {
                            shape.IsHovered = shape.CheckHoverStatus(mouseEventArgs.Location);
                            if (!shape.IsHovered)
                                itemHoverLeaveState = true;
                            itemHover = shape.IsHovered;
                        }
                        else if (!itemHoverEnterState)
                        {
                            shape.IsHovered = shape.CheckHoverStatus(mouseEventArgs.Location);
                            itemHoverEnterState = shape.IsHovered;
                            itemHover = shape.IsHovered;
                        }
                    }
                    else
                    {
                        shape.IsHovered = false;
                    }
                }

                if (itemHoverEnterState || itemHoverLeaveState)
                {
                    this.Out_PaintRequest();
                }
            }

            if (!this.IsMultiSelect && this.Out_MouseMove != null)
                this.Out_MouseMove(mouseEventArgs);
        }

        public void In_PaintRequest(IPaintRequestMessage paintRequestMessage)
        {
            paintRequestMessage.Graphics.SmoothingMode = SmoothingMode.HighQuality;

            foreach (var shape in this.Shapes.Values)
            {
                shape.Paint(paintRequestMessage.Graphics);
            }
        }

        public void In_MouseClick(MouseEventArgs mouseEventArgs)
        {
            if (this.Out_MouseClick != null)
                this.Out_MouseClick(mouseEventArgs);
        }

        public event Action Out_PaintRequest;


        public void In_MouseUp(MouseEventArgs mouseEventArgs)
        {
            this.IsDragging = false;

            if (this.Out_MouseUp != null)
                this.Out_MouseUp(mouseEventArgs);

            this.Out_PaintRequest();
        }

        public void In_MouseDown(MouseEventArgs mouseEventArgs)
        {
            // Only deselect them if we aren't in multi selection mode.
            if (!this.IsMultiSelect)
            {
                this.DeselectAllShapes();
            }

            this.IsDragging = true;

            bool isSelected = false;
            bool isMouseOverShape = false;

            foreach (var shapeGuid in this.ShapeLevels)
            {
                if (!(this.Shapes[shapeGuid] is ConnectionShape))
                {
                    isSelected = this.SelectedShapes.Contains(this.Shapes[shapeGuid]);
                    isMouseOverShape = this.Shapes[shapeGuid].CheckMousePosition(mouseEventArgs);

                    if (!isSelected)
                    {
                        if (isMouseOverShape)
                        {
                            this.SelectedShapes.Add(this.Shapes[shapeGuid]);
                            this.Shapes[shapeGuid].IsSelected = true;
                            this.Shapes[shapeGuid].IsDraged = this.Shapes[shapeGuid].IsSelected && mouseEventArgs.Button == MouseButtons.Left;

                            break;
                        }
                    }
                    else if (isSelected && isMouseOverShape)
                    {
                        this.SelectedShapes.Remove(this.Shapes[shapeGuid]);
                        this.Shapes[shapeGuid].IsSelected = false;
                        this.Shapes[shapeGuid].IsDraged = false;
                        this.Shapes[shapeGuid].MultiSelectNumber = -1;

                        break;
                    }
                }
            }

            this.SetMultiSelectNumbers();

            if (this.Out_MouseDown != null)
                this.Out_MouseDown(mouseEventArgs);
        }

        private void SetMultiSelectNumbers()
        {
            if (this.IsMultiSelect)
            {
                int count = 1;
                foreach (var shape in this.SelectedShapes)
                {
                    shape.MultiSelectNumber = count;

                    count++;
                }
            }
        }

        public event Action<MouseEventArgs> Out_MouseMove;

        public event Action<MouseEventArgs> Out_MouseUp;

        public event Action<MouseEventArgs> Out_MouseDown;

        public void In_AddShape(IAddShapeMessage addShapeMessage)
        {
            this.AddShape(addShapeMessage.Shape, addShapeMessage.EBC, addShapeMessage.ShapeLocation);

            this.Out_PaintRequest();
        }

        public event Action<MouseEventArgs> Out_MouseClick;

        public event Action<IConnectEBCMessage> Out_ConnectEBCs;

        public event Action<IExecuteFirstEBCMessage> Out_ExecuteFirstEBC;

        public event Action<IEBCBase> Out_EBCAdded;

        public void In_KeyDown(KeyEventArgs keyEventArgs)
        {
            if (keyEventArgs.KeyCode == Keys.Delete)
            {
                this.DeleteShapes();

                this.Out_PaintRequest();
            }
            else if (keyEventArgs.KeyCode == Keys.Escape)
            {
                this.CancelConnection();
                this.DeselectAllShapes();

                this.Out_PaintRequest();
            }
            else if (keyEventArgs.KeyCode == Keys.ControlKey)
            {
                this.IsMultiSelect = true;
            }
            else if (keyEventArgs.KeyCode == Keys.C && keyEventArgs.Shift)
            {
                this.AutoConnectShapes();
            }
            else if (keyEventArgs.KeyCode == Keys.D && keyEventArgs.Shift)
            {
                this.AutoDisconnectShapes();
            }
        }

        private void AutoDisconnectShapes()
        {
            IShapeBase lastShape = null;
            bool deleted = true;

            foreach (var shape in this.SelectedShapes)
            {
                if (lastShape != null)
                {
                    if (this.ConnectionStartShapes.ContainsKey(lastShape) && this.ConnectionEndShapes.ContainsKey(shape))
                    {
                        List<ConnectionShape> connectionStartShapes = this.ConnectionStartShapes[lastShape];
                        List<ConnectionShape> connectionEndShapes = this.ConnectionEndShapes[shape];
                        List<ConnectionShape> deletedConnectionShapes = new List<ConnectionShape>();

                        foreach (var startConnection in connectionStartShapes)
                        {
                            foreach (var endConnection in connectionEndShapes)
                            {
                                if (startConnection == endConnection)
                                {
                                    this.DeleteShape(startConnection);

                                    if (!deletedConnectionShapes.Contains(startConnection))
                                    {
                                        deletedConnectionShapes.Add(startConnection);
                                    }

                                    deleted = true;

                                    this.DisconnectEBCs(startConnection);
                                }
                            }
                        }

                        foreach (var deletedConnection in deletedConnectionShapes)
                        {
                            this.ConnectionStartShapes[lastShape].Remove(deletedConnection);
                            this.ConnectionEndShapes[shape].Remove(deletedConnection);
                        }
                    }
                }

                lastShape = shape;
            }

            if (deleted)
            {
                this.Out_PaintRequest();
            }
        }

        private void DisconnectEBCs(ConnectionShape connectionShape)
        {
            IShapeBase outputShape = connectionShape.OutputShape;
            IShapeBase inputShape = connectionShape.InputShape;

            IEBCBase outputEBC = this.ShapeToEBC[outputShape.ID];
            IEBCBase inputEBC = this.ShapeToEBC[inputShape.ID];

            this.Out_DisconnectEBCs(new DisconnectEBCMessage(outputEBC, inputEBC));
        }

        private void AutoConnectShapes()
        {
            IShapeBase outputShape = null;

            foreach (var inputShape in this.SelectedShapes)
            {
                // If there is an outputShape and the relevant pins are enabled, connect them.
                if (outputShape != null && inputShape.IsInputPinEnabled && outputShape.IsOutputPinEnabled)
                {
                    ConnectionShape connectionShape = new ConnectionShape(inputShape, outputShape);

                    if (this.ConnectEBCs(connectionShape))
                    {
                        this.SetConnectionShapes(connectionShape);

                        this.AddShape(connectionShape);
                    }
                    else
                    {
                        this.IsMultiSelect = false;
                    }
                }

                outputShape = inputShape;
            }

            this.Out_PaintRequest();
        }

        public void In_KeyUp(KeyEventArgs keyEventArgs)
        {
            if (keyEventArgs.KeyCode == Keys.ControlKey)
            {
                this.IsMultiSelect = false;
            }
        }

        private void DeselectAllShapes()
        {
            foreach (var shape in this.SelectedShapes)
            {
                shape.IsSelected = false;
                shape.IsDraged = false;

                shape.MultiSelectNumber = -1;
            }

            this.SelectedShapes.Clear();
        }

        private void CancelConnection(bool deleteShape)
        {
            if (this.LastConnection != null)
            {
                if (deleteShape)
                {
                    this.DeleteShape(this.LastConnection);
                }

                this.LastConnection = null;
                this.LastConnectionTmpMouseMove = null;
                this.LastClickedShape = null;

                this.OnInner_ChangeShapeStatus(true);
            }
        }

        private void CancelConnection()
        {
            this.CancelConnection(true);
        }

        private void DeleteShapes()
        {
            foreach (var shape in this.SelectedShapes)
            {
                this.DeleteShape(shape);
            }
        }

        private void DeleteShape(IShapeBase shape)
        {
            if (this.ShapeToEBC.ContainsKey(shape.ID))
            {
                IEBCBase ebc = this.ShapeToEBC[shape.ID];

                this.Out_DeleteEBC(ebc);

                ebc.RemoveEvents();

                this.EBCtoShape.Remove(ebc);
                this.EBCs.Remove(ebc);
            }

            if (this.ConnectionStartShapes.ContainsKey(shape))
            {
                foreach (var connectionShape in this.ConnectionStartShapes[shape])
                {
                    this.DeleteShape(connectionShape);
                }

                this.ConnectionStartShapes.Remove(shape);
            }

            if (this.ConnectionEndShapes.ContainsKey(shape))
            {
                foreach (var connectionShape in this.ConnectionEndShapes[shape])
                {
                    this.DeleteShape(connectionShape);
                }

                this.ConnectionEndShapes.Remove(shape);
            }

            shape.RemoveEvents();

            if (this.MouseEvents.ContainsKey(shape))
            {
                foreach (var mouseEvent in this.MouseEvents[shape])
                {
                    switch (mouseEvent.Key)
                    {
                        case "MouseMove":
                            this.Out_MouseMove -= mouseEvent.Value;
                            break;
                        case "MouseClick":
                            this.Out_MouseClick -= mouseEvent.Value;
                            break;
                        case "MouseUp":
                            this.Out_MouseUp -= mouseEvent.Value;
                            break;
                        case "MouseDown":
                            this.Out_MouseDown -= mouseEvent.Value;
                            break;
                        case "MouseDoubleClick":
                            this.Out_MouseDoubleClick -= mouseEvent.Value;
                            break;
                    }
                }

                this.MouseEvents.Remove(shape);
            }

            this.Shapes.Remove(shape.ID);
            this.ShapeLevels.Remove(shape.ID);
            this.ShapeToEBC.Remove(shape.ID);
        }

        public event Action<IEBCBase> Out_DeleteEBC;

        public void In_MouseDoubleClick(MouseEventArgs mouseEventArgs)
        {
            if (this.Out_MouseDoubleClick != null)
                this.Out_MouseDoubleClick(mouseEventArgs);
        }

        public event Action<MouseEventArgs> Out_MouseDoubleClick;

        public void In_ShapeMode(IShapeModeMessage shapeModeMessage)
        {
            this.EBCConnectionsAllowed = shapeModeMessage.ShapeMode == ShapeModes.Edit;

            // Shapes are only active when we are in edit-mode.
            this.OnInner_ChangeShapeStatus(shapeModeMessage.ShapeMode == ShapeModes.Edit);

            this.Out_PaintRequest();
        }

        private void OnInner_ChangeShapeStatus(bool isShapeActive)
        {
            if (this.Inner_ChangeShapeStatus != null)
            {
                this.Inner_ChangeShapeStatus(new ChangeShapeStatusMessage(isShapeActive));
            }
        }

        public event Action<ISTEConnectMessage> Out_STEAutoConnect;

        public event Action<IErrorMessage> Out_ReportError;

        private void OnOut_ReportError(Exception exception)
        {
            if (this.Out_ReportError != null)
            {
                this.Out_ReportError(new ErrorMessage(exception));
            }
        }

        public event Action<IDisconnectEBCMessage> Out_DisconnectEBCs;
    }
}