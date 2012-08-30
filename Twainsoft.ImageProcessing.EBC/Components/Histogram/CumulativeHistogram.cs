#region Namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Twainsoft.ImageProcessing.EBC.Contracts.Histogram;
using Twainsoft.ImageProcessing.EBC.Components.Base;
using Twainsoft.ImageProcessing.EBC.Contracts.Vocabulary.Messages;
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
    public class CumulativeHistogram : EBCBase, ICumulativeHistogram
    {
        public CumulativeHistogram()
        {
            this.Name = "Kum. Histogramm";
        }

        public override void MessageReceived(IEBCMessage ebcMessage)
        {
            IEBCMessageData lastEBCMessageData = ebcMessage.EBCMessageData;

            int[] grayValueHistogram = lastEBCMessageData.Data as int[];
            int[] cumulativeHistogram = Histograms.CreateCumulativeHistogram(grayValueHistogram);

            IEBCMessageData ebcMessageData = new EBCMessageData(DataResultTypes.CumulativeHistogram,
                lastEBCMessageData.Image, cumulativeHistogram);

            IDebugData debugData = new DebugData(ebcMessageData.DataResultType, lastEBCMessageData.Image, cumulativeHistogram);

            this.OnOut_ShapeDebugMessage(debugData);

            this.OnOut_SendResult(new EBCMessage(ebcMessageData));
        }
    }
}