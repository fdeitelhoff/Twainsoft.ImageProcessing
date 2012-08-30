#region Namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Twainsoft.ImageProcessing.EBC.Contracts.Vocabulary.Messages;
using Twainsoft.ImageProcessing.Common.Contracts.Vocabulary.Data;
using Twainsoft.ImageProcessing.EBC.Contracts.Base;

#endregion

namespace Twainsoft.ImageProcessing.EBC.Components.Vocabulary.Messages
{
    public class EBCDebugMessage : IEBCDebugMessage
    {
        public IEBCBase EBC { get; private set; }
        public IDebugData DebugData { get; private set; }

        public EBCDebugMessage(IEBCBase ebc, IDebugData debugData)
        {
            this.EBC = ebc;
            this.DebugData = debugData;
        }
    }
}