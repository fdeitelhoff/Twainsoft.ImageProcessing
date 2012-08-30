#region Namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Twainsoft.ImageProcessing.EBC.Contracts.Base;

#endregion

namespace Twainsoft.ImageProcessing.EBC.Contracts.Vocabulary.Messages
{
    public interface IConnectEBCMessage
    {
        IEBCBase OutputEBC { get; }

        IEBCBase InputEBC { get; }
    }
}