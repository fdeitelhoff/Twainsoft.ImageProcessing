#region Namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Twainsoft.ImageProcessing.EBC.Contracts.Vocabulary.Messages;
using Twainsoft.ImageProcessing.EBC.Contracts.Base;
using Twainsoft.ImageProcessing.Common.Contracts.Vocabulary.Exceptions;

#endregion

namespace Twainsoft.ImageProcessing.EBC.Components.Vocabulary.Messages
{
    public class EBCExceptionMessage : IEBCExceptionMessage
    {
        public IEBCBase EBC { get; private set; }
        public IWorkException WorkException { get; set; }

        public EBCExceptionMessage(IEBCBase ebcBase, IWorkException ebcWorkException)
        {
            this.EBC = ebcBase;
            this.WorkException = ebcWorkException;
        }
    }
}