#region Namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Twainsoft.ImageProcessing.Common.Contracts.Vocabulary.Data;

#endregion

namespace Twainsoft.ImageProcessing.Common.Components.Vocabulary.Data
{
    public class ThresholdData : IThresholdData
    {
        public int Min { get; private set; }
        public int Max { get; private set; }
        public int GrayValue { get; private set; }

        public ThresholdData(int min, int max, int grayValue)
        {
            this.Min = min;
            this.Max = max;
            this.GrayValue = grayValue;
        }
    }
}