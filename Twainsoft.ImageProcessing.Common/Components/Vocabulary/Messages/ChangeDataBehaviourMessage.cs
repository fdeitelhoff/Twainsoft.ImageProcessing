#region Namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Twainsoft.ImageProcessing.Common.Contracts.Vocabulary.Messages;

#endregion

namespace Twainsoft.ImageProcessing.Common.Components.Vocabulary.Messages
{
    public class ChangeDataBehaviourMessage : IChangeDataBehaviourMessage
    {
        public bool CanProcotolOutputData { get; private set; }

        public bool CanProtocolDebugData { get; private set; }

        public ChangeDataBehaviourMessage(bool canProtocolOutputData, bool canProcotolDebugData)
        {
            this.CanProcotolOutputData = canProtocolOutputData;
            this.CanProtocolDebugData = canProcotolDebugData;
        }
    }
}