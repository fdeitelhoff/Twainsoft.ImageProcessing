#region Namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Twainsoft.ImageProcessing.Common.Contracts.Vocabulary.Messages;

#endregion

namespace Twainsoft.ImageProcessing.Shapes.Contracts.Threshold
{
    public interface IThresholdShape
    {
        void In_SelectThresholds();

        event Action<IThresholdMessage> Out_ThresholdsSelected;
    }
}