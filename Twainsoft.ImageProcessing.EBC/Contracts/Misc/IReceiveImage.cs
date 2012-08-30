#region Namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Twainsoft.ImageProcessing.EBC.Contracts.Vocabulary.Messages;

#endregion

namespace Twainsoft.ImageProcessing.EBC.Contracts.Misc
{
    public interface IReceiveImage
    {
        void In_StartService();

        void In_MessageTransfered(IEBCMessage ebcMessage);

        event Action Out_ServiceStarted;
    }
}