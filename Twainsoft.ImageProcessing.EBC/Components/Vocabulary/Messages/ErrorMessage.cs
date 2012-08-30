#region Namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Twainsoft.ImageProcessing.EBC.Contracts.Vocabulary.Messages;

#endregion

namespace Twainsoft.ImageProcessing.EBC.Components.Vocabulary.Messages
{
    public class ErrorMessage : IErrorMessage
    {
        public Exception Exception { get; private set; }

        public ErrorMessage(Exception exception)
        {
            this.Exception = exception;
        }
    }
}