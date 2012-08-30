#region Namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Twainsoft.ImageProcessing.EBC.Contracts.Vocabulary.Data;
using System.Runtime.Serialization;
using Twainsoft.ImageProcessing.EBC.Components.Vocabulary.Messages;

#endregion

namespace Twainsoft.ImageProcessing.EBC.Contracts.Vocabulary.Messages
{
    public interface IEBCMessage
    {
        IEBCMessageData EBCMessageData { get; set; }
    }
}