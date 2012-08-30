#region Namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Twainsoft.ImageProcessing.Common.Contracts.Vocabulary.Exceptions;

#endregion

namespace Twainsoft.ImageProcessing.Common.Components.Vocabulary.Exceptions
{
    public class WorkException : ApplicationException, IWorkException
    {
        public WorkException(Exception innerException)
            : this("There was an exception during the EBC work process!", innerException)
        { }

        public WorkException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}