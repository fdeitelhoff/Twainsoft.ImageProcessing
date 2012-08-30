#region Namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Twainsoft.ImageProcessing.Common.Contracts.Vocabulary.Messages;

#endregion

namespace Twainsoft.ImageProcessing.GUI.Contracts
{
    public interface IFrmToolboxShapes
    {
        ListView.SelectedListViewItemCollection GetSelectedShapes();

        void ClearSelectedShapes();

        event Action<IShapeModeMessage> Out_AddShapeMode;
    }
}