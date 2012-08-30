#region Namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using Twainsoft.ImageProcessing.EBC.Components.WCF;
using Twainsoft.ImageProcessing.EBC.Components.Vocabulary.Message;

#endregion

namespace Twainsoft.ImageProcessing.EBC.Contracts.Vocabulary.WCF
{
    [ServiceContract()]
    public interface ITransferMessage
    {
        [OperationContract(IsOneWay = true)]
        void TransferMessage(TransferMessage transferMessage);
    }
}