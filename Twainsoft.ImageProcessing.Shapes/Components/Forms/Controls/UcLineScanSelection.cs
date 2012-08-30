#region Namespaces

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

#endregion

namespace Twainsoft.ImageProcessing.Shapes.Components.Forms.Controls
{
    public partial class UcLineScanSelection : UserControl
    {
        public Dictionary<int, int> Points { get; private set; }
        private Point StartPoint { get; set; }
        private Point EndPoint { get; set; }

        public UcLineScanSelection()
        {
            InitializeComponent();

            this.Points = new Dictionary<int, int>();
        }

        public UcLineScanSelection(Bitmap image)
            : this()
        {
            this.pictureBox.Image = image;
        }
        
        private void UcLineScanSelection_MouseClick(object sender, MouseEventArgs e)
        {
            if (this.StartPoint != Point.Empty && this.EndPoint != Point.Empty)
            {
                this.StartPoint = Point.Empty;
                this.EndPoint = Point.Empty;
            }

            if (this.StartPoint == Point.Empty)
                this.StartPoint = e.Location;
            else
                this.EndPoint = e.Location;

            if (this.StartPoint != Point.Empty && this.EndPoint != Point.Empty)
            {
                Points.Clear();

                int width = this.pictureBox.Width;

                if (this.SourceImage != null)
                    width = this.SourceImage.Width;

                for (int x = 0; x < width; x++)
                {
                    int y = this.CalcPoint(x);
                    
                    Points.Add(x, y);
                }

                this.pictureBox.Invalidate();
            }
        }

        private Bitmap SourceImage { get; set; }

        internal void SetSourceImage(Bitmap sourceImage)
        {
            this.SourceImage = sourceImage;
            this.pictureBox.Image = sourceImage;
        }

        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            if (this.StartPoint != Point.Empty && this.EndPoint != Point.Empty)
            {
                for (int x = 0; x < this.pictureBox.Width; x++)
                {
                    int y = this.CalcPoint(x);

                    e.Graphics.DrawRectangle(Pens.Red, x, y, 1, 1);
                }
            }
        }

        private int CalcPoint(int x)
        {
            int y = (int)((double)(this.EndPoint.Y - this.StartPoint.Y) / (double)(this.EndPoint.X - this.StartPoint.X) * x
                + (this.StartPoint.Y - (double)((this.EndPoint.Y - this.StartPoint.Y) / (this.EndPoint.X - this.StartPoint.X)) * this.StartPoint.X));

            return y;
        }
    }
}