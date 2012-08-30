#region Namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Twainsoft.ImageProcessing.Common.Contracts.Vocabulary.Messages;

#endregion

namespace Twainsoft.ImageProcessing.Common.Components.Vocabulary.Messages
{
    public class ChangePinStatusMessage : IChangePinStatusMessage
    {
        public PinTypes PinType { get; private set; }

        public bool Status { get; private set; }

        public ChangePinStatusMessage(PinTypes pinType, bool status)
        {
            this.PinType = pinType;
            this.Status = status;
        }
    }
}