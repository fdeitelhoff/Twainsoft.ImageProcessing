#region Namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

#endregion

namespace Twainsoft.ImageProcessing.Common.Contracts.Vocabulary.Exceptions
{
    public interface IWorkException
    {
        string Message { get; }

        Exception InnerException { get; }
    }
}