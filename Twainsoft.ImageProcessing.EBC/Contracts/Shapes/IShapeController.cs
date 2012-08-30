#region Namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Twainsoft.ImageProcessing.EBC.Contracts.Vocabulary.Messages;
using Twainsoft.ImageProcessing.EBC.Contracts.Base;
using System.Drawing;
using Twainsoft.ImageProcessing.Shapes.Contracts.Vocabulary.Messages;
using Twainsoft.ImageProcessing.Shapes.Contracts;
using Twainsoft.ImageProcessing.Shapes.Contracts.Base;
using Twainsoft.ImageProcessing.Common.Contracts.Vocabulary.Messages;

#endregion

namespace Twainsoft.ImageProcessing.EBC.Contracts
{
    public interface IShapeController
    {
        void In_MouseMove(MouseEventArgs mouseEventArgs);

        void In_MouseClick(MouseEventArgs mouseEventArgs);

        void In_MouseDoubleClick(MouseEventArgs mouseEventArgs);

        void In_MouseUp(MouseEventArgs mouseEventArgs);

        void In_MouseDown(MouseEventArgs mouseEventArgs);

        void In_KeyDown(KeyEventArgs keyEventArgs);

        void In_KeyUp(KeyEventArgs keyEventArgs);

        void In_PaintRequest(IPaintRequestMessage paintRequestMessage);

        void In_AddShape(IAddShapeMessage addShapeMessage);

        void In_ShapeMode(IShapeModeMessage shapeModeMessage);

        event Action<IEBCBase> Out_EBCAdded;

        event Action Out_PaintRequest;

        event Action<MouseEventArgs> Out_MouseClick;

        event Action<MouseEventArgs> Out_MouseDoubleClick;

        event Action<MouseEventArgs> Out_MouseMove;

        event Action<MouseEventArgs> Out_MouseUp;

        event Action<MouseEventArgs> Out_MouseDown;

        event Action<IConnectEBCMessage> Out_ConnectEBCs;

        event Action<IDisconnectEBCMessage> Out_DisconnectEBCs;

        event Action<IExecuteFirstEBCMessage> Out_ExecuteFirstEBC;

        event Action<IEBCBase> Out_DeleteEBC;

        event Action<ISTEConnectMessage> Out_STEAutoConnect;

        event Action<IErrorMessage> Out_ReportError;
    }
}