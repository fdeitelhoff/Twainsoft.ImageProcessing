#region Namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Twainsoft.ImageProcessing.EBC.Components.Base;
using Twainsoft.ImageProcessing.EBC.Contracts.WCF;
using Twainsoft.ImageProcessing.EBC.Components.Vocabulary.Message;
using Twainsoft.ImageProcessing.EBC.Contracts.Vocabulary.Messages;
using Twainsoft.ImageProcessing.EBC.Components.WCF;
using Twainsoft.ImageProcessing.Common.Components.Vocabulary.Data;
using Twainsoft.ImageProcessing.Common.Contracts.Vocabulary.Data;
using Twainsoft.ImageProcessing.EBC.Contracts.Misc;

#endregion

namespace Twainsoft.ImageProcessing.EBC.Components.Misc
{
    public class SendImage : EBCBase, ISendImage
    {
        private ITransferMessageClient TransferMessageClient { get; set; }

        public SendImage()
        {
            this.Name = "Sender";

            this.TransferMessageClient = new TransferMessageClient();
        }

        public override void MessageReceived(IEBCMessage ebcMessage)
        {
            // Send the message over the communication channel.
            this.TransferMessageClient.TransferMessage(new TransferMessage(ebcMessage.EBCMessageData));

            // Send the debug data with the resulting image containing the ellipse.
            IDebugData debugData = new DebugData(ebcMessage.EBCMessageData.DataResultType, ebcMessage.EBCMessageData.Image);
            
            this.OnOut_ShapeDebugMessage(debugData);

            this.OnOut_SendResult(ebcMessage);
        }
    }
}