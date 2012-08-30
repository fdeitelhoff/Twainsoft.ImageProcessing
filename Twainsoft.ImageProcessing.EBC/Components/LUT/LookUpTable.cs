#region Namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Twainsoft.ImageProcessing.EBC.Contracts.LUT;
using Twainsoft.ImageProcessing.EBC.Components.Base;
using Twainsoft.ImageProcessing.EBC.Contracts.Vocabulary.Messages;
using Twainsoft.ImageProcessing.EBC.Contracts.Vocabulary.Data;
using Twainsoft.ImageProcessing.IPLab.LUT;
using Twainsoft.ImageProcessing.EBC.Components.Vocabulary.Data;
using Twainsoft.ImageProcessing.EBC.Components.Vocabulary.Messages;
using System.Drawing;
using Twainsoft.ImageProcessing.Common.Components.Vocabulary.Exceptions;
using Twainsoft.ImageProcessing.Common.Components.Vocabulary.Data;
using Twainsoft.ImageProcessing.Common.Contracts.Vocabulary.Data;

#endregion

namespace Twainsoft.ImageProcessing.EBC.Components.LUT
{
    public class LookUpTable : EBCBase, ILookUpTable
    {
        public LookUpTable()
        {
            this.Name = "Look-Up-Table";
        }

        public override void MessageReceived(IEBCMessage ebcMessage)
        {
            IEBCMessageData lastEBCMessageData = ebcMessage.EBCMessageData;

            int[] cumulativeHistogram = lastEBCMessageData.Data as int[];
            int[] lookUpTable = LookUpTables.CreateLookUpTable(cumulativeHistogram);

            IEBCMessageData ebcMessageData = new EBCMessageData(DataResultTypes.LookUpTable,
                lastEBCMessageData.Image, lookUpTable);

            IDebugData debugData = new DebugData(ebcMessageData.DataResultType, lastEBCMessageData.Image, lookUpTable);

            this.OnOut_ShapeDebugMessage(debugData);

            this.OnOut_SendResult(new EBCMessage(ebcMessageData));
        }
    }
}