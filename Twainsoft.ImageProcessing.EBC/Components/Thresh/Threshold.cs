#region Namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Twainsoft.ImageProcessing.EBC.Contracts.Thresh;
using Twainsoft.ImageProcessing.EBC.Components.Base;
using Twainsoft.ImageProcessing.EBC.Contracts.Vocabulary.Messages;
using Twainsoft.ImageProcessing.Common.Contracts.Vocabulary.Messages;
using Twainsoft.ImageProcessing.Common.Contracts.Vocabulary.Data;
using Twainsoft.ImageProcessing.IPLab.Threshold;
using Twainsoft.ImageProcessing.EBC.Contracts.Vocabulary.Data;
using System.Drawing;
using Twainsoft.ImageProcessing.EBC.Components.Vocabulary.Data;
using Twainsoft.ImageProcessing.Common.Components.Vocabulary.Data;
using Twainsoft.ImageProcessing.EBC.Components.Vocabulary.Messages;

#endregion

namespace Twainsoft.ImageProcessing.EBC.Components.Thresh
{
    public class Threshold : EBCBase, IThreshold
    {
        private List<IThresholdData> ThresholdData { get; set; }
        private IEBCMessageData EBCMessageData { get; set; }

        public Threshold()
        {
            this.Name = "Schwellwert";
        }

        public override void MessageReceived(IEBCMessage ebcMessage)
        {
            this.EBCMessageData = ebcMessage.EBCMessageData;

            if (this.ThresholdData == null)
            {
                this.Out_SelectThresholds();
            }

            this.ApplyThresholds();
        }

        private void ApplyThresholds()
        {
            int[,] thresholds = new int[this.ThresholdData.Count, 3];

            for (int i = 0; i < this.ThresholdData.Count; i++)
            {
                thresholds[i, 0] = this.ThresholdData[i].Min;
                thresholds[i, 1] = this.ThresholdData[i].Max;
                thresholds[i, 2] = this.ThresholdData[i].GrayValue;
            }

            Bitmap resultingImage = Thresholds.ApplyThresholds(this.EBCMessageData.Image, thresholds);

            IEBCMessageData ebcMessageData = new EBCMessageData(DataResultTypes.Threshold,
                resultingImage, this.EBCMessageData.ImageType);

            // Send the debug data with the resulting image containing the ellipse.
            IDebugData debugData = new DebugData(ebcMessageData.DataResultType, resultingImage);
            debugData.AddSourceImage(this.EBCMessageData.Image);

            this.OnOut_ShapeDebugMessage(debugData);

            this.OnOut_SendResult(new EBCMessage(ebcMessageData));
        }

        public event Action Out_SelectThresholds;
        
        public void In_ThresholdsSelected(IThresholdMessage thresholdMessage)
        {
            this.ThresholdData = thresholdMessage.ThresholdData;
        }
    }
}