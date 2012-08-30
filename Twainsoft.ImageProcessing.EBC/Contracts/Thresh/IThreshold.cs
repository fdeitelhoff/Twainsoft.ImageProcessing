#region Namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Twainsoft.ImageProcessing.Common.Contracts.Vocabulary.Messages;

#endregion

namespace Twainsoft.ImageProcessing.EBC.Contracts.Thresh
{
    public interface IThreshold
    {
        event Action Out_SelectThresholds;
        
        void In_ThresholdsSelected(IThresholdMessage thresholdMessage);
    }
}