#region Namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Twainsoft.ImageProcessing.EBC.Contracts.Vocabulary.Messages;
using Twainsoft.ImageProcessing.EBC.Contracts.Base;
using Twainsoft.ImageProcessing.EBC.Contracts.Vocabulary.Data;

#endregion

namespace Twainsoft.ImageProcessing.EBC.Components.Vocabulary.Messages
{
    public class AvailableShapesMessage : IAvailableShapesMessage
    {
        public Dictionary<IShapeInfoData, Type> ShapesToEBCs { get; private set; }

        public AvailableShapesMessage(Dictionary<IShapeInfoData, Type> shapesToEBCs)
        {
            this.ShapesToEBCs = shapesToEBCs;
        }
    }
}