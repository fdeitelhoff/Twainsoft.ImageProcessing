#region Namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

#endregion

namespace Twainsoft.ImageProcessing.IPLab.ImageScan
{
    public static class ImageScans
    {
        #region Line-Scan with coordinates

        public static int[] LineScan(Bitmap bitmap, Dictionary<int, int> coordinates)
        {
            int[] lineScanData = new int[bitmap.Width];

            for (int x = 0; x < bitmap.Width; x++)
            {
                lineScanData[x] = bitmap.GetPixel(x, coordinates[x]).R;
            }

            return lineScanData;
        }

        #endregion

        #region Ellipse-Scan with coordinates

        public static int[] EllipseScan(Bitmap sourceImage, Point ellipseCenter, int ellipseWidth, int ellipseHeight)
        {
            const int T = 360;

            double w = 2 * Math.PI / T;
            double i_e;
            double j_e;

            int[] ellipseScanData = new int[T];

            for (int t = 0; t < T; t++)
            {
                i_e = Convert.ToInt32(ellipseWidth) * Math.Sin(w * t) + ellipseCenter.X;
                j_e = Convert.ToInt32(ellipseHeight) * Math.Cos(w * t) + ellipseCenter.Y;

                ellipseScanData[t] = sourceImage.GetPixel((int)i_e, (int)j_e).R;

                sourceImage.SetPixel(
                    (int)i_e,
                    (int)j_e,
                    Color.FromArgb(255, 178, 34, 34));
            }

            return ellipseScanData;
        }

        #endregion
    }
}