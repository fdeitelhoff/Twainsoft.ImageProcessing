#region Namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Twainsoft.ImageProcessing.EBC.Contracts.Vocabulary.Data;

#endregion

namespace Twainsoft.ImageProcessing.EBC.Components.Vocabulary.Data
{
    public class ShapeInfoData : IShapeInfoData
    {
        public string Name { get; private set; }
        public Type Type { get; private set; }
        public ShapeGroups ShapeGroup { get; private set; }

        public ShapeInfoData(ShapeGroups shapeGroup, string name, Type type)
        {
            this.ShapeGroup = shapeGroup;
            this.Name = name;
            this.Type = type;
        }
    }
}