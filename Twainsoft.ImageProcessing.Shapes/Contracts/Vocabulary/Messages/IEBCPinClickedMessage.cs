#region Namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Twainsoft.ImageProcessing.Shapes.Components.Vocabulary.Messages;
using Twainsoft.ImageProcessing.Shapes.Contracts.Base;
using Twainsoft.ImageProcessing.Common.Components.Vocabulary.Messages;

#endregion

namespace Twainsoft.ImageProcessing.Shapes.Contracts.Vocabulary.Messages
{
    public interface IEBCPinClickedMessage
    {
        PinTypes PinType { get; }

        IShapeBase Shape { get; }
    }
}