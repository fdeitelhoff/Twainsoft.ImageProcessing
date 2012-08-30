#region Namespaces

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using Twainsoft.ImageProcessing.Shapes.Util.Extensions;
using Twainsoft.ImageProcessing.Shapes.Components.Vocabulary.Messages;
using Twainsoft.ImageProcessing.Shapes.Contracts.Vocabulary.Messages;
using Twainsoft.ImageProcessing.Shapes.Contracts.Base;
using System.Drawing.Drawing2D;
using Twainsoft.ImageProcessing.Shapes.Properties;
using Twainsoft.ImageProcessing.Shapes.Contracts.Vocabulary.Data;
using Twainsoft.ImageProcessing.Shapes.Components.Forms;
using Twainsoft.ImageProcessing.Common.Contracts.Vocabulary.Messages;
using Twainsoft.ImageProcessing.Common.Components.Vocabulary.Messages;
using Twainsoft.ImageProcessing.Common.Contracts.Vocabulary.Exceptions;
using Twainsoft.ImageProcessing.Common.Contracts.Vocabulary.Data;
using Twainsoft.ImageProcessing.Shapes.Components.Forms.Adapter;
using Twainsoft.ImageProcessing.Common.Components.Vocabulary.Data;

#endregion

namespace Twainsoft.ImageProcessing.Shapes.Components.Base
{
    public partial class ShapeBase : Component, IShapeBase
    {
        private Rectangle shapeBorder;
        private bool isSelected;
        private bool isHovered;
        private Rectangle exclamationImageRectangle;

        public Guid ID { get; private set; }

        public string Name { get; set; }

        public bool IsDraged { get; set; }
        private bool HasError { get; set; }
        public bool IsActive { get; set; }

        protected int LastClickedX { get; set; }
        protected int LastClickedY { get; set; }

        private long ExecutionTime { get; set; }
        private string ExecutionTimeText { get; set; }

        private IShapeBasePin InputPin { get; set; }
        private IShapeBasePin OutputPin { get; set; }

        private Pen NormalPen { get; set; }
        private Pen SelectedPen { get; set; }
        private Pen ShapeBorderPen { get; set; }

        private Font NameFont { get; set; }
        private StringFormat NameFontFormat { get; set; }

        private Bitmap ExclamationImage { get; set; }
        private IWorkException WorkException { get; set; }

        private Rectangle multiSelectNumberRectangle;
        private Font MultiSelectNumberFont { get; set; }
        private StringFormat MultiSelectNumberFontFormat { get; set; }

        protected ImageTypes LastImageType { get; set; }

        public bool IsSelected
        {
            get { return this.isSelected; }
            set
            {
                this.isSelected = value;

                if (value || this.IsHovered)
                {
                    this.ShapeBorderPen = this.SelectedPen;
                }
                else
                {
                    this.ShapeBorderPen = this.NormalPen;
                }
            }
        }

        public bool IsHovered
        {
            get { return this.isHovered; }
            set
            {
                this.isHovered = value;

                if (value || this.IsSelected)
                {
                    this.ShapeBorderPen = this.SelectedPen;
                }
                else
                {
                    this.ShapeBorderPen = this.NormalPen;
                }
            }
        }

        private List<IShapeDebugMessage> DebugMessages { get; set; }

        public int MultiSelectNumber { get; set; }

        public bool IsInputPinEnabled
        {
            get
            {
                return this.InputPin.IsEnabled;
            }
            set
            {
                this.InputPin.IsEnabled = value;
            }
        }

        public bool IsOutputPinEnabled
        {
            get
            {
                return this.OutputPin.IsEnabled;
            }
            set
            {
                this.OutputPin.IsEnabled = value;
            }
        }

        public ShapeBase()
        {
            InitializeComponent();

            this.ID = Guid.NewGuid();
            this.shapeBorder = new Rectangle(100, 100, 100, 60);
            this.ExecutionTime = -1;

            this.InputPin = new ShapeBaseInputPin();
            this.OutputPin = new ShapeBaseOutputPin();

            this.NormalPen = Pens.Black;
            this.SelectedPen = new Pen(Brushes.Red);
            this.SelectedPen.DashStyle = DashStyle.DashDotDot;

            this.ShapeBorderPen = this.NormalPen;

            this.NameFont = new Font("Arial", 10);

            this.NameFontFormat = new StringFormat()
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            this.ExclamationImage = Resources.Exclamation;

            this.DebugMessages = new List<IShapeDebugMessage>();

            this.MultiSelectNumber = -1;
            
            this.MultiSelectNumberFont = new Font("Arial", 10, FontStyle.Italic);

            this.MultiSelectNumberFontFormat = new StringFormat()
            {
                Alignment = StringAlignment.Far,
                LineAlignment = StringAlignment.Center
            };

            this.LastImageType = ImageTypes.Default;

            this.BuildOwnContextMenu();
        }

        private void BuildOwnContextMenu()
        {
            this.tsmiStart.Click += (object sender, EventArgs e) => this.Out_StartProcess();
            this.tsmiShowError.Click += new EventHandler(tsmiShowError_Click);
            this.tsmiImageType.Click += new EventHandler(tsmiImageType_Click);

            this.tsmiShowDebugData.Click += new EventHandler(tsmiShowDebugData_Click);

            this.tsmiProtocolOutputData.Click += (object sender, EventArgs e) => this.ChangeDataBehaviour();
            this.tsmiProtocolDebugData.Click += (object sender, EventArgs e) => this.ChangeDataBehaviour();
            this.tsmiProtocolBoth.Click += new EventHandler(tsmiProtocolBoth_Click);

            this.tsmiChangeInputPinStatus.Click += (object sender, EventArgs e) => this.ChangePinStatus(PinTypes.Input, this.tsmiChangeInputPinStatus.Checked);
            this.tsmiChangeOutputPinStatus.Click += (object sender, EventArgs e) => this.ChangePinStatus(PinTypes.Output, this.tsmiChangeOutputPinStatus.Checked);
            this.tsmiChangeBothPinStatus.Click += new EventHandler(tsmiChangeBothPinStatus_Click);
        }

        void tsmiProtocolBoth_Click(object sender, EventArgs e)
        {
            this.tsmiProtocolOutputData.Checked = this.tsmiProtocolBoth.Checked;
            this.tsmiProtocolDebugData.Checked = this.tsmiProtocolBoth.Checked;
            
            this.ChangeDataBehaviour();
        }

        void tsmiImageType_Click(object sender, EventArgs e)
        {
            FrmImageLoadAdapterShapeOptions frmImageLoadAdapterShapeOptions = new FrmImageLoadAdapterShapeOptions(this.LastImageType);

            if (frmImageLoadAdapterShapeOptions.ShowDialog() == DialogResult.OK)
            {
                this.LastImageType = frmImageLoadAdapterShapeOptions.GetSelectedImageType();

                this.Out_ImageType(new ImageTypeMessage(this.LastImageType));
            }
        }

        private void ChangeDataBehaviour()
        {
            this.tsmiProtocolBoth.Checked = this.tsmiProtocolOutputData.Checked && this.tsmiProtocolDebugData.Checked;

            this.Out_ChangeDataBehaviour(new ChangeDataBehaviourMessage(this.tsmiProtocolOutputData.Checked, this.tsmiProtocolDebugData.Checked));
        }

        void tsmiShowDebugData_Click(object sender, EventArgs e)
        {
            FrmShapeDebugData frmShapeDebugData = new FrmShapeDebugData();
            frmShapeDebugData.SetDebugMessages(this.DebugMessages);
            frmShapeDebugData.ShowDialog();
        }

        void tsmiChangeBothPinStatus_Click(object sender, EventArgs e)
        {
            this.tsmiChangeInputPinStatus.Checked = this.tsmiChangeBothPinStatus.Checked;
            this.tsmiChangeOutputPinStatus.Checked = this.tsmiChangeBothPinStatus.Checked;

            this.ChangePinStatus(PinTypes.Input, this.tsmiChangeInputPinStatus.Checked);
            this.ChangePinStatus(PinTypes.Output, this.tsmiChangeOutputPinStatus.Checked);
        }

        private void ChangePinStatus(PinTypes pinType, bool status)
        {
            this.InputPin.IsActive = this.tsmiChangeInputPinStatus.Checked;
            this.OutputPin.IsActive = this.tsmiChangeOutputPinStatus.Checked;

            this.tsmiChangeBothPinStatus.Checked = this.tsmiChangeInputPinStatus.Checked && this.tsmiChangeOutputPinStatus.Checked;

            if (this.Out_ChangePinStatus != null)
            {
                this.Out_ChangePinStatus(new ChangePinStatusMessage(pinType, status));
            }
        }

        protected void MergeContextMenuItems(ContextMenuStrip contextMenuStrip)
        {
            ToolStripItem[] toolStripItems = new ToolStripItem[contextMenuStrip.Items.Count];
            contextMenuStrip.Items.CopyTo(toolStripItems, 0);
            this.cmsMain.Items.AddRange(toolStripItems);
        }

        public virtual void Paint(Graphics graphics)
        {
            // Paint the pins first.
            this.InputPin.Paint(graphics);
            this.OutputPin.Paint(graphics);

            if (this.IsActive)
            {
                // Then the shape and it's name.
                graphics.FillRectangle(Brushes.LightGray, this.shapeBorder);
                graphics.DrawRectangle(this.ShapeBorderPen, this.shapeBorder);

                graphics.DrawString(this.Name, this.NameFont, Brushes.Black, this.shapeBorder, this.NameFontFormat);

                // Draw the execution-time, if available.
                graphics.DrawString(this.ExecutionTimeText, this.NameFont, Brushes.Black, this.shapeBorder.Left, this.shapeBorder.Top - 17);
            }
            else
            {
                // Then the shape and it's name.
                graphics.FillRectangle(Brushes.Gray, this.shapeBorder);
                graphics.DrawRectangle(Pens.Gray, this.shapeBorder);

                graphics.DrawString(this.Name, this.NameFont, Brushes.White, this.shapeBorder, this.NameFontFormat);
            }

            // Draw the error image.
            if (this.HasError)
            {
                graphics.DrawImage(this.ExclamationImage, this.exclamationImageRectangle);
            }

            // Draw the multi-selection number, if set.
            if (this.MultiSelectNumber > 0)
            {
                graphics.DrawString(this.MultiSelectNumber.ToString(), this.MultiSelectNumberFont, Brushes.Black,
                    this.multiSelectNumberRectangle, this.MultiSelectNumberFontFormat);
            }
        }
        
        public bool CheckHoverStatus(Point point)
        {
            return this.IsHovered = this.shapeBorder.Contains(point) || (this.HasError && this.exclamationImageRectangle.Contains(point));
        }

        public bool CheckMousePosition(MouseEventArgs mouseEventArgs)
        {
            return this.shapeBorder.Contains(mouseEventArgs.Location)
                || (this.HasError && this.exclamationImageRectangle.Contains(mouseEventArgs.Location));
        }

        public virtual void In_MouseDown(MouseEventArgs mouseEventArgs)
        {
            this.LastClickedX = this.shapeBorder.X - mouseEventArgs.X;
            this.LastClickedY = this.shapeBorder.Y - mouseEventArgs.Y;
        }

        public virtual void In_MouseUp(MouseEventArgs mouseEventArgs)
        {
            this.IsDraged = false;

            if (mouseEventArgs.Button == MouseButtons.Left)
            {
                // Check the mouse position and the enabled status of the pins.
                if (this.OutputPin.IsEnabled && this.OutputPin.Contains(mouseEventArgs.Location))
                {
                    if (this.Out_PinClicked != null)
                        this.Out_PinClicked(new EBCPinClickedMessage(PinTypes.Output, this));
                }
                else if (this.InputPin.IsEnabled && this.InputPin.Contains(mouseEventArgs.Location))
                {
                    if (this.Out_PinClicked != null)
                        this.Out_PinClicked(new EBCPinClickedMessage(PinTypes.Input, this));
                }
            }
        }

        public virtual void In_MouseMove(MouseEventArgs mouseEventArgs)
        {
            if (this.IsActive && this.IsDraged)
            {
                Cursor.Current = Cursors.SizeAll;

                this.shapeBorder.X = mouseEventArgs.Location.X + this.LastClickedX;
                this.shapeBorder.Y = mouseEventArgs.Location.Y + this.LastClickedY;

                this.InputPin.MoveTo(this.shapeBorder);
                this.OutputPin.MoveTo(this.shapeBorder);

                this.exclamationImageRectangle.X = this.shapeBorder.Left + 2;
                this.exclamationImageRectangle.Y = this.shapeBorder.Bottom + 2;

                this.multiSelectNumberRectangle.X = this.shapeBorder.Left;
                this.multiSelectNumberRectangle.Y = this.shapeBorder.Bottom + 2;

                if (this.Out_ShapeDragged != null)
                    this.Out_ShapeDragged(new ShapeDraggedMessage(this.InputPin.Center(), this.OutputPin.Center()));

                this.Out_PaintRequest();
            }
            else if (this.IsSelected && this.exclamationImageRectangle.Contains(mouseEventArgs.Location))
            {
                Cursor.Current = Cursors.Hand;
            }
        }

        public event Action Out_PaintRequest;

        public event Action<IEBCPinClickedMessage> Out_PinClicked;
        
        public event Action<IShapeDraggedMessage> Out_ShapeDragged;

        public Point InputPinCenter()
        {
            return this.InputPin.Center();
        }

        public Point OutputPinCenter()
        {
            return this.OutputPin.Center();
        }

        protected virtual void OnOut_PaintRequest()
        {
            if (this.Out_PaintRequest != null)
                this.Out_PaintRequest();
        }

        public virtual void In_MouseClick(MouseEventArgs mouseEventArgs)
        {
            if (this.IsSelected && this.IsActive && mouseEventArgs.Button == MouseButtons.Right)
            {
                this.cmsMain.Show(Cursor.Position);
            }
        }

        public event Action Out_StartProcess;

        public void SetInitialPosition(Point location)
        {
            // The shape.
            this.shapeBorder.X = location.X - (this.shapeBorder.Width / 2);
            this.shapeBorder.Y = location.Y - (this.shapeBorder.Height / 2);

            // Input and output pins.
            this.InputPin.SetPosition(this.shapeBorder);
            this.OutputPin.SetPosition(this.shapeBorder);
            
            // The error image.
            this.exclamationImageRectangle = new Rectangle(this.shapeBorder.Left + 2, this.shapeBorder.Bottom + 2, 16, 16);

            // The multi-select number.
            this.multiSelectNumberRectangle = new Rectangle(this.shapeBorder.Left, this.shapeBorder.Bottom + 2, this.shapeBorder.Width - 2, 13);
        }

        private void SetExecutionTime(long milliseconds)
        {
            this.ExecutionTime = milliseconds;

            if (this.ExecutionTime > 0)
            {
                this.ExecutionTimeText = this.ExecutionTime + " ms";
            }
            else if (this.ExecutionTime == 0)
            {
                this.ExecutionTimeText = "< 1 ms";
            }
            else
            {
                this.ExecutionTimeText = "";
            }

            this.Out_PaintRequest();
        }

        public void In_MouseDoubleClick(MouseEventArgs mouseEventArgs)
        {
            if (this.IsSelected && this.HasError)
            {
                this.ShowErrorWindow();
            }
        }

        private void ShowErrorWindow()
        {
            FrmShapeError frmShapeError = new FrmShapeError();
            frmShapeError.SetWorkException(this.WorkException);
            frmShapeError.Show();
        }

        void tsmiShowError_Click(object sender, EventArgs e)
        {
            this.ShowErrorWindow();
        }

        private void cmsMain_Opening(object sender, CancelEventArgs e)
        {
            this.tsmiShowError.Enabled = this.WorkException != null;
            this.tsmiShowDebugData.Enabled = this.DebugMessages.Count > 0;
        }

        public event Action<IChangePinStatusMessage> Out_ChangePinStatus;

        public void In_ExceptionInfo(IExceptionInfoMessage exceptionInfoMessage)
        {
            this.HasError = (exceptionInfoMessage.WorkException != null) ? true : false;

            this.WorkException = exceptionInfoMessage.WorkException;

            this.OnOut_PaintRequest();
        }

        public void In_ChangeShapeStatus(IChangeShapeStatusMessage changeShapeStatus)
        {
            this.IsActive = changeShapeStatus.IsShapeActive;
        }

        public void In_ShapeDebugMessage(IShapeDebugMessage debugMessage)
        {
            this.DebugMessages.Add(debugMessage);
        }

        public event Action<IChangeDataBehaviourMessage> Out_ChangeDataBehaviour;

        public virtual void RemoveEvents()
        {
            this.Out_ChangeDataBehaviour = null;
            this.Out_ChangePinStatus = null;
            this.Out_PaintRequest = null;
            this.Out_PinClicked = null;
            this.Out_ShapeDragged = null;
            this.Out_StartProcess = null;
        }

        public void In_ExecutionFinished(IExecutionTimeMessage executionTimeMessage)
        {
            this.SetExecutionTime(executionTimeMessage.UsedMilliseconds);
        }

        public event Action<IImageTypeMessage> Out_ImageType;
    }
}