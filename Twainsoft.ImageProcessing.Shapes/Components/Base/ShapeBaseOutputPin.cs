#region Namespaces

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Drawing;
using Twainsoft.ImageProcessing.Shapes.Contracts.Base;
using Twainsoft.ImageProcessing.Shapes.Util.Extensions;

#endregion

namespace Twainsoft.ImageProcessing.Shapes.Components.Base
{
    public partial class ShapeBaseOutputPin : Component, IShapeBasePin
    {
        private Rectangle outputPin;

        private Pen OutputColorPen { get; set; }
        private Brush OutputColorBrush { get; set; }

        private Pen OutputActiveColorPen { get; set; }
        private Brush OutputActiveColorBrush { get; set; }
        private Pen OutputDeactiveColorPen { get; set; }
        private Brush OutputDeactiveColorBrush { get; set; }

        private Color OutputActiveColor { get; set; }
        private Color OutputDeactiveColor { get; set; }

        public bool IsEnabled { get; set; }

        public bool IsActive
        {
            set
            {
                if (value)
                {
                    this.OutputColorPen = this.OutputActiveColorPen;
                    this.OutputColorBrush = this.OutputActiveColorBrush;
                }
                else
                {
                    this.OutputColorPen = this.OutputDeactiveColorPen;
                    this.OutputColorBrush = this.OutputDeactiveColorBrush;
                }
            }
        }

        public ShapeBaseOutputPin()
        {
            InitializeComponent();

            this.OutputActiveColor = Color.FromArgb(170, 28, 97, 7);
            this.OutputDeactiveColor = Color.FromArgb(50, 28, 97, 7);

            this.OutputActiveColorPen = new Pen(this.OutputActiveColor, 1);
            this.OutputActiveColorBrush = new SolidBrush(this.OutputActiveColor);
            this.OutputDeactiveColorPen = new Pen(this.OutputDeactiveColor, 1);
            this.OutputDeactiveColorBrush = new SolidBrush(this.OutputDeactiveColor);

            this.IsActive = true;
            this.IsEnabled = true;
        }

        public void Paint(Graphics graphics)
        {
            if (this.IsEnabled)
            {
                graphics.DrawRectangle(this.OutputColorPen, this.outputPin);
                graphics.FillRectangle(this.OutputColorBrush, this.outputPin);
            }
        }

        public void MoveTo(Rectangle rectangle)
        {
            this.outputPin.X = rectangle.X + rectangle.Width;
            this.outputPin.Y = rectangle.Y;
        }

        public void SetPosition(Rectangle rectangle)
        {
            this.outputPin = new Rectangle(rectangle.X + rectangle.Width, rectangle.Y, 12, rectangle.Height);
        }

        public Point Center()
        {
            return this.outputPin.Center();
        }

        public bool Contains(Point point)
        {
            return this.outputPin.Contains(point);
        }
    }
}