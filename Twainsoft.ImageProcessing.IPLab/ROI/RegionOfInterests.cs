#region Namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Twainsoft.ImageProcessing.IPLab.Utility;

#endregion

namespace Twainsoft.ImageProcessing.IPLab.ROI
{
    public static class RegionOfInterests
    {
        public static Bitmap CreateROI(Bitmap sourceImage, int startX, int startY, int maxWidth, int maxHeight)
        {
            int rows = maxHeight;
            int columns = maxWidth;
            int grayValue = 0;

            Bitmap resultingImage = new Bitmap(columns, rows);

            for (int y = 0; y < rows; y++)
            {
                for (int x = 0; x < columns; x++)
                {
                    grayValue = sourceImage.GetPixel(x, y).R;

                    resultingImage.SetPixel(x, y, Utilities.GetGrayValueColor(grayValue));
                }
            }

            return resultingImage;
        }
    }
}