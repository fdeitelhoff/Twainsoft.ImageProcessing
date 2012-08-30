#region Namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Twainsoft.ImageProcessing.EBC.Components.Base;
using Twainsoft.ImageProcessing.EBC.Contracts.Examples;
using Twainsoft.ImageProcessing.EBC.Contracts.Vocabulary.Messages;
using Twainsoft.ImageProcessing.EBC.Components.Thresh;
using Twainsoft.ImageProcessing.Common.Components.Vocabulary.Messages;
using Twainsoft.ImageProcessing.Common.Components.Vocabulary.Data;
using Twainsoft.ImageProcessing.EBC.Components.FloodFilling;
using Twainsoft.ImageProcessing.EBC.Components.Ranking;
using Twainsoft.ImageProcessing.EBC.Components.Operations;
using Twainsoft.ImageProcessing.Common.Contracts.Vocabulary.Data;
using Twainsoft.ImageProcessing.EBC.Components.Vocabulary.Messages;
using Twainsoft.ImageProcessing.EBC.Contracts.Vocabulary.Data;
using Twainsoft.ImageProcessing.EBC.Components.Vocabulary.Data;

#endregion

namespace Twainsoft.ImageProcessing.EBC.Components.Examples
{
    public class BottleCheck : EBCBase, IBottleCheck
    {
        private Threshold Threshold { get; set; }

        private ROICenter RegionOfInterestTop { get; set; }
        private FloodFill FloodFill { get; set; }

        private Dilatation Dilatation { get; set; }
        private ROICenter RegionOfInterestBottom { get; set; }

        private Subtraction Subtraction { get; set; }

        public BottleCheck()
        {
            this.Name = "Flaschen-Prüfung";

            this.Threshold = new Threshold();
            this.RegionOfInterestTop = new ROICenter();
            this.FloodFill = new FloodFill();
            this.Dilatation = new Dilatation();
            this.RegionOfInterestBottom = new ROICenter();
            this.Subtraction = new Subtraction();

            this.Threshold.Out_SendMessage += (IEBCMessage ebcMessage) => this.RegionOfInterestTop.In_ReceiveMessage(ebcMessage);
            this.Threshold.Out_SendMessage += (IEBCMessage ebcMessage) => this.Dilatation.In_ReceiveMessage(ebcMessage);

            this.RegionOfInterestTop.Out_SendMessage += (IEBCMessage ebcMessage) => this.FloodFill.In_ReceiveMessage(ebcMessage);
            this.Dilatation.Out_SendMessage += (IEBCMessage ebcMessage) => this.RegionOfInterestBottom.In_ReceiveMessage(ebcMessage);

            this.FloodFill.Out_SendMessage += (IEBCMessage ebcMessage) => this.Subtraction.In_ReceiveMessage(new EBCMessage(ebcMessage, ImageTypes.Subtrahend));
            this.RegionOfInterestBottom.Out_SendMessage += (IEBCMessage ebcMessage) => this.Subtraction.In_ReceiveMessage(new EBCMessage(ebcMessage, ImageTypes.Minuend));

            this.Subtraction.Out_SendMessage += (IEBCMessage ebcMessage) => this.BotteExtractionComplete(ebcMessage);                

            // Add Thresholds.
            List<IThresholdData> thresholdData = new List<IThresholdData>();
            thresholdData.Add(new ThresholdData(0, 200, 255));
            thresholdData.Add(new ThresholdData(201, 255, 0));
            this.Threshold.In_ThresholdsSelected(new ThresholdMessage(thresholdData));
        }

        void BotteExtractionComplete(IEBCMessage ebcMessage)
        {
            IEBCMessageData ebcMessageData = new EBCMessageData(DataResultTypes.BottleCheck,
                ebcMessage.EBCMessageData.Image, ebcMessage.EBCMessageData.ImageType);

            IDebugData debugData = new DebugData(ebcMessageData.DataResultType, ebcMessage.EBCMessageData.Image);

            this.OnOut_ShapeDebugMessage(debugData);

            this.OnOut_SendResult(new EBCMessage(ebcMessageData));
        }

        public override void MessageReceived(IEBCMessage ebcMessage)
        {
            this.Threshold.In_ReceiveMessage(ebcMessage);
        }
    }
}