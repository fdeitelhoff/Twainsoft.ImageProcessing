#region Namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Twainsoft.ImageProcessing.Shapes.Contracts.Vocabulary.Messages;
using Twainsoft.ImageProcessing.Shapes.Contracts.Base;

#endregion

namespace Twainsoft.ImageProcessing.Shapes.Components.Vocabulary.Messages
{
    public class PaintObjectsMessage : IPaintObjectsMessage
    {
        public List<IShapeBase> Shapes { get; private set; }

        public PaintObjectsMessage(List<IShapeBase> shapes)
        {
            this.Shapes = shapes;
        }
    }
}