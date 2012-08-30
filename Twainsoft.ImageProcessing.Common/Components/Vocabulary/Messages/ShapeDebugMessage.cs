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
    public class ShapeDebugMessage : IShapeDebugMessage
    {
        public string EBCName { get; private set; }
        public IDebugData DebugData { get; private set; }

        public ShapeDebugMessage(string ebcName, IDebugData debugData)
        {
            this.EBCName = ebcName;
            this.DebugData = debugData;
        }
    }
}