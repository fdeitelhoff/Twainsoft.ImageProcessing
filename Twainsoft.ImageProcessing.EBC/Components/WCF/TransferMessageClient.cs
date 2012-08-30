#region Namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using Twainsoft.ImageProcessing.EBC.Contracts.Misc;
using Twainsoft.ImageProcessing.EBC.Contracts.Vocabulary.Messages;
using Twainsoft.ImageProcessing.EBC.Contracts.Vocabulary.WCF;
using Twainsoft.ImageProcessing.EBC.Contracts.WCF;
using Twainsoft.ImageProcessing.EBC.Components.Vocabulary.Message;

#endregion

namespace Twainsoft.ImageProcessing.EBC.Components.WCF
{
    public class TransferMessageClient : ClientBase<ITransferMessage>, ITransferMessageClient
    {
        public TransferMessageClient() { }

        public void TransferMessage(TransferMessage ebcMessage)
        {
            base.Channel.TransferMessage(ebcMessage);
        }
    }
}