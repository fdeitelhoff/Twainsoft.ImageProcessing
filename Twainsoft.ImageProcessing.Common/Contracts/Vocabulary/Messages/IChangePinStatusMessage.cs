#region Namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Twainsoft.ImageProcessing.Common.Components.Vocabulary.Messages;

#endregion

namespace Twainsoft.ImageProcessing.Common.Contracts.Vocabulary.Messages
{
    public interface IChangePinStatusMessage
    {
        PinTypes PinType { get; }

        bool Status { get; }
    }
}