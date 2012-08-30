#region Namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Twainsoft.ImageProcessing.EBC.Contracts.Vocabulary.Messages;

#endregion

namespace Twainsoft.ImageProcessing.GUI.Contracts
{
    public interface IFrmToolboxEBCDebugData
    {
        void In_EBCDebugMessage(IEBCDebugMessage ebcDebugMessage);
    }
}