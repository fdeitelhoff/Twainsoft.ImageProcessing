#region Namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Twainsoft.ImageProcessing.Shapes.Contracts.Vocabulary.Messages;
using Twainsoft.ImageProcessing.EBC.Contracts.Vocabulary.Messages;
using System.Drawing;

#endregion

namespace Twainsoft.ImageProcessing.EBC.Contracts.Scan
{
    public interface ILineScan
    {
        event Action<Bitmap> Out_GetLineScanCoordinates;

        void In_ScanImage(ILineScanCoordinatesMessage lineScanCoordinatesMessage);
    }
}