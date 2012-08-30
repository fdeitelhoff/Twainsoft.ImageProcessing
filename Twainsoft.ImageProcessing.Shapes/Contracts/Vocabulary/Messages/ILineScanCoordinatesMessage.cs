#region Namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

#endregion

namespace Twainsoft.ImageProcessing.Shapes.Contracts.Vocabulary.Messages
{
    public interface ILineScanCoordinatesMessage
    {
        Dictionary<int, int> Coordinates { get; }
    }
}