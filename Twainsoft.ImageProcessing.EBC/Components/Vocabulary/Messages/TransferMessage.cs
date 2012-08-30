#region Namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Twainsoft.ImageProcessing.EBC.Contracts.Vocabulary.Data;
using Twainsoft.ImageProcessing.EBC.Components.Vocabulary.Data;
using System.Runtime.Serialization;
using Twainsoft.ImageProcessing.Common.Components.Vocabulary.Data;

#endregion

namespace Twainsoft.ImageProcessing.EBC.Components.Vocabulary.Message
{
    [DataContract]
    [KnownType(typeof(EBCMessageData))]
    [KnownType(typeof(Int32[]))]
    [KnownType(typeof(ImageTypes))]
    public class TransferMessage
    {
        [DataMember]
        public IEBCMessageData EBCMessageData { get; set; }

        public TransferMessage(IEBCMessageData ebcMessageData)
        {
            this.EBCMessageData = ebcMessageData;
        }
    }
}