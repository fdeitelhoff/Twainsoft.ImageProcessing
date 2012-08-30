#region Namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Twainsoft.ImageProcessing.EBC.Contracts.Operations;
using Twainsoft.ImageProcessing.EBC.Components.Base;
using Twainsoft.ImageProcessing.EBC.Contracts.Vocabulary.Messages;
using System.Drawing;
using Twainsoft.ImageProcessing.EBC.Contracts.Vocabulary.Data;
using Twainsoft.ImageProcessing.EBC.Components.Vocabulary.Data;
using Twainsoft.ImageProcessing.Common.Components.Vocabulary.Data;
using Twainsoft.ImageProcessing.Common.Contracts.Vocabulary.Data;
using Twainsoft.ImageProcessing.EBC.Components.Vocabulary.Messages;
using Twainsoft.ImageProcessing.IPLab.ROI;

#endregion

namespace Twainsoft.ImageProcessing.EBC.Components.Operations
{
    public class ROICenter : EBCBase, IROICenter
    {
        public ROICenter()
        {
            this.Name = "ROI (Zentrum)";
        }

        public override void MessageReceived(IEBCMessage ebcMessage)
        {
            Bitmap sourceImage = ebcMessage.EBCMessageData.Image;

            Point center = new Point(sourceImage.Width / 2, sourceImage.Height / 2);
            int height = sourceImage.Height - center.Y;

            Bitmap resultingImage = RegionOfInterests.CreateROI(sourceImage, 0, 0, sourceImage.Width, height);

            IEBCMessageData ebcMessageData = new EBCMessageData(DataResultTypes.ROICenter, resultingImage, this.ImageType);

            IDebugData debugData = new DebugData(ebcMessageData.DataResultType, resultingImage);
            debugData.AddSourceImage(ebcMessage.EBCMessageData.Image);

            this.OnOut_ShapeDebugMessage(debugData);

            this.OnOut_SendResult(new EBCMessage(ebcMessageData));
        }
    }
}