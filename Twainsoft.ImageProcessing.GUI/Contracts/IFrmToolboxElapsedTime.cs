#region Namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Twainsoft.ImageProcessing.EBC.Contracts.Vocabulary.Data;

#endregion

namespace Twainsoft.ImageProcessing.GUI.Contracts
{
    public interface IFrmToolboxElapsedTime
    {
        void In_ElapsedTime(IEBCExecutionTimeData ebcExecutionTimeData);
    }
}