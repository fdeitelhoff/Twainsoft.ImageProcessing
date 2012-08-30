#region Namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

#endregion

namespace Twainsoft.ImageProcessing.Shapes.Components.Forms.Misc
{
    public class CachedImageEventArgs : EventArgs
    {
        public Bitmap CachedImage { get; set; }

        public CachedImageEventArgs(Bitmap cachedImage)
        {
            this.CachedImage = cachedImage;
        }
    }
}