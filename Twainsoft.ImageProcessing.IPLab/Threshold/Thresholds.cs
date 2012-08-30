#region Namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Twainsoft.ImageProcessing.IPLab.Utility;

#endregion

namespace Twainsoft.ImageProcessing.IPLab.Threshold
{
    public static class Thresholds
    {
        #region ApplyThresholds

        public static Bitmap ApplyThresholds(Bitmap sourceImage, int[,] thresholds)
        {
            Bitmap resultingImage = new Bitmap(sourceImage.Width, sourceImage.Height);

            int rows = sourceImage.Height;
            int columns = sourceImage.Width;
            int currentGrayValue = 0;
            int defaultGrayValue = 155;
            bool wasThresholdUsed;

            for (int y = 0; y < rows; y++)
            {
                wasThresholdUsed = false;

                for (int x = 0; x < columns; x++)
                {
                    currentGrayValue = sourceImage.GetPixel(x, y).R;

                    for (int i = thresholds.GetLowerBound(0); i <= thresholds.GetUpperBound(0); i++)
                    {
                        if (currentGrayValue >= thresholds[i, 0] && currentGrayValue <= thresholds[i, 1])
                        {
                            resultingImage.SetPixel(x, y, Utilities.GetGrayValueColor(thresholds[i, 2]));

                            wasThresholdUsed = true;

                            break;
                        }
                    }

                    if (!wasThresholdUsed)
                    {
                        resultingImage.SetPixel(x, y, Utilities.GetGrayValueColor(defaultGrayValue));
                    }
                }
            }

            return resultingImage;
        }

        #endregion
    }
}