#region Namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Twainsoft.ImageProcessing.EBC.Contracts.Vocabulary.Messages;

#endregion

namespace Twainsoft.ImageProcessing.EBC.Contracts.Portals
{
    public interface IShapeCollectorPortal
    {
        void In_GetAvailableShapes();

        event Action<IAvailableShapesMessage> Out_AvailableShapes;
    }
}