#region Namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Twainsoft.ImageProcessing.EBC.Contracts.Vocabulary.Data;

#endregion

namespace Twainsoft.ImageProcessing.GUI.Contracts
{
    public interface IFrmToolboxEBCData
    {
        void In_OutputData(IEBCOutputData ebcOutputData);
    }
}