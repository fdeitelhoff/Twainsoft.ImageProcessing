#region Namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Twainsoft.ImageProcessing.EBC.Contracts.Portals;
using Twainsoft.ImageProcessing.EBC.Contracts.Shapes;
using Twainsoft.ImageProcessing.EBC.Contracts.Vocabulary.Messages;

#endregion

namespace Twainsoft.ImageProcessing.EBC.Components.Portals
{
    public class ShapeCollectorPortal : IShapeCollectorPortal
    {
        private IShapeCollector ShapeCollector { get; set; }

        public ShapeCollectorPortal(IShapeCollector shapeCollector)
        {
            this.ShapeCollector = shapeCollector;

            this.ShapeCollector.Out_AvailableShapes += (IAvailableShapesMessage availableShapesMessage) => this.Out_AvailableShapes(availableShapesMessage);
        }

        public void In_GetAvailableShapes()
        {
            this.ShapeCollector.In_GetAvailableShapes();
        }

        public event Action<IAvailableShapesMessage> Out_AvailableShapes;
    }
}