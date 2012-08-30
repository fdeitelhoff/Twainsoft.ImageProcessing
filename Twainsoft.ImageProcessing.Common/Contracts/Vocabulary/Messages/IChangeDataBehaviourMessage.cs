#region Namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

#endregion

namespace Twainsoft.ImageProcessing.Common.Contracts.Vocabulary.Messages
{
    public interface IChangeDataBehaviourMessage
    {
        bool CanProcotolOutputData { get; }

        bool CanProtocolDebugData { get; }
    }
}