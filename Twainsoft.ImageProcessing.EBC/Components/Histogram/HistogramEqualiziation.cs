#region Namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Twainsoft.ImageProcessing.EBC.Contracts.Histogram;
using Twainsoft.ImageProcessing.EBC.Components.Base;
using Twainsoft.ImageProcessing.EBC.Contracts.Vocabulary.Messages;
using Twainsoft.ImageProcessing.EBC.Contracts.Vocabulary.Data;
using System.Drawing;
using Twainsoft.ImageProcessing.IPLab.Histogram;
using Twainsoft.ImageProcessing.EBC.Components.Vocabulary.Data;
using Twainsoft.ImageProcessing.EBC.Components.Vocabulary.Messages;
using Twainsoft.ImageProcessing.Common.Components.Vocabulary.Exceptions;
using Twainsoft.ImageProcessing.Common.Components.Vocabulary.Data;
using Twainsoft.ImageProcessing.Common.Contracts.Vocabulary.Data;

#endregion

namespace Twainsoft.ImageProcessing.EBC.Components.Histogram
{
    public class HistogramEqualiziation : EBCBase, IHistogramEqualiziation
    {
        public HistogramEqualiziation()
        {
            this.Name = "Histogramm ebnen";
        }

        public override void MessageReceived(IEBCMessage ebcMessage)
        {
            IEBCMessageData lastEBCMessageData = ebcMessage.EBCMessageData;

            int[] lookUpTable = lastEBCMessageData.Data as int[];
            Bitmap resultingImage = Histograms.CreateHistogramEqualizedImage(lookUpTable, lastEBCMessageData.Image);

            IEBCMessageData ebcMessageData = new EBCMessageData(DataResultTypes.HistogramEqualiziation, resultingImage, lastEBCMessageData.ImageType);

            IDebugData debugData = new DebugData(ebcMessageData.DataResultType, lastEBCMessageData.Image);

            this.OnOut_ShapeDebugMessage(debugData);

            this.OnOut_SendResult(new EBCMessage(ebcMessageData));
        }
    }
}