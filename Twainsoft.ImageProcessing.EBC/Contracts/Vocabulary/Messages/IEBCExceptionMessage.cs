#region Namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Twainsoft.ImageProcessing.EBC.Contracts.Base;
using Twainsoft.ImageProcessing.Common.Contracts.Vocabulary.Exceptions;

#endregion

namespace Twainsoft.ImageProcessing.EBC.Contracts.Vocabulary.Messages
{
    public interface IEBCExceptionMessage
    {
        IEBCBase EBC { get; }

        IWorkException WorkException { get; }
    }
}