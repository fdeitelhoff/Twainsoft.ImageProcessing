#region Namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Twainsoft.ImageProcessing.IPLab.Utility;

#endregion

namespace Twainsoft.ImageProcessing.IPLab.FloodFill
{
    public static class FloodFills
    {
        #region FloodFill

        public static Bitmap FloodFill(Bitmap sourceImage, FloodFillModes floodFillMode, Point startPoint, int oldGrayValue, int newGrayValue)
        {
            int rows = sourceImage.Height;
            int columns = sourceImage.Width;

            Bitmap resultingImage = new Bitmap(sourceImage);

            Stack<Point> points = new Stack<Point>();
            points.Push(startPoint);

            Point currentPoint;
            while (points.Count > 0)
	        {
                currentPoint = points.Pop();

                if (currentPoint.Y < rows && currentPoint.X < columns && resultingImage.GetPixel(currentPoint.X, currentPoint.Y).R == oldGrayValue)
                {
                    resultingImage.SetPixel(currentPoint.X, currentPoint.Y, Utilities.GetGrayValueColor(newGrayValue));

                    points.Push(new Point(currentPoint.X, currentPoint.Y + 1));
                    points.Push(new Point(currentPoint.X, currentPoint.Y - 1));
                    points.Push(new Point(currentPoint.X + 1, currentPoint.Y));
                    points.Push(new Point(currentPoint.X - 1, currentPoint.Y));
                }
	        }

            return resultingImage;
        }

        #endregion
    }
}