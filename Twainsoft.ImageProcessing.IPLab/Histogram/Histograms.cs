#region Namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

#endregion

namespace Twainsoft.ImageProcessing.IPLab.Histogram
{
    public static class Histograms
    {
        #region CreateGrayValueHistogram

        public static int[] CreateGrayValueHistogram(Bitmap sourceImage)
        {
            int[] grayValueHistogram = new int[256];

            int rows = sourceImage.Height;
            int columns = sourceImage.Width;

            for (int y = 0; y < rows; y++)
            {
                for (int x = 0; x < columns; x++)
                {
                    grayValueHistogram[sourceImage.GetPixel(x, y).R]++;
                }
            }

            return grayValueHistogram;
        }

        #endregion

        #region CreateCumulativeHistogram

        public static int[] CreateCumulativeHistogram(int[] grayValueHistogram)
        {
            int[] cumulativeHistogram = new int[grayValueHistogram.Length];

            for (int i = 1; i < grayValueHistogram.Length; i++)
            {
                cumulativeHistogram[i] = cumulativeHistogram[i - 1] + grayValueHistogram[i];

            }

            return cumulativeHistogram;
        }

        #endregion
        
        #region CreateHistogramEqualizedImage

        public static Bitmap CreateHistogramEqualizedImage(int[] lookUpTable, Bitmap sourceImage)
        {
            int rows = sourceImage.Height;
            int columns = sourceImage.Width;

            Bitmap resultingImage = new Bitmap(columns, rows);

            for (int y = 0; y < rows; y++)
            {
                for (int x = 0; x < columns; x++)
                {
                    int grayValue = sourceImage.GetPixel(x, y).R;

                    Color equalizedColor = Color.FromArgb(255, lookUpTable[grayValue],
                        lookUpTable[grayValue], lookUpTable[grayValue]);

                    resultingImage.SetPixel(x, y, equalizedColor);
                }
            }

            return resultingImage;
        }

        #endregion
    }
}