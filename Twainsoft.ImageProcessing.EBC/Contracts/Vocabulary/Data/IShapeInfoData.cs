#region Namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Twainsoft.ImageProcessing.EBC.Components.Vocabulary.Data;

#endregion

namespace Twainsoft.ImageProcessing.EBC.Contracts.Vocabulary.Data
{
    public interface IShapeInfoData
    {
        string Name { get; }

        Type Type { get; }

        ShapeGroups ShapeGroup { get; }
    }
}