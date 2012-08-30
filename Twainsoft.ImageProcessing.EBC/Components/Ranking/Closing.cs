#region Namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Twainsoft.ImageProcessing.EBC.Contracts.Ranking;
using Twainsoft.ImageProcessing.EBC.Components.Base;
using Twainsoft.ImageProcessing.EBC.Contracts.Vocabulary.Messages;
using Twainsoft.ImageProcessing.Common.Components.Vocabulary.Data;
using Twainsoft.ImageProcessing.EBC.Contracts.Vocabulary.Data;
using Twainsoft.ImageProcessing.EBC.Components.Vocabulary.Data;
using Twainsoft.ImageProcessing.Common.Contracts.Vocabulary.Data;
using Twainsoft.ImageProcessing.EBC.Components.Vocabulary.Messages;

#endregion

namespace Twainsoft.ImageProcessing.EBC.Components.Ranking
{
    public class Closing : EBCBase, IClosing
    {
        private Erodation Erodation { get; set; }
        private Dilatation Dilatation { get; set; }

        public Closing()
        {
            this.Name = "Closing";

            this.Erodation = new Erodation();
            this.Dilatation = new Dilatation();

            // Normal message flow.
            this.Dilatation.Out_SendMessage += (IEBCMessage message) => this.Erodation.In_ReceiveMessage(message);
            this.Erodation.Out_SendMessage += (IEBCMessage message) => this.OpeningFinished(message);

            // Deubg messages.
            this.Erodation.Out_EBCDebugMessage += (IEBCDebugMessage debugMessage)
                => this.OnOut_ShapeDebugMessage(debugMessage.DebugData);
            this.Dilatation.Out_EBCDebugMessage += (IEBCDebugMessage debugMessage)
                => this.OnOut_ShapeDebugMessage(debugMessage.DebugData);
        }

        public override void MessageReceived(IEBCMessage ebcMessage)
        {
            this.Dilatation.In_ReceiveMessage(ebcMessage);
        }

        private void OpeningFinished(IEBCMessage ebcMessage)
        {
            IEBCMessageData ebcMessageData = new EBCMessageData(DataResultTypes.Closing,
                ebcMessage.EBCMessageData.Image, ebcMessage.EBCMessageData.ImageType);

            IDebugData debugData = new DebugData(ebcMessageData.DataResultType, ebcMessage.EBCMessageData.Image);

            this.OnOut_ShapeDebugMessage(debugData);

            this.OnOut_SendResult(new EBCMessage(ebcMessageData));
        }
    }
}