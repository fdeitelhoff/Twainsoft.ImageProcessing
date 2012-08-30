#region Namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Twainsoft.ImageProcessing.EBC.Contracts.Vocabulary.Data;
using Twainsoft.ImageProcessing.EBC.Contracts.Base;

#endregion

namespace Twainsoft.ImageProcessing.EBC.Components.Vocabulary.Data
{
    public class EBCExecutionTimeData : IEBCExecutionTimeData
    {
        public TimeSpan EndTime { get; private set; }

        public long UsedMilliseconds { get; private set; }

        public IEBCBase EBC { get; private set; }

        public EBCExecutionTimeData(TimeSpan endTime, long usedMilliseconds, IEBCBase ebcBase)
        {
            this.EndTime = endTime;
            this.UsedMilliseconds = usedMilliseconds;
            this.EBC = ebcBase;
        }
    }
}