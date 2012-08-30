#region Namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Twainsoft.ImageProcessing.EBC.Contracts.Operations;
using Twainsoft.ImageProcessing.EBC.Components.Base;
using Twainsoft.ImageProcessing.EBC.Contracts.Vocabulary.Messages;
using System.Drawing;
using Twainsoft.ImageProcessing.Common.Components.Vocabulary.Data;
using Twainsoft.ImageProcessing.IPLab.Arithmetic;
using Twainsoft.ImageProcessing.EBC.Components.Vocabulary.Messages;
using Twainsoft.ImageProcessing.EBC.Contracts.Vocabulary.Data;
using Twainsoft.ImageProcessing.EBC.Components.Vocabulary.Data;
using Twainsoft.ImageProcessing.Common.Contracts.Vocabulary.Data;

#endregion

namespace Twainsoft.ImageProcessing.EBC.Components.Operations
{
    public class Subtraction : EBCBase, ISubtraction
    {
        private Bitmap SubtrahendImage { get; set; }
        private Bitmap MinuendImage { get; set; }

        public Subtraction()
        {
            this.Name = "Subtraktion";
        }

        public override void MessageReceived(IEBCMessage ebcMessage)
        {
            if (ebcMessage.EBCMessageData.ImageType == ImageTypes.Subtrahend)
            {
                this.SubtrahendImage = ebcMessage.EBCMessageData.Image;
            }
            else if (ebcMessage.EBCMessageData.ImageType == ImageTypes.Minuend)
            {
                this.MinuendImage = ebcMessage.EBCMessageData.Image;
            }

            this.SubstractImages();
        }

        private void SubstractImages()
        {
            if (this.SubtrahendImage != null && this.MinuendImage != null)
            {
                Bitmap resultingImage = Arithmetics.SubtractImages(this.MinuendImage, this.SubtrahendImage);

                IEBCMessageData ebcMessageData = new EBCMessageData(DataResultTypes.Subtraction, resultingImage);

                IDebugData debugData = new DebugData(ebcMessageData.DataResultType, resultingImage);
                debugData.AddSourceImage(this.MinuendImage);
                debugData.AddSourceImage(this.SubtrahendImage);

                this.OnOut_ShapeDebugMessage(debugData);

                this.OnOut_SendResult(new EBCMessage(ebcMessageData));
            }
        }
    }
}