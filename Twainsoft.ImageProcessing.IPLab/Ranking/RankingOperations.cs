#region Namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Twainsoft.ImageProcessing.IPLab.Utility;

#endregion

namespace Twainsoft.ImageProcessing.IPLab.Ranking
{
    public static class RankingOperations
    {
        #region ImageDilatation

        public static Bitmap ImageDilatation(Bitmap sourceImage, int[,] matrix)
        {
            Bitmap resultingImage = new Bitmap(sourceImage.Width, sourceImage.Height);

            int rows = sourceImage.Height;
            int columns = sourceImage.Width;
            int matrixRows = matrix.GetUpperBound(0);
            int matrixColumns = matrix.GetUpperBound(1);

            List<int> rankedList = new List<int>();

            for (int y = 1; y < rows - 1; y++)
            {
                for (int x = 1; x < columns - 1; x++)
                {
                    rankedList.Clear();

                    // loop through the filter matrix.
                    for (int u = -1; u < matrixRows; u++)
                    {
                        for (int v = -1; v < matrixColumns; v++)
                        {
                            rankedList.Add(sourceImage.GetPixel(x + u, y + v).R * matrix[u + 1, v + 1]);
                        }
                    }

                    resultingImage.SetPixel(x, y, Utilities.GetGrayValueColor(rankedList.Max()));
                }
            }

            return resultingImage;
        }

        #endregion

        #region ImageErodation

        public static Bitmap ImageErodation(Bitmap sourceImage, int[,] matrix)
        {
            Bitmap resultingImage = new Bitmap(sourceImage.Width, sourceImage.Height);

            int rows = sourceImage.Height;
            int columns = sourceImage.Width;
            int matrixRows = matrix.GetUpperBound(0);
            int matrixColumns = matrix.GetUpperBound(1);

            List<int> rankedList = new List<int>();

            for (int y = 1; y < rows - 1; y++)
            {
                for (int x = 1; x < columns - 1; x++)
                {
                    rankedList.Clear();

                    // loop through the filter matrix.
                    for (int u = -1; u < matrixRows; u++)
                    {
                        for (int v = -1; v < matrixColumns; v++)
                        {
                            rankedList.Add(sourceImage.GetPixel(x + u, y + v).R * matrix[u + 1, v + 1]);
                        }
                    }

                    resultingImage.SetPixel(x, y, Utilities.GetGrayValueColor(rankedList.Min()));
                }
            }

            return resultingImage;
        }

        #endregion

        #region ImageMedian

        public static Bitmap ImageMedian(Bitmap sourceImage, int[,] matrix)
        {
            Bitmap resultingImage = new Bitmap(sourceImage.Width, sourceImage.Height);

            int rows = sourceImage.Height;
            int columns = sourceImage.Width;
            int matrixRows = matrix.GetUpperBound(0);
            int matrixColumns = matrix.GetUpperBound(1);

            List<int> rankedList = new List<int>();

            for (int y = 1; y < rows - 1; y++)
            {
                for (int x = 1; x < columns - 1; x++)
                {
                    rankedList.Clear();

                    // loop through the filter matrix.
                    for (int u = -1; u < matrixRows; u++)
                    {
                        for (int v = -1; v < matrixColumns; v++)
                        {
                            rankedList.Add(sourceImage.GetPixel(x + u, y + v).R * matrix[u + 1, v + 1]);
                        }
                    }

                    resultingImage.SetPixel(x, y, Utilities.GetGrayValueColor(Convert.ToInt32(Median(rankedList))));
                }
            }

            return resultingImage;
        }

        #endregion

        #region Median

        private static decimal Median(List<int> collection)
        {
            var array = collection.ToArray();

            int count = array.Length;

            Array.Sort(array);

            decimal medianValue = 0;

            if (count % 2 == 0)
            {
                // count is even, need to get the middle two elements and calculate the arithmethic median.
                int middleElement1 = array[(count / 2) - 1];
                int middleElement2 = array[(count / 2)];
                medianValue = (middleElement1 + middleElement2) / 2;
            }
            else
            {
                // count is odd, simply get the middle element.
                medianValue = array[(count / 2)];
            }

            return medianValue;
        }

        #endregion

        #region Laplace

        public static Bitmap ApplyLaplace(Bitmap sourceImage, int[,] matrix)
        {
            Bitmap resultingImage = new Bitmap(sourceImage.Width, sourceImage.Height);

            int N = 0;

            for (int u = 0; u <= matrix.GetUpperBound(0); u++)
            {
                for (int v = 0; v <= matrix.GetUpperBound(1); v++)
                {
                    N += Math.Abs(matrix[u, v]);
                }
            }

            int rows = sourceImage.Height;
            int columns = sourceImage.Width;
            int matrixRows = matrix.GetUpperBound(0);
            int matrixColumns = matrix.GetUpperBound(1);
            int k = (matrixRows - 1) / 2;
            int m = (matrixColumns - 1) / 2;

            int G = 0;

            for (int y = 1; y < rows - 1; y++)
            {
                for (int x = 1; x < columns - 1; x++)
                {
                    for (int v = 0; v < matrixRows - 1; v++)
                    {
                        for (int u = 0; u < matrixColumns - 1; u++)
                        {
                            G += sourceImage.GetPixel(x - k + u, y - m + v).R * matrix[u, v];
                        }
                    }

                    G = (int)(G * 1.0 / (double)N);

                    resultingImage.SetPixel(x, y, Utilities.GetGrayValueColor(G));
                }
            }

            return resultingImage;
        }

        #endregion
    }
}