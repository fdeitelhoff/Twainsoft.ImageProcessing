#region Namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Twainsoft.ImageProcessing.Shapes.Contracts.Vocabulary.Messages;
using System.Drawing;

#endregion

namespace Twainsoft.ImageProcessing.Shapes.Contracts.Scan
{
    public interface ILineScanShape
    {
        void In_GetLineScanCoordinates(Bitmap sourceImage);

        event Action<ILineScanCoordinatesMessage> Out_ScanImage;
    }
}