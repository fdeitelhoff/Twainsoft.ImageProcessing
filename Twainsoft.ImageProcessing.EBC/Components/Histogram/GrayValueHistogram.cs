#region Namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Twainsoft.ImageProcessing.EBC.Contracts.Histogram;
using Twainsoft.ImageProcessing.EBC.Contracts.Vocabulary.Messages;
using Twainsoft.ImageProcessing.EBC.Components.Base;
using Twainsoft.ImageProcessing.EBC.Contracts.Vocabulary.Data;
using Twainsoft.ImageProcessing.IPLab.Histogram;
using Twainsoft.ImageProcessing.EBC.Components.Vocabulary.Data;
using Twainsoft.ImageProcessing.EBC.Components.Vocabulary.Messages;
using System.Drawing;
using Twainsoft.ImageProcessing.Common.Components.Vocabulary.Exceptions;
using Twainsoft.ImageProcessing.Common.Components.Vocabulary.Data;
using Twainsoft.ImageProcessing.Common.Contracts.Vocabulary.Data;

#endregion

namespace Twainsoft.ImageProcessing.EBC.Components.Histogram
{
    public class GrayValueHistogram : EBCBase, IGrayValueHistogram
    {
        public GrayValueHistogram()
        {
            this.Name = "Grauwert- Histogramm";
        }

        public override void MessageReceived(IEBCMessage ebcMessage)
        {
            IEBCMessageData lastEBCMessageData = ebcMessage.EBCMessageData;

            int[] grayValueHistogram = Histograms.CreateGrayValueHistogram(lastEBCMessageData.Image);

            IEBCMessageData ebcMessageData = new EBCMessageData(DataResultTypes.GrayValueHistogram,
                lastEBCMessageData.Image, grayValueHistogram);

            IDebugData debugData = new DebugData(ebcMessageData.DataResultType, lastEBCMessageData.Image, grayValueHistogram);
            debugData.AddSourceImage(lastEBCMessageData.Image);

            this.OnOut_ShapeDebugMessage(debugData);

            this.OnOut_SendResult(new EBCMessage(ebcMessageData));
        }
    }
}