#region Namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Twainsoft.ImageProcessing.Shapes.Contracts.Vocabulary.Data;

#endregion

namespace Twainsoft.ImageProcessing.Shapes.Components.Vocabulary.Data
{
    public class ShapeErrorData : IShapeErrorData
    {
        public string Message { get; private set; }
        public Exception InnerException { get; private set; }

        public ShapeErrorData(string message, Exception innerException)
        {
            this.Message = message;
            this.InnerException = innerException;
        }
    }
}