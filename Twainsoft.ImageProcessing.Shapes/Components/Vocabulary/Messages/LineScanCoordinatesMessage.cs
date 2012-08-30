#region Namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Twainsoft.ImageProcessing.Shapes.Contracts.Vocabulary.Messages;

#endregion

namespace Twainsoft.ImageProcessing.Shapes.Components.Vocabulary.Messages
{
    public class LineScanCoordinatesMessage : ILineScanCoordinatesMessage
    {
        public Dictionary<int, int> Coordinates { get; private set; }

        public LineScanCoordinatesMessage(Dictionary<int, int> coordinates)
        {
            this.Coordinates = coordinates;
        }
    }
}