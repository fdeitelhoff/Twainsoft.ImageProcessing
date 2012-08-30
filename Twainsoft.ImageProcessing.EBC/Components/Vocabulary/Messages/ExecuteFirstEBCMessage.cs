#region Namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Twainsoft.ImageProcessing.EBC.Contracts.Vocabulary.Messages;
using Twainsoft.ImageProcessing.EBC.Contracts.Base;

#endregion

namespace Twainsoft.ImageProcessing.EBC.Components.Vocabulary.Messages
{
    public class ExecuteFirstEBCMessage : IExecuteFirstEBCMessage
    {
        public IEBCBase EBC { get; private set; }

        public ExecuteFirstEBCMessage(IEBCBase firstEBC)
        {
            this.EBC = firstEBC;
        }
    }
}