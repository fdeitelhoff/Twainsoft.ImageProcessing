#region Namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Twainsoft.ImageProcessing.EBC.Contracts.Ranking;
using Twainsoft.ImageProcessing.EBC.Components.Base;
using Twainsoft.ImageProcessing.EBC.Contracts.Vocabulary.Messages;
using System.Drawing;
using Twainsoft.ImageProcessing.IPLab.Ranking;
using Twainsoft.ImageProcessing.EBC.Contracts.Vocabulary.Data;
using Twainsoft.ImageProcessing.EBC.Components.Vocabulary.Data;
using Twainsoft.ImageProcessing.Common.Components.Vocabulary.Data;
using Twainsoft.ImageProcessing.Common.Contracts.Vocabulary.Data;
using Twainsoft.ImageProcessing.EBC.Components.Vocabulary.Messages;

#endregion

namespace Twainsoft.ImageProcessing.EBC.Components.Ranking
{
    public class Laplace : EBCBase, ILaplace
    {
        public Laplace()
        {
            this.Name = "Laplace-Filter";
        }

        public override void MessageReceived(IEBCMessage ebcMessage)
        {
            int[,] matrix = new int[,] { { 1, 1, 1 }, { 1, -8, 1 }, { 1, 1, 1 } };

            Bitmap resultingImage = RankingOperations.ApplyLaplace(ebcMessage.EBCMessageData.Image, matrix);

            IEBCMessageData ebcMessageData = new EBCMessageData(DataResultTypes.Laplace,
                resultingImage, ebcMessage.EBCMessageData.ImageType);

            // Send the debug data with the resulting image containing the ellipse.
            IDebugData debugData = new DebugData(ebcMessageData.DataResultType, resultingImage);
            debugData.AddSourceImage(ebcMessage.EBCMessageData.Image);

            this.OnOut_ShapeDebugMessage(debugData);

            this.OnOut_SendResult(new EBCMessage(ebcMessageData));
        }
    }
}