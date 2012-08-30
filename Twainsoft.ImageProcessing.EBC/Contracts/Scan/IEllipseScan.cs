#region Namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Twainsoft.ImageProcessing.Shapes.Contracts.Vocabulary.Messages;

#endregion

namespace Twainsoft.ImageProcessing.EBC.Contracts.Scan
{
    public interface IEllipseScan
    {
        event Action<Bitmap> Out_GetEllipseScanCoordinates;

        void In_ScanImage(IEllipseScanCoordinatesMessage ellipseScanCoordinatesMessage);
    }
}