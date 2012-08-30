#region Namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Twainsoft.ImageProcessing.Shapes.Contracts.Base;

#endregion

namespace Twainsoft.ImageProcessing.Shapes.Contracts.Connection
{
    public interface IConnectionShape
    {
        void SetInputShape(IShapeBase inputShape);

        void SetOutputShape(IShapeBase outputShape);
    }
}