#region Namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Twainsoft.ImageProcessing.EBC.Components.Base;
using Twainsoft.ImageProcessing.EBC.Contracts.Vocabulary.Messages;
using Twainsoft.ImageProcessing.EBC.Contracts.Scan;
using Twainsoft.ImageProcessing.Shapes.Contracts.Vocabulary.Messages;
using Twainsoft.ImageProcessing.EBC.Contracts.Vocabulary.Data;
using System.Drawing;
using Twainsoft.ImageProcessing.EBC.Components.Vocabulary.Messages;
using Twainsoft.ImageProcessing.EBC.Components.Vocabulary.Data;
using Twainsoft.ImageProcessing.IPLab.ImageScan;
using Twainsoft.ImageProcessing.Common.Components.Vocabulary.Data;
using Twainsoft.ImageProcessing.Common.Contracts.Vocabulary.Data;

#endregion

namespace Twainsoft.ImageProcessing.EBC.Components.Scan
{
    public class LineScan : EBCBase, ILineScan
    {
        private ILineScanCoordinatesMessage LineScanCoordinatesMessage { get; set; }
        private IEBCMessageData EBCMessageData { get; set; }

        public LineScan()
        {
            this.Name = "Line-Scan";
        }

        public override void MessageReceived(IEBCMessage ebcMessage)
        {
            this.EBCMessageData = ebcMessage.EBCMessageData;

            if (this.LineScanCoordinatesMessage == null)
            {
                this.Out_GetLineScanCoordinates(ebcMessage.EBCMessageData.Image);
            }

            this.ProcessScan();
        }

        private void ProcessScan()
        {
            if (this.EBCMessageData != null && this.LineScanCoordinatesMessage != null)
            {
                int[] lineScanData = ImageScans.LineScan(this.EBCMessageData.Image, this.LineScanCoordinatesMessage.Coordinates);

                IEBCMessageData ebcMessageData = new EBCMessageData(DataResultTypes.LineScan,
                    this.EBCMessageData.Image, lineScanData);

                IDebugData debugData = new DebugData(ebcMessageData.DataResultType, this.EBCMessageData.Image, lineScanData);

                this.OnOut_ShapeDebugMessage(debugData);

                this.OnOut_SendResult(new EBCMessage(ebcMessageData));
            }
        }

        public event Action<Bitmap> Out_GetLineScanCoordinates;

        public void In_ScanImage(ILineScanCoordinatesMessage lineScanCoordinatesMessage)
        {
            this.LineScanCoordinatesMessage = lineScanCoordinatesMessage;
        }
    }
}