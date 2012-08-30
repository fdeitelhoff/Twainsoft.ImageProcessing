#region Namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Twainsoft.ImageProcessing.EBC.Components.Base;
using Twainsoft.ImageProcessing.EBC.Contracts.Contrast;
using Twainsoft.ImageProcessing.EBC.Contracts.Vocabulary.Messages;
using Twainsoft.ImageProcessing.EBC.Components.Histogram;
using Twainsoft.ImageProcessing.EBC.Components.LUT;
using Twainsoft.ImageProcessing.EBC.Contracts.Vocabulary.Data;
using Twainsoft.ImageProcessing.EBC.Components.Vocabulary.Data;
using Twainsoft.ImageProcessing.Common.Components.Vocabulary.Data;
using Twainsoft.ImageProcessing.Common.Contracts.Vocabulary.Data;
using Twainsoft.ImageProcessing.EBC.Components.Vocabulary.Messages;

#endregion

namespace Twainsoft.ImageProcessing.EBC.Components.Contrast
{
    public class IncreaseContrast : EBCBase, IIncreaseContrast
    {
        private GrayValueHistogram GrayValueHistogram { get; set; }
        private CumulativeHistogram CumulativeHistogram { get; set; }
        private LookUpTable LookUpTable { get; set; }
        private HistogramEqualiziation HistogramEqualiziation { get; set; }

        public IncreaseContrast()
        {
            this.Name = "Kontrast anheben";

            this.GrayValueHistogram = new GrayValueHistogram();
            this.CumulativeHistogram = new CumulativeHistogram();
            this.LookUpTable = new LookUpTable();
            this.HistogramEqualiziation = new HistogramEqualiziation();

            this.GrayValueHistogram.Out_SendMessage += (IEBCMessage ebcMessage) => this.CumulativeHistogram.In_ReceiveMessage(ebcMessage);
            this.CumulativeHistogram.Out_SendMessage += (IEBCMessage ebcMessage) => this.LookUpTable.In_ReceiveMessage(ebcMessage);
            this.LookUpTable.Out_SendMessage += (IEBCMessage ebcMessage) => this.HistogramEqualiziation.In_ReceiveMessage(ebcMessage);
            this.HistogramEqualiziation.Out_SendMessage += (IEBCMessage ebcMessage) => this.OperationFinished(ebcMessage);

            this.GrayValueHistogram.Out_EBCDebugMessage += (IEBCDebugMessage debugMessage)
                => this.OnOut_ShapeDebugMessage(debugMessage.DebugData);
            this.CumulativeHistogram.Out_EBCDebugMessage += (IEBCDebugMessage debugMessage)
                => this.OnOut_ShapeDebugMessage(debugMessage.DebugData);
            this.LookUpTable.Out_EBCDebugMessage += (IEBCDebugMessage debugMessage)
                => this.OnOut_ShapeDebugMessage(debugMessage.DebugData);
            this.HistogramEqualiziation.Out_EBCDebugMessage += (IEBCDebugMessage debugMessage)
                => this.OnOut_ShapeDebugMessage(debugMessage.DebugData);
        }

        public override void MessageReceived(IEBCMessage ebcMessage)
        {
            this.GrayValueHistogram.In_ReceiveMessage(ebcMessage);
        }

        private void OperationFinished(IEBCMessage ebcMessage)
        {
            IEBCMessageData ebcMessageData = new EBCMessageData(DataResultTypes.IncreaseContrast,
                ebcMessage.EBCMessageData.Image, ebcMessage.EBCMessageData.ImageType);

            IDebugData debugData = new DebugData(ebcMessageData.DataResultType, ebcMessage.EBCMessageData.Image);

            this.OnOut_ShapeDebugMessage(debugData);

            this.OnOut_SendResult(new EBCMessage(ebcMessageData));
        }
    }
}