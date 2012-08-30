#region Namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Twainsoft.ImageProcessing.Common.Contracts.Vocabulary.Messages;

#endregion

namespace Twainsoft.ImageProcessing.Common.Components.Vocabulary.Messages
{
    public class RepeatCountChangedMessage : IRepeatCountChangedMessage
    {
        public int RepeatCount { get; private set; }

        public RepeatCountChangedMessage(int repeatCount)
        {
            this.RepeatCount = repeatCount;
        }
    }
}