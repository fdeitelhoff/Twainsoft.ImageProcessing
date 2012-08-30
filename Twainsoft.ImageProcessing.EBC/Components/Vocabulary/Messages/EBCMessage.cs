#region Namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Twainsoft.ImageProcessing.EBC.Contracts.Vocabulary.Messages;
using System.Drawing;
using Twainsoft.ImageProcessing.EBC.Contracts.Vocabulary.Data;
using System.Runtime.Serialization;
using Twainsoft.ImageProcessing.EBC.Components.Vocabulary.Data;
using Twainsoft.ImageProcessing.Common.Components.Vocabulary.Data;

#endregion

namespace Twainsoft.ImageProcessing.EBC.Components.Vocabulary.Messages
{
    [DataContract]
    [KnownType(typeof(EBCMessageData))]
    public class EBCMessage : IEBCMessage
    {
        [DataMember]
        public IEBCMessageData EBCMessageData { get; set; }

        public EBCMessage(IEBCMessageData ebcMessageData)
        {
            this.EBCMessageData = ebcMessageData;
        }

        public EBCMessage(IEBCMessage ebcMessage, ImageTypes imageTypes)
        {
            this.EBCMessageData = ebcMessage.EBCMessageData;
            this.EBCMessageData.ImageType = imageTypes;
        }
    }
}