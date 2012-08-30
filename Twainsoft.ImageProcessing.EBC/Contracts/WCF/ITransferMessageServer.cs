#region Namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Twainsoft.ImageProcessing.EBC.Contracts.Vocabulary.WCF;
using Twainsoft.ImageProcessing.EBC.Contracts.Vocabulary.Messages;

#endregion

namespace Twainsoft.ImageProcessing.EBC.Contracts.WCF
{
    public interface ITransferMessageServer : ITransferMessage
    {
        void StartServer();

        event Action<IEBCMessage> Out_MessageTransfered;
    }
}