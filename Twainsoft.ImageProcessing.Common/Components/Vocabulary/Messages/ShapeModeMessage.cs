#region Namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Twainsoft.ImageProcessing.Common.Contracts.Vocabulary.Messages;

#endregion

namespace Twainsoft.ImageProcessing.Common.Components.Vocabulary.Messages
{
    public class ShapeModeMessage : IShapeModeMessage
    {
        public ShapeModes ShapeMode { get; private set; }

        public ShapeModeMessage(ShapeModes shapeMode)
        {
            this.ShapeMode = shapeMode;
        }
    }
}