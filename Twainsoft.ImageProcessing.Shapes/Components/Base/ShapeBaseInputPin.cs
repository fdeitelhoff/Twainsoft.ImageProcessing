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
    public partial class ShapeBaseInputPin : Component, IShapeBasePin
    {
        private Rectangle inputPin;

        private Pen InputColorPen { get; set; }
        private Brush InputColorBrush { get; set; }

        private Pen InputActiveColorPen { get; set; }
        private Brush InputActiveColorBrush { get; set; }
        private Pen InputDeactiveColorPen { get; set; }
        private Brush InputDeactiveColorBrush { get; set; }

        private Color InputActiveColor { get; set; }
        private Color InputDeactiveColor { get; set; }

        public bool IsActive
        {
            set
            {
                if (value)
                {
                    this.InputColorPen = this.InputActiveColorPen;
                    this.InputColorBrush = this.InputActiveColorBrush;
                }
                else
                {
                    this.InputColorPen = this.InputDeactiveColorPen;
                    this.InputColorBrush = this.InputDeactiveColorBrush;
                }
            }
        }

        public bool IsEnabled { get; set; }

        public ShapeBaseInputPin()
        {
            InitializeComponent();

            this.InputActiveColor = Color.FromArgb(170, 45, 139, 255);
            this.InputDeactiveColor = Color.FromArgb(50, 45, 139, 255);

            this.InputActiveColorPen = new Pen(this.InputActiveColor, 1);
            this.InputActiveColorBrush = new SolidBrush(this.InputActiveColor);
            this.InputDeactiveColorPen = new Pen(this.InputDeactiveColor, 1);
            this.InputDeactiveColorBrush = new SolidBrush(this.InputDeactiveColor);

            this.IsActive = true;
            this.IsEnabled = true;
        }

        public void Paint(Graphics graphics)
        {
            if (this.IsEnabled)
            {
                graphics.DrawRectangle(this.InputColorPen, this.inputPin);
                graphics.FillRectangle(this.InputColorBrush, this.inputPin);
            }
        }

        public void MoveTo(Rectangle rectangle)
        {
            this.inputPin.X = rectangle.X - 12;
            this.inputPin.Y = rectangle.Y;
        }

        public void SetPosition(Rectangle rectangle)
        {
            this.inputPin = new Rectangle(rectangle.X - 12, rectangle.Y, 12, rectangle.Height);
        }

        public Point Center()
        {
            return this.inputPin.Center();
        }

        public bool Contains(Point point)
        {
            return this.inputPin.Contains(point);
        }
    }
}