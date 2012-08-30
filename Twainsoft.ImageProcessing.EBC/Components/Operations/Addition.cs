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
using Twainsoft.ImageProcessing.EBC.Contracts.Vocabulary.Data;
using Twainsoft.ImageProcessing.EBC.Components.Vocabulary.Data;
using Twainsoft.ImageProcessing.Common.Contracts.Vocabulary.Data;
using Twainsoft.ImageProcessing.EBC.Components.Vocabulary.Messages;

#endregion

namespace Twainsoft.ImageProcessing.EBC.Components.Operations
{
    public class Addition : EBCBase, IAddition
    {
        private Bitmap FirstSummand { get; set; }
        private Bitmap SecondSummand { get; set; }

        public Addition()
        {
            this.Name = "Addition";
        }

        public override void MessageReceived(IEBCMessage ebcMessage)
        {
            if (ebcMessage.EBCMessageData.ImageType == ImageTypes.FirstSummand)
            {
                this.FirstSummand = ebcMessage.EBCMessageData.Image;
            }
            else if (ebcMessage.EBCMessageData.ImageType == ImageTypes.SecondSummand)
            {
                this.SecondSummand = ebcMessage.EBCMessageData.Image;
            }

            this.AddImages();
        }

        private void AddImages()
        {
            if (this.FirstSummand != null && this.SecondSummand != null)
            {
                Bitmap resultingImage = Arithmetics.SumImages(this.FirstSummand, this.SecondSummand);

                IEBCMessageData ebcMessageData = new EBCMessageData(DataResultTypes.Addition, resultingImage);

                IDebugData debugData = new DebugData(ebcMessageData.DataResultType, resultingImage);
                debugData.AddSourceImage(this.FirstSummand);
                debugData.AddSourceImage(this.SecondSummand);

                this.OnOut_ShapeDebugMessage(debugData);

                this.OnOut_SendResult(new EBCMessage(ebcMessageData));
            }
        }
    }
}