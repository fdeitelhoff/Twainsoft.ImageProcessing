#region Namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Twainsoft.ImageProcessing.Common.Contracts.Vocabulary.Messages;
using Twainsoft.ImageProcessing.Common.Contracts.Vocabulary.Data;

#endregion

namespace Twainsoft.ImageProcessing.Common.Components.Vocabulary.Messages
{
    public class ThresholdMessage : IThresholdMessage
    {
        public List<IThresholdData> ThresholdData { get; private set; }

        public ThresholdMessage(List<IThresholdData> thresholdData)
        {
            this.ThresholdData = thresholdData;
        }
    }
}