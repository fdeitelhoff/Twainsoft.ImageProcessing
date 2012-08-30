#region Namespaces

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Twainsoft.ImageProcessing.Shapes.Contracts;
using System.Drawing;
using System.Windows.Forms;
using Twainsoft.ImageProcessing.Shapes.Contracts.Vocabulary.Messages;
using Twainsoft.ImageProcessing.Shapes.Contracts.Connection;
using System.Drawing.Drawing2D;
using Twainsoft.ImageProcessing.Shapes.Components.Base;
using Twainsoft.ImageProcessing.Shapes.Contracts.Base;

#endregion

namespace Twainsoft.ImageProcessing.Shapes.Components.Connection
{
    public partial class ConnectionShape : ShapeBase, IConnectionShape
    {
        enum LineDirection
        {
            InputToOutput,
            OutputToInput
        }

        public IShapeBase InputShape { get; private set; }
        public IShapeBase OutputShape { get; private set; }

        private Point StartPoint { get; set; }
        private Point EndPoint { get; set; }

        private bool IsBuilding { get; set; }
        private List<ConnectionPointShape> Points { get; set; }

        private Pen NormalLinePen { get; set; }
        private Pen FirstLinePen { get; set; }
        private Pen LastLinePen { get; set; }

        private LineDirection CurrentLineDirection { get; set; }

        public ConnectionShape()
            : base()
        {
            InitializeComponent();

            this.IsDraged = true;
            this.IsBuilding = true;

            this.Points = new List<ConnectionPointShape>();

            this.NormalLinePen = new Pen(Brushes.Black, 3);
            this.FirstLinePen = new Pen(Brushes.Black, 3);
            this.LastLinePen = new Pen(Brushes.Black, 3);
        }

        public ConnectionShape(IShapeBase inputShape, IShapeBase outputShape)
            : this()
        {
            this.SetInputShape(inputShape);
            this.SetOutputShape(outputShape);
        }

        public override void Paint(Graphics graphics)
        {
            Point lastPoint = this.StartPoint;
            bool firstLine = true;
            
            foreach (var item in this.Points)
            {
                if (firstLine)
                {
                    graphics.DrawLine(this.FirstLinePen, lastPoint, item.Center);
                    item.Paint(graphics);

                    firstLine = false;
                }
                else
                {
                    graphics.DrawLine(this.NormalLinePen, lastPoint, item.Center);
                    item.Paint(graphics);
                }

                lastPoint = item.Center;
            }

            // It depends on the way of creating the line, where to draw the arrow.
            if (this.CurrentLineDirection == LineDirection.OutputToInput)
                graphics.DrawLine(this.LastLinePen, lastPoint, this.EndPoint);
            else if (this.CurrentLineDirection == LineDirection.InputToOutput && !firstLine)
                graphics.DrawLine(this.NormalLinePen, lastPoint, this.EndPoint);
            else if (firstLine)
                graphics.DrawLine(this.FirstLinePen, lastPoint, this.EndPoint);         
        }

        public override void In_MouseMove(MouseEventArgs mouseEventArgs)
        {
            //Console.WriteLine("In_MouseMove: " + this.Name);
            if (this.IsDraged)
            {
                this.EndPoint = mouseEventArgs.Location;

                this.OnOut_PaintRequest();
            }
            else
            {
                if (this.Inner_MouseMove != null)
                    this.Inner_MouseMove(mouseEventArgs);
            }
        }

        public void SetInputShape(IShapeBase inputShape)
        {
            this.InputShape = inputShape;

            if (this.OutputShape == null)
            {
                this.FirstLinePen.CustomStartCap = new AdjustableArrowCap(5, 5);
                this.FirstLinePen.EndCap = LineCap.Round;

                this.CurrentLineDirection = LineDirection.InputToOutput;

                this.StartPoint = inputShape.InputPinCenter();
                this.InputShape.Out_ShapeDragged += (IShapeDraggedMessage shapeDraggedMessage) => { this.StartPoint = shapeDraggedMessage.InputPinCenter; };
            }
            else
            {
                this.EndPoint = inputShape.InputPinCenter();
                this.InputShape.Out_ShapeDragged += (IShapeDraggedMessage shapeDraggedMessage) => { this.EndPoint = shapeDraggedMessage.InputPinCenter; };
            }

            this.CheckStatus();
        }

        public void SetOutputShape(IShapeBase outputShape)
        {
            this.OutputShape = outputShape;

            if (this.InputShape == null)
            {
                this.LastLinePen.StartCap = LineCap.Round;
                this.LastLinePen.CustomEndCap = new AdjustableArrowCap(5, 5);

                this.CurrentLineDirection = LineDirection.OutputToInput;

                this.StartPoint = outputShape.OutputPinCenter();
                this.OutputShape.Out_ShapeDragged += (IShapeDraggedMessage shapeDraggedMessage) => { this.StartPoint = shapeDraggedMessage.OutputPinCenter; };
            }
            else
            {
                this.EndPoint = outputShape.OutputPinCenter();
                this.OutputShape.Out_ShapeDragged += (IShapeDraggedMessage shapeDraggedMessage) => { this.EndPoint = shapeDraggedMessage.OutputPinCenter; };
            }

            this.CheckStatus();
        }

        private void CheckStatus()
        {
            this.IsBuilding = this.InputShape == null || this.OutputShape == null;
            this.IsDraged = this.InputShape == null || this.OutputShape == null;
        }

        public override void In_MouseUp(MouseEventArgs mouseEventArgs)
        {
            if (this.IsBuilding && mouseEventArgs.Button == MouseButtons.Left)
            {
                ConnectionPointShape connectionPointShape = new ConnectionPointShape(mouseEventArgs.Location);
                this.Inner_MouseDown += (MouseEventArgs m) => connectionPointShape.In_MouseDown(m);
                this.Inner_MouseUp += (MouseEventArgs m) => connectionPointShape.In_MouseUp(m);
                this.Inner_MouseMove += (MouseEventArgs m) => connectionPointShape.In_MouseMove(m);
                connectionPointShape.Out_PointDragged += () => this.OnOut_PaintRequest();

                this.Points.Add(connectionPointShape);
            }

            if (this.Inner_MouseUp != null)
                this.Inner_MouseUp(mouseEventArgs);
        }

        public override void In_MouseDown(MouseEventArgs mouseEventArgs)
        {
            if (this.Inner_MouseDown != null)
                this.Inner_MouseDown(mouseEventArgs);
        }

        public override void In_MouseClick(MouseEventArgs mouseEventArgs)
        {
            if (mouseEventArgs.Button == MouseButtons.Right)
            {
                ConnectionPointShape currentPointShape = null;

                foreach (var connectionPoint in this.Points)
                {
                    if (connectionPoint.CheckClickStatus(mouseEventArgs.Location))
                    {
                        currentPointShape = connectionPoint;
                        break;
                    }
                }

                if (currentPointShape != null)
                {
                    this.Points.Remove(currentPointShape);

                    this.OnOut_PaintRequest();
                }
            }
        }

        private event Action<MouseEventArgs> Inner_MouseDown;

        private event Action<MouseEventArgs> Inner_MouseUp;

        private event Action<MouseEventArgs> Inner_MouseMove;

        public override void RemoveEvents()
        {
            base.RemoveEvents();

            this.Inner_MouseDown = null;
            this.Inner_MouseMove = null;
            this.Inner_MouseUp = null;
        }
    }
}