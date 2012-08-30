#region Namespaces

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Twainsoft.ImageProcessing.Shapes.Contracts.Vocabulary.Messages;
using Twainsoft.ImageProcessing.Shapes.Components.Vocabulary.Messages;

#endregion

namespace Twainsoft.ImageProcessing.Shapes.Components.Forms
{
    public partial class FrmEllipseScanShapeOptions : FrmShapeOptionsBase
    {
        private Point EllipseCenter { get; set; }
        private bool IsCenterValid { get; set; }
        private bool IsDragMode { get; set; }
        private Pen EllipsePen { get; set; }

        private int T { get; set; }
        private double W { get; set; }

        public FrmEllipseScanShapeOptions()
        {
            InitializeComponent();

            this.T = 360;
            this.W = 2 * Math.PI / T;
        }

        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            if (!this.IsCenterValid)
                return;

            if (this.IsDragMode)
            {
                this.EllipsePen = Pens.Black;
            }
            else
            {
                this.EllipsePen = Pens.Red;
            }

            double i_e;
            double j_e;

            for (int t = 0; t < this.T; t++)
            {
                i_e = Convert.ToInt32(this.nudEllipseWidth.Value) * Math.Sin(this.W * t) + this.EllipseCenter.X;
                j_e = Convert.ToInt32(this.nudEllipseHeight.Value) * Math.Cos(this.W * t) + this.EllipseCenter.Y;

                e.Graphics.DrawRectangle(this.EllipsePen, (int)i_e, (int)j_e, 1, 1);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void nudEllipseHeight_ValueChanged(object sender, EventArgs e)
        {
            this.pictureBox.Invalidate();
        }

        private void nudEllipseWidth_ValueChanged(object sender, EventArgs e)
        {
            this.pictureBox.Invalidate();
        }

        internal void SetSourceImage(Bitmap sourceImage)
        {
            this.pictureBox.Image = sourceImage;
        }

        public IEllipseScanCoordinatesMessage GetEllipseScanCoordinatesMessage()
        {
            return new EllipseScanCoordinatesMessage(this.EllipseCenter,
                Convert.ToInt32(this.nudEllipseWidth.Value),
                Convert.ToInt32(this.nudEllipseHeight.Value));
        }

        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            this.IsCenterValid = true;

            this.IsDragMode = true;

            this.UpdateEllipseData(e.Location);
        }

        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            this.IsDragMode = false;

            this.UpdateEllipseData(e.Location);
        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.IsDragMode)
            {
                this.UpdateEllipseData(e.Location);
            }
        }

        private void UpdateEllipseData(Point location)
        {
            this.EllipseCenter = location;

            this.tbEllipseCenter.Text = this.EllipseCenter.ToString();

            this.pictureBox.Invalidate();
        }
    }
}