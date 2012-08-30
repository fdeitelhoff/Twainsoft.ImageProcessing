#region Namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Twainsoft.ImageProcessing.EBC.Contracts.Scan;
using Twainsoft.ImageProcessing.EBC.Components.Base;
using Twainsoft.ImageProcessing.EBC.Contracts.Vocabulary.Messages;
using Twainsoft.ImageProcessing.EBC.Contracts.Vocabulary.Data;
using System.Drawing;
using Twainsoft.ImageProcessing.Shapes.Contracts.Vocabulary.Messages;
using Twainsoft.ImageProcessing.IPLab.ImageScan;
using Twainsoft.ImageProcessing.EBC.Components.Vocabulary.Data;
using Twainsoft.ImageProcessing.EBC.Components.Vocabulary.Messages;
using Twainsoft.ImageProcessing.Common.Components.Vocabulary.Data;
using Twainsoft.ImageProcessing.Common.Contracts.Vocabulary.Data;

#endregion

namespace Twainsoft.ImageProcessing.EBC.Components.Scan
{
    public class EllipseScan : EBCBase, IEllipseScan
    {
        private IEBCMessageData EBCMessageData { get; set; }
        private IEllipseScanCoordinatesMessage EllipseScanCoordinatesMessage { get; set; }

        public EllipseScan()
        {
            this.Name = "Ellipse-Scan";
        }

        public override void MessageReceived(IEBCMessage ebcMessage)
        {
            this.EBCMessageData = ebcMessage.EBCMessageData;

            if (this.EllipseScanCoordinatesMessage == null)
            {
                this.Out_GetEllipseScanCoordinates(this.EBCMessageData.Image);
            }

            this.ProcessScan();
        }

        private void ProcessScan()
        {
            if (this.EBCMessageData != null && this.EllipseScanCoordinatesMessage != null)
            {
                Bitmap resultingImage = new Bitmap(this.EBCMessageData.Image);

                int[] ellipseScanData = ImageScans.EllipseScan(resultingImage, this.EllipseScanCoordinatesMessage.EllipseCenter,
                    this.EllipseScanCoordinatesMessage.EllipseWidth, this.EllipseScanCoordinatesMessage.EllipseHeight);

                // The real data. Both images are equal!
                IEBCMessageData ebcMessageData = new EBCMessageData(DataResultTypes.EllipseScan,
                    this.EBCMessageData.Image, ellipseScanData);

                // Send the debug data with the resulting image containing the ellipse.
                IDebugData debugData = new DebugData(ebcMessageData.DataResultType, resultingImage, ellipseScanData);
                debugData.AddSourceImage(this.EBCMessageData.Image);

                this.OnOut_ShapeDebugMessage(debugData);

                this.OnOut_SendResult(new EBCMessage(ebcMessageData));
            }
        }

        public event Action<Bitmap> Out_GetEllipseScanCoordinates;

        public void In_ScanImage(IEllipseScanCoordinatesMessage ellipseScanCoordinatesMessage)
        {
            this.EllipseScanCoordinatesMessage = ellipseScanCoordinatesMessage;
        }
    }
}