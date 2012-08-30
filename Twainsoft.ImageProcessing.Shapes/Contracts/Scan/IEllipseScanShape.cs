#region Namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Twainsoft.ImageProcessing.Shapes.Contracts.Vocabulary.Messages;

#endregion

namespace Twainsoft.ImageProcessing.Shapes.Contracts.Scan
{
    public interface IEllipseScanShape
    {
        void In_GetEllipseScanCoordinates(Bitmap sourceImage);

        event Action<IEllipseScanCoordinatesMessage> Out_ScanImage;
    }
}