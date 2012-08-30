#region Namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Twainsoft.ImageProcessing.Common.Contracts.Vocabulary.Messages;
using System.Drawing;

#endregion

namespace Twainsoft.ImageProcessing.Common.Components.Vocabulary.Messages
{
    public class CachedImageMessage : ICachedImageMessage
    {
        public Bitmap CachedImage { get; private set; }

        public CachedImageMessage(Bitmap cachedImage)
        {
            this.CachedImage = cachedImage;
        }
    }
}