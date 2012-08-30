#region Namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Twainsoft.ImageProcessing.EBC.Contracts.Misc;
using Twainsoft.ImageProcessing.EBC.Components.Base;
using Twainsoft.ImageProcessing.EBC.Contracts.Vocabulary.Messages;
using Twainsoft.ImageProcessing.EBC.Contracts.Vocabulary.Data;
using Twainsoft.ImageProcessing.EBC.Components.Vocabulary.Data;
using Twainsoft.ImageProcessing.Common.Components.Vocabulary.Data;
using Twainsoft.ImageProcessing.Common.Contracts.Vocabulary.Data;
using Twainsoft.ImageProcessing.EBC.Components.Vocabulary.Messages;
using Twainsoft.ImageProcessing.Common.Contracts.Vocabulary.Messages;

#endregion

namespace Twainsoft.ImageProcessing.EBC.Components.Misc
{
    public class ImageRepeater : EBCBase, IImageRepeater
    {
        private int RepeatCount { get; set; }

        public ImageRepeater()
        {
            this.Name = "Bild-Repeater";

            this.RepeatCount = 1;
        }

        public override void MessageReceived(IEBCMessage ebcMessage)
        {
            for (int i = 0; i < this.RepeatCount; i++)
            {
                // The real data. Both images are equal!
                IEBCMessageData ebcMessageData = new EBCMessageData(DataResultTypes.ImageRepeater,
                    ebcMessage.EBCMessageData.Image, ebcMessage.EBCMessageData.ImageType);

                // Send the debug data with the resulting image containing the ellipse.
                IDebugData debugData = new DebugData(ebcMessageData.DataResultType, ebcMessage.EBCMessageData.Image);
                debugData.AddSourceImage(ebcMessage.EBCMessageData.Image);

                this.OnOut_ShapeDebugMessage(debugData);

                this.OnOut_SendResult(new EBCMessage(ebcMessageData));
            }
        }

        public void In_RepeatCountChanged(IRepeatCountChangedMessage repeatCountChangedMessage)
        {
            this.RepeatCount = repeatCountChangedMessage.RepeatCount;
        }
    }
}