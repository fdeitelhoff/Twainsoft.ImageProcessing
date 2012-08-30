#region Namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Twainsoft.ImageProcessing.Shapes.Contracts.Vocabulary.Messages;
using System.Drawing;

#endregion

namespace Twainsoft.ImageProcessing.Shapes.Components.Vocabulary.Messages
{
    public class EllipseScanCoordinatesMessage : IEllipseScanCoordinatesMessage
    {
        public Point EllipseCenter { get; private set; }
        public int EllipseWidth { get; private set; }
        public int EllipseHeight { get; private set; }

        public EllipseScanCoordinatesMessage(Point ellipseCenter, int ellipseWidth, int ellipseHeight)
        {
            this.EllipseCenter = ellipseCenter;
            this.EllipseWidth = ellipseWidth;
            this.EllipseHeight = ellipseHeight;
        }
    }
}