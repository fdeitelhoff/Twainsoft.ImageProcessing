#region Namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

#endregion

namespace Twainsoft.ImageProcessing.EBC.Components.Vocabulary.Exceptions
{
    public class CircularConnectionException : ApplicationException
    {
        public CircularConnectionException(string message)
            : base(message)
        { }
    }
}