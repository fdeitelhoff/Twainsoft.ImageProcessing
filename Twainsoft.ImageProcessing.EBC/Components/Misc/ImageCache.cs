#region Namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Twainsoft.ImageProcessing.EBC.Contracts.Misc;
using Twainsoft.ImageProcessing.EBC.Components.Base;
using Twainsoft.ImageProcessing.EBC.Contracts.Vocabulary.Messages;
using Twainsoft.ImageProcessing.Common.Contracts.Vocabulary.Messages;
using Twainsoft.ImageProcessing.Common.Components.Vocabulary.Messages;
using Twainsoft.ImageProcessing.EBC.Components.Vocabulary.Messages;
using Twainsoft.ImageProcessing.EBC.Components.Vocabulary.Data;
using Twainsoft.ImageProcessing.Common.Components.Vocabulary.Data;

#endregion

namespace Twainsoft.ImageProcessing.EBC.Components.Misc
{
    public class ImageCache : EBCBase, IImageCache
    {
        public ImageCache()
        {
            this.Name = "Bild-Cache";
        }

        public override void MessageReceived(IEBCMessage ebcMessage)
        {
            this.OnOut_ShapeDebugMessage(new DebugData(DataResultTypes.CachedImage, ebcMessage.EBCMessageData.Image));

            this.Out_CachedImage(new CachedImageMessage(ebcMessage.EBCMessageData.Image));
        }

        public event Action<ICachedImageMessage> Out_CachedImage;

        public void In_SendCachedImage(ICachedImageMessage cachedImageMessage)
        {
            this.OnOut_SendResult(new EBCMessage(new EBCMessageData(DataResultTypes.CachedImage, cachedImageMessage.CachedImage)));
        }
    }
}