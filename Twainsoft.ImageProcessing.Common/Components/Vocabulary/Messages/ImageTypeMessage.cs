#region Namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Twainsoft.ImageProcessing.Common.Components.Vocabulary.Data;
using Twainsoft.ImageProcessing.Common.Contracts.Vocabulary.Messages;

#endregion

namespace Twainsoft.ImageProcessing.Common.Components.Vocabulary.Messages
{
    public class ImageTypeMessage : IImageTypeMessage
    {
        public ImageTypes ImageType { get; private set; }

        public ImageTypeMessage(ImageTypes imageType)
        {
            this.ImageType = imageType;
        }
    }
}