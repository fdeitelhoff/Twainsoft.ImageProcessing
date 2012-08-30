#region Namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

#endregion

namespace Twainsoft.ImageProcessing.Shapes.Contracts.Vocabulary.Messages
{
    public interface IEllipseScanCoordinatesMessage
    {
        Point EllipseCenter { get; }
        int EllipseWidth { get; }
        int EllipseHeight { get; }
    }
}