#region Namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Twainsoft.ImageProcessing.Common.Contracts.Vocabulary.Messages;
using System.Drawing;
using Twainsoft.ImageProcessing.Common.Contracts.Vocabulary.Data;

#endregion

namespace Twainsoft.ImageProcessing.Common.Components.Vocabulary.Data
{
    public class DebugData : IDebugData
    {
        public DataResultTypes DataResultType { get; private set; }

        public List<Bitmap> SourceImages { get; private set; }
        public Bitmap ResultingImage { get; private set; }

        public object Data { get; private set; }

        public bool HasSourceImages
        {
            get { return this.SourceImages.Count > 0; }
        }

        public bool HasResultingImage
        {
            get { return this.ResultingImage != null; }
        }

        public bool HasData
        {
            get { return this.Data != null; }
        }

        public DebugData(DataResultTypes dataResultType, Bitmap resultingImage)
        {
            this.DataResultType = dataResultType;
            this.ResultingImage = new Bitmap(resultingImage);

            this.SourceImages = new List<Bitmap>();
        }

        public DebugData(DataResultTypes dataResultType, Bitmap resultingImage, object data)
            : this(dataResultType, resultingImage)
        {
            this.Data = data;
        }

        public void AddSourceImage(Bitmap sourceImage)
        {
            this.SourceImages.Add(new Bitmap(sourceImage));
        }
    }
}