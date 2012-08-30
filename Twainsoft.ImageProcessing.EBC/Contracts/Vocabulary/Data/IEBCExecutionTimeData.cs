#region Namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Twainsoft.ImageProcessing.EBC.Contracts.Base;

#endregion

namespace Twainsoft.ImageProcessing.EBC.Contracts.Vocabulary.Data
{
    public interface IEBCExecutionTimeData
    {
        TimeSpan EndTime { get; }

        long UsedMilliseconds { get; }

        IEBCBase EBC { get; }
    }
}