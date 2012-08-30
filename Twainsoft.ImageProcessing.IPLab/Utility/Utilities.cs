#region Namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

#endregion

namespace Twainsoft.ImageProcessing.IPLab.Utility
{
    public static class Utilities
    {
        #region GetGrayValueColor

        public static Color GetGrayValueColor(int grayValue)
        {
            return Color.FromArgb(255, grayValue, grayValue, grayValue);
        }

        #endregion
    }
}