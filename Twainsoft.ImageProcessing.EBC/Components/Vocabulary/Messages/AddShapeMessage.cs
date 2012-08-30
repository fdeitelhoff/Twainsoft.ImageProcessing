#region Namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Twainsoft.ImageProcessing.EBC.Contracts.Vocabulary.Messages;
using Twainsoft.ImageProcessing.Shapes.Contracts.Base;
using Twainsoft.ImageProcessing.EBC.Contracts.Base;
using System.Drawing;

#endregion

namespace Twainsoft.ImageProcessing.EBC.Components.Vocabulary.Messages
{
    public class AddShapeMessage : IAddShapeMessage
    {
        public IShapeBase Shape { get; private set; }
        public IEBCBase EBC { get; private set; }
        public Point ShapeLocation { get; private set; }

        public AddShapeMessage(IShapeBase shape, IEBCBase ebc, Point shapeLocation)
        {
            this.Shape = shape;
            this.EBC = ebc;
            this.ShapeLocation = shapeLocation;
        }
    }
}