#region Namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

#endregion

namespace Twainsoft.ImageProcessing.Shapes.Util.Extensions
{
    public static class RectangleExtensions
    {
        #region Rectangle.Center()

        public static Point Center(this Rectangle rectangle)
        {
            return new Point(rectangle.Left + rectangle.Width / 2,
                             rectangle.Top + rectangle.Height / 2);
        }

        #endregion
    }
}