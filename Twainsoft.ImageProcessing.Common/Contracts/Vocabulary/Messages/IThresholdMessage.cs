#region Namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Twainsoft.ImageProcessing.Common.Contracts.Vocabulary.Data;

#endregion

namespace Twainsoft.ImageProcessing.Common.Contracts.Vocabulary.Messages
{
    public interface IThresholdMessage
    {
        List<IThresholdData> ThresholdData { get; }
    }
}