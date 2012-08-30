#region Namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

#endregion

namespace Twainsoft.ImageProcessing.EBC.Components.Vocabulary.Exceptions
{
    public class ShapeConnectionException : ApplicationException
    {
        public ShapeConnectionException(string message)
            : base(message)
        { }
    }
}