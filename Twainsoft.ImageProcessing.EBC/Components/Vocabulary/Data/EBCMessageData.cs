#region Namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Twainsoft.ImageProcessing.EBC.Contracts.Vocabulary.Data;
using Twainsoft.ImageProcessing.Common.Components.Vocabulary.Data;
using System.Runtime.Serialization;

#endregion

namespace Twainsoft.ImageProcessing.EBC.Components.Vocabulary.Data
{
    [DataContract]
    public class EBCMessageData : IEBCMessageData
    {
        [DataMember]
        public Bitmap Image { get; private set; }
        [DataMember]
        public ImageTypes ImageType { get; set; }

        [DataMember]
        public DataResultTypes DataResultType { get; private set; }
        [DataMember]
        public object Data { get; private set; }

        public bool HasImage
        {
            get { return this.Image != null; }
        }

        public bool HasData
        {
            get { return this.Data != null; }
        }

        public EBCMessageData(DataResultTypes dataResultType, Bitmap image)
        {
            this.DataResultType = dataResultType;
            this.Image = new Bitmap(image);
            this.ImageType = ImageTypes.Default;
        }

        public EBCMessageData(DataResultTypes dataResultType, Bitmap image, object data)
            : this(dataResultType, image)
        {
            this.Data = data;
        }

        public EBCMessageData(IEBCMessageData ebcMessageData)
            : this(ebcMessageData.DataResultType, ebcMessageData.Image, ebcMessageData.Data)
        {
            this.ImageType = ebcMessageData.ImageType;
        }
    }
}