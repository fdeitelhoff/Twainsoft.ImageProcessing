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
    public class EBCOutputData : IEBCOutputData
    {
        public IEBCBase EBC { get; private set; }

        public IEBCMessageData EBCMessageData { get; private set; }

        public EBCOutputDataTypes EBCOutputDataType { get; private set; }

        public EBCOutputData(IEBCBase ebcBase, IEBCMessageData ebcMessageData, EBCOutputDataTypes ebcOutputDataType)
        {
            this.EBC = ebcBase;
            this.EBCMessageData = ebcMessageData;
            this.EBCOutputDataType = ebcOutputDataType;
        }
    }
}