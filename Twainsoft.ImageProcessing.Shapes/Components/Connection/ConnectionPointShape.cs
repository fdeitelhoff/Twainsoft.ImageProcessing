#region Namespaces

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using Twainsoft.ImageProcessing.Shapes.Contracts.Connection;
using Twainsoft.ImageProcessing.Shapes.Util.Extensions;
using Twainsoft.ImageProcessing.Shapes.Components.Base;

#endregion

namespace Twainsoft.ImageProcessing.Shapes.Components.Connection
{
    public partial class ConnectionPointShape : ShapeBase, IConnectionPointShape
    {
        private Rectangle border;
        public Point Center { get; private set; }

        public ConnectionPointShape(Point centerPoint)
        {
            InitializeComponent();

            this.Center = centerPoint;
            this.border = new Rectangle(this.Center.X - 4, this.Center.Y - 4, 8, 8);
        }

        public override void Paint(Graphics graphics)
        {
            graphics.DrawRectangle(Pens.Red, this.border);
        }

        public override void In_MouseDown(MouseEventArgs mouseEventArgs)
        {
            if (mouseEventArgs.Button == MouseButtons.Left)
            {
                base.In_MouseDown(mouseEventArgs);

                this.IsDraged = this.border.Contains(mouseEventArgs.Location);
            }
        }

        public override void In_MouseUp(MouseEventArgs mouseEventArgs)
        {
            this.IsDraged = false;
        }

        public override void In_MouseMove(MouseEventArgs mouseEventArgs)
        {
            if (this.IsDraged)
            {
                this.border.X = mouseEventArgs.X - 4;
                this.border.Y = mouseEventArgs.Y - 4;
                this.Center = this.border.Center();

                this.Out_PointDragged();
            }
        }

        public event Action Out_PointDragged;

        public bool CheckClickStatus(Point location)
        {
            return this.border.Contains(location);
        }
    }
}