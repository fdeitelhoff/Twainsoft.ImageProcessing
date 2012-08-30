#region Namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Twainsoft.ImageProcessing.Common.Contracts.Vocabulary.Messages;

#endregion

namespace Twainsoft.ImageProcessing.Common.Components.Vocabulary.Messages
{
    public class ExecutionTimeMessage : IExecutionTimeMessage
    {
        public long UsedMilliseconds { get; private set; }

        public ExecutionTimeMessage(long usedMilliseconds)
        {
            this.UsedMilliseconds = usedMilliseconds;
        }
    }
}