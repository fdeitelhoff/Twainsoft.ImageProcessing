#region Namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Twainsoft.ImageProcessing.EBC.Contracts.Gradient;
using Twainsoft.ImageProcessing.EBC.Components.Base;
using Twainsoft.ImageProcessing.EBC.Contracts.Vocabulary.Messages;
using Twainsoft.ImageProcessing.EBC.Components.Ranking;
using Twainsoft.ImageProcessing.EBC.Components.Operations;
using System.Drawing;
using Twainsoft.ImageProcessing.Common.Components.Vocabulary.Data;
using Twainsoft.ImageProcessing.EBC.Components.Vocabulary.Messages;
using Twainsoft.ImageProcessing.EBC.Contracts.Vocabulary.Data;
using Twainsoft.ImageProcessing.EBC.Components.Vocabulary.Data;
using Twainsoft.ImageProcessing.Common.Contracts.Vocabulary.Data;

#endregion

namespace Twainsoft.ImageProcessing.EBC.Components.Gradient
{
    public class GradientOut : EBCBase, IGradientOut
    {
        private Dilatation Dilatation { get; set; }
        private Subtraction Subtraction { get; set; }

        private EBCMessageData EBCMessageData { get; set; }

        public GradientOut()
        {
            this.Name = "Gradient-out";

            this.Dilatation = new Dilatation();
            this.Subtraction = new Subtraction();

            this.Dilatation.Out_SendMessage += new Action<IEBCMessage>(Dilatation_Out_SendMessage);
            this.Subtraction.Out_SendMessage += new Action<IEBCMessage>(Subtraction_Out_SendMessage);

            this.Dilatation.Out_EBCDebugMessage += (IEBCDebugMessage debugMessage)
                => this.OnOut_ShapeDebugMessage(debugMessage.DebugData);
            this.Subtraction.Out_EBCDebugMessage += (IEBCDebugMessage debugMessage)
                => this.OnOut_ShapeDebugMessage(debugMessage.DebugData);
        }

        private void Subtraction_Out_SendMessage(IEBCMessage ebcMessage)
        {
            IEBCMessageData ebcMessageData = new EBCMessageData(DataResultTypes.GradientOut,
                ebcMessage.EBCMessageData.Image, ebcMessage.EBCMessageData.ImageType);

            // Send the debug data with the resulting image containing the ellipse.
            IDebugData debugData = new DebugData(ebcMessageData.DataResultType, ebcMessage.EBCMessageData.Image);

            this.OnOut_ShapeDebugMessage(debugData);

            this.OnOut_SendResult(new EBCMessage(ebcMessageData));
        }

        private void Dilatation_Out_SendMessage(IEBCMessage ebcMessage)
        {
            this.Subtraction.In_ReceiveMessage(ebcMessage);
            this.Subtraction.In_ReceiveMessage(new EBCMessage(this.EBCMessageData));
        }

        public override void MessageReceived(IEBCMessage ebcMessage)
        {
            this.EBCMessageData = new EBCMessageData(ebcMessage.EBCMessageData);
            this.EBCMessageData.ImageType = ImageTypes.Subtrahend;

            IEBCMessageData newEBCMessageData = new EBCMessageData(ebcMessage.EBCMessageData);
            newEBCMessageData.ImageType = ImageTypes.Minuend;

            this.Dilatation.In_ReceiveMessage(new EBCMessage(newEBCMessageData));
        }
    }
}