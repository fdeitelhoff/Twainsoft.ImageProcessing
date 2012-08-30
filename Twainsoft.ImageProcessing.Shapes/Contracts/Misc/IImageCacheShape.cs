#region Namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Twainsoft.ImageProcessing.Common.Contracts.Vocabulary.Messages;

#endregion

namespace Twainsoft.ImageProcessing.Shapes.Contracts.Misc
{
    public interface IImageCacheShape
    {
        void In_CachedImage(ICachedImageMessage cachedImageMessage);

        event Action<ICachedImageMessage> Out_SendCachedImage;
    }
}