#region Namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

#endregion

namespace Twainsoft.ImageProcessing.Shapes.Contracts.Vocabulary.Data
{
    public interface IShapeErrorData
    {
        string Message { get; }

        Exception InnerException { get; }
    }
}