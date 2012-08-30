#region Namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Twainsoft.ImageProcessing.Shapes.Contracts.Vocabulary.Messages;
using Twainsoft.ImageProcessing.Shapes.Contracts.Base;
using Twainsoft.ImageProcessing.Common.Components.Vocabulary.Messages;

#endregion

namespace Twainsoft.ImageProcessing.Shapes.Components.Vocabulary.Messages
{
    public class EBCPinClickedMessage : IEBCPinClickedMessage
    {
        public PinTypes PinType { get; private set; }
        public IShapeBase Shape { get; private set; }

        public EBCPinClickedMessage(PinTypes pinType, IShapeBase shapeBase)
        {
            this.PinType = pinType;
            this.Shape = shapeBase;
        }
    }
}