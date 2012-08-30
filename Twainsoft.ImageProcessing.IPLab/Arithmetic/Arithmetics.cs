#region Namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Twainsoft.ImageProcessing.IPLab.Utility;

#endregion

namespace Twainsoft.ImageProcessing.IPLab.Arithmetic
{
    public static class Arithmetics
    {
        #region SubtractImages

        public static Bitmap SubtractImages(Bitmap minuend, Bitmap subtrahend)
        {
            if (minuend.Size != subtrahend.Size)
            {
                throw new ArgumentException("The images to subtract must have the same sizes!");
            }

            Bitmap newImage = new Bitmap(minuend.Width, minuend.Height);

            int rows = minuend.Height;
            int columns = minuend.Width;

            for (int y = 0; y < rows; y++)
            {
                for (int x = 0; x < columns; x++)
                {
                    newImage.SetPixel(x, y, Utilities.GetGrayValueColor(CheckGrayValueRange(minuend.GetPixel(x, y).R - subtrahend.GetPixel(x, y).R)));
                }
            }

            return newImage;
        }

        #endregion

        #region SumImages

        public static Bitmap SumImages(Bitmap firstSummand, Bitmap secondSummand)
        {
            if (firstSummand.Size != secondSummand.Size)
            {
                throw new ArgumentException("The images to sum must have the same sizes!");
            }

            Bitmap newImage = new Bitmap(firstSummand.Width, firstSummand.Height);

            int rows = firstSummand.Height;
            int columns = firstSummand.Width;

            for (int y = 0; y < rows; y++)
            {
                for (int x = 0; x < columns; x++)
                {
                    newImage.SetPixel(x, y, Utilities.GetGrayValueColor(Convert.ToInt32((firstSummand.GetPixel(x, y).R + secondSummand.GetPixel(x, y).R) * 0.5)));
                }
            }

            return newImage;
        }

        #endregion

        #region CheckGrayValueRange

        private static int CheckGrayValueRange(int pixel)
        {
            if (pixel < 0)
                pixel = 0;
            else if (pixel > 255)
                pixel = 255;

            return pixel;
        }

        #endregion
    }
}