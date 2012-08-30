#region Namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Twainsoft.ImageProcessing.EBC.Contracts.Vocabulary.Messages;
using Twainsoft.ImageProcessing.EBC.Contracts.Vocabulary.Data;

#endregion

namespace Twainsoft.ImageProcessing.EBC.Components.Vocabulary.Messages
{
    public class ExecutionFinishedMessage : IExecutionFinishedMessage
    {
        public IEBCExecutionTimeData EBCExecutionTime { get; private set; }

        public IEBCOutputData EBCOutputData { get; private set; }

        public ExecutionFinishedMessage(IEBCOutputData ebcOutputData)
            : this(null, ebcOutputData)
        { }

        public ExecutionFinishedMessage(IEBCExecutionTimeData ebcExecutionTime)
            : this(ebcExecutionTime, null)
        { }

        public ExecutionFinishedMessage(IEBCExecutionTimeData ebcExecutionTime, IEBCOutputData ebcOutputData)
        {
            this.EBCExecutionTime = ebcExecutionTime;
            this.EBCOutputData = ebcOutputData;
        }
    }
}