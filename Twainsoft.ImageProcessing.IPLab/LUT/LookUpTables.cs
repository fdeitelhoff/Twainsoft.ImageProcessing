#region Namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

#endregion

namespace Twainsoft.ImageProcessing.IPLab.LUT
{
    public static class LookUpTables
    {
        #region CreateLookUpTable

        public static int[] CreateLookUpTable(int[] cumulativeHistogram)
        {
            int[] lookUpTable = new int[cumulativeHistogram.Length];

            for (int i = 0; i < cumulativeHistogram.Length; i++)
            {
                lookUpTable[i] = (int)(((double)cumulativeHistogram[i] / cumulativeHistogram[cumulativeHistogram.Length - 1]) * 255);
            }

            return lookUpTable;
        }

        #endregion
    }
}