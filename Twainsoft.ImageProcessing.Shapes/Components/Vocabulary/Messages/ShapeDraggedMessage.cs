using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Twainsoft.ImageProcessing.Shapes.Contracts.Vocabulary.Messages;

namespace Twainsoft.ImageProcessing.Shapes.Components.Vocabulary.Messages
{
    public class ShapeDraggedMessage : IShapeDraggedMessage
    {
        public Point InputPinCenter { get; private set; }
        public Point OutputPinCenter { get; private set; }

        public ShapeDraggedMessage(Point inputPinCenter, Point outputPinCenter)
        {
            this.InputPinCenter = inputPinCenter;
            this.OutputPinCenter = outputPinCenter;
        }
    }
}