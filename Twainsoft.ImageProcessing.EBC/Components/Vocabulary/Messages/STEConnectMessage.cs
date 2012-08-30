#region Namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Twainsoft.ImageProcessing.EBC.Contracts.Vocabulary.Messages;
using Twainsoft.ImageProcessing.Shapes.Contracts.Base;
using Twainsoft.ImageProcessing.EBC.Contracts.Base;

#endregion

namespace Twainsoft.ImageProcessing.EBC.Components.Vocabulary.Messages
{
    public class STEConnectMessage : ISTEConnectMessage
    {
        public IShapeBase Shape { get; private set; }

        public IEBCBase EBC { get; private set; }

        public STEConnectMessage(IShapeBase shape, IEBCBase ebc)
        {
            this.Shape = shape;
            this.EBC = ebc;
        }
    }
}