#region Namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Twainsoft.ImageProcessing.EBC.Contracts.Portals;
using System.Windows.Forms;
using Twainsoft.ImageProcessing.EBC.Contracts;
using Twainsoft.ImageProcessing.EBC.Contracts.Vocabulary.Messages;
using Twainsoft.ImageProcessing.EBC.Components.Vocabulary.Messages;
using Twainsoft.ImageProcessing.Shapes.Components.Vocabulary.Messages;
using Twainsoft.ImageProcessing.EBC.Contracts.Base;
using Twainsoft.ImageProcessing.EBC.Contracts.Execution;
using System.Drawing;
using Twainsoft.ImageProcessing.Shapes.Contracts.Vocabulary.Messages;
using Twainsoft.ImageProcessing.Shapes.Contracts;
using Twainsoft.ImageProcessing.Shapes.Contracts.Base;
using Twainsoft.ImageProcessing.Common.Contracts.Vocabulary.Messages;
using Twainsoft.ImageProcessing.EBC.Contracts.Shapes;

#endregion

namespace Twainsoft.ImageProcessing.EBC.Components.Portals
{
    public class PaintLeafPortal : IPaintLeafPortal
    {
        private IShapeController ShapeController { get; set; }

        private IExecutionController ExecutionController { get; set; }

        private ISTEConnector STEConnector { get; set; }

        public PaintLeafPortal(IShapeController shapeController, IExecutionController executionController, ISTEConnector steConnector)
        {
            this.ShapeController = shapeController;
            this.ExecutionController = executionController;
            this.STEConnector = steConnector;

            this.ShapeController.Out_PaintRequest += () => this.Out_InvalidateRequest();
            this.ShapeController.Out_ConnectEBCs += (IConnectEBCMessage connectEBCMessage) => this.ExecutionController.In_ConnectEBCs(connectEBCMessage);
            this.ShapeController.Out_DisconnectEBCs += (IDisconnectEBCMessage disconnectEBCMessage) => this.ExecutionController.In_DisconnectEBCs(disconnectEBCMessage);
            this.ShapeController.Out_ExecuteFirstEBC += (IExecuteFirstEBCMessage executeFirstEBCMessage) => this.ExecutionController.In_ExecuteFirstEBC(executeFirstEBCMessage);
            this.ShapeController.Out_EBCAdded += (IEBCBase ebcBase) => this.ExecutionController.In_EBCAdded(ebcBase);
            this.ShapeController.Out_DeleteEBC += (IEBCBase ebcBase) => this.ExecutionController.In_DeleteEBC(ebcBase);
            this.ShapeController.Out_STEAutoConnect += (ISTEConnectMessage steConnectMessage) => this.STEConnector.In_STEAutoConnect(steConnectMessage);
            this.ShapeController.Out_ReportError += (IErrorMessage errorMessage) => this.Out_ReportError(errorMessage);

            this.Out_AddShape += (IAddShapeMessage addShapeMessage) => this.ShapeController.In_AddShape(addShapeMessage);
            this.Out_PaintRequest += (IPaintRequestMessage paintRequestMessage) => this.ShapeController.In_PaintRequest(paintRequestMessage);
            this.Out_MouseClick += (MouseEventArgs mouseEventArgs) => this.ShapeController.In_MouseClick(mouseEventArgs);
            this.Out_MouseDoubleClick += (MouseEventArgs mouseEventArgs) => this.ShapeController.In_MouseDoubleClick(mouseEventArgs);
            this.Out_MouseUp += (MouseEventArgs mouseEventArgs) => this.ShapeController.In_MouseUp(mouseEventArgs);
            this.Out_MouseDown += (MouseEventArgs mouseEventArgs) => this.ShapeController.In_MouseDown(mouseEventArgs);
            this.Out_MouseMove += (MouseEventArgs mouseEventArgs) => this.ShapeController.In_MouseMove(mouseEventArgs);
            this.Out_KeyDown += (KeyEventArgs keyEventArgs) => this.ShapeController.In_KeyDown(keyEventArgs);
            this.Out_KeyUp += (KeyEventArgs keyEventArgs) => this.ShapeController.In_KeyUp(keyEventArgs);

            this.ExecutionController.Out_ExecutionFinished += (IExecutionFinishedMessage executionFinishedMessage) => this.Out_ExecutionFinished(executionFinishedMessage);
            this.ExecutionController.Out_EBCDebugMessage += (IEBCDebugMessage ebcDebugMessage) => this.Out_EBCDebugMessage(ebcDebugMessage);
            this.ExecutionController.Out_EBCWorkExceptionHandled += (IEBCExceptionMessage ebcExceptionMessage) => this.Out_EBCWorkExceptionHandled(ebcExceptionMessage);

            this.Out_ShapeMode += (IShapeModeMessage shapeModeMessage) => this.ShapeController.In_ShapeMode(shapeModeMessage);
        }

        public void In_MouseMove(MouseEventArgs mouseEventArgs)
        {
            this.Out_MouseMove(mouseEventArgs);
        }

        public event Action<MouseEventArgs> Out_MouseMove;


        public void In_PaintRequest(PaintEventArgs paintEventArgs)
        {
            //Console.WriteLine("In_PaintRequest");
            this.Out_PaintRequest(new PaintRequestMessage(paintEventArgs.Graphics));
        }

        public event Action<IPaintRequestMessage> Out_PaintRequest;


        public void In_MouseClick(MouseEventArgs mouseEventArgs)
        {
            this.Out_MouseClick(mouseEventArgs);
        }

        public event Action<MouseEventArgs> Out_MouseClick;

        public event Action Out_InvalidateRequest;


        public void In_MouseDown(MouseEventArgs mouseEventArgs)
        {
            this.Out_MouseDown(mouseEventArgs);
        }
        
        public void In_MouseUp(MouseEventArgs mouseEventArgs)
        {
            this.Out_MouseUp(mouseEventArgs);
        }

        public event Action<MouseEventArgs> Out_MouseUp;

        public event Action<MouseEventArgs> Out_MouseDown;

        public void In_AddShape(IShapeBase shapeBase, IEBCBase ebcBase, Point shapeLocation)
        {
            this.Out_AddShape(new AddShapeMessage(shapeBase, ebcBase, shapeLocation));
        }

        public event Action<IAddShapeMessage> Out_AddShape;

        public void In_KeyDown(KeyEventArgs keyEventArgs)
        {
            this.Out_KeyDown(keyEventArgs);
        }

        public event Action<KeyEventArgs> Out_KeyDown;

        public event Action<IExecutionFinishedMessage> Out_ExecutionFinished;


        public void In_MouseDoubleClick(MouseEventArgs mouseEventArgs)
        {
            this.Out_MouseDoubleClick(mouseEventArgs);
        }

        public event Action<MouseEventArgs> Out_MouseDoubleClick;

        public event Action<IEBCExceptionMessage> Out_EBCWorkExceptionHandled;
        
        public void In_ShapeMode(IShapeModeMessage shapeModeMessage)
        {
            this.Out_ShapeMode(shapeModeMessage);
        }

        public event Action<IShapeModeMessage> Out_ShapeMode;

        public event Action<IErrorMessage> Out_ReportError;

        public event Action<IEBCDebugMessage> Out_EBCDebugMessage;

        public void In_KeyUp(KeyEventArgs keyEventArgs)
        {
            this.Out_KeyUp(keyEventArgs);
        }

        public event Action<KeyEventArgs> Out_KeyUp;
    }
}