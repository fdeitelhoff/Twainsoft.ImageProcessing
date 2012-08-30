#region Namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Twainsoft.ImageProcessing.Shapes.Contracts.Base;

#endregion

namespace Twainsoft.ImageProcessing.Shapes.Contracts.Vocabulary.Messages
{
    public interface IPaintObjectsMessage
    {
        List<IShapeBase> Shapes { get; }
    }
}