#region Namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

#endregion

namespace Twainsoft.ImageProcessing.Common.Contracts.Vocabulary.Data
{
    public interface IThresholdData
    {
        int Min { get; }

        int Max { get; }

        int GrayValue { get; }
    }
}