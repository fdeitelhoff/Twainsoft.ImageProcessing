#region Namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Twainsoft.ImageProcessing.Shapes.Contracts.Base;
using Twainsoft.ImageProcessing.EBC.Contracts.Base;
using System.Drawing;

#endregion

namespace Twainsoft.ImageProcessing.EBC.Contracts.Vocabulary.Messages
{
    public interface IAddShapeMessage
    {
        IShapeBase Shape { get; }

        IEBCBase EBC { get; }

        Point ShapeLocation { get; }
    }
}