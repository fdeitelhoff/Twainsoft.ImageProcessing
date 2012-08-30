#region Namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Twainsoft.ImageProcessing.Common.Contracts.Vocabulary.Messages;
using Twainsoft.ImageProcessing.Common.Contracts.Vocabulary.Exceptions;

#endregion

namespace Twainsoft.ImageProcessing.Common.Components.Vocabulary.Messages
{
    public class ExceptionInfoMessage : IExceptionInfoMessage
    {
        public IWorkException WorkException { get; private set; }

        public ExceptionInfoMessage(IWorkException workException)
        {
            this.WorkException = workException;
        }
    }
}