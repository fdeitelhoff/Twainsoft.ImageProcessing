using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Twainsoft.ImageProcessing.Shapes.Contracts.Vocabulary.Messages
{
    public interface IShapeDraggedMessage
    {
        Point InputPinCenter { get; }

        Point OutputPinCenter { get; }
    }
}