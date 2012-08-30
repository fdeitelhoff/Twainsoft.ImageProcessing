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

namespace Twainsoft.ImageProcessing.EBC.Contracts.Portals
{
    public interface IPaintLeafPortal
    {
        void In_MouseMove(MouseEventArgs mouseEventArgs);

        void In_MouseClick(MouseEventArgs mouseEventArgs);

        void In_MouseDoubleClick(MouseEventArgs mouseEventArgs);

        void In_MouseDown(MouseEventArgs mouseEventArgs);

        void In_MouseUp(MouseEventArgs mouseEventArgs);

        void In_KeyDown(KeyEventArgs keyEventArgs);

        void In_KeyUp(KeyEventArgs keyEventArgs);

        void In_PaintRequest(PaintEventArgs paintEventArgs);

        void In_AddShape(IShapeBase shapeBase, IEBCBase ebcBase, Point shapeLocation);

        void In_ShapeMode(IShapeModeMessage shapeModeMessage);

        event Action<MouseEventArgs> Out_MouseMove;

        event Action<MouseEventArgs> Out_MouseClick;

        event Action<MouseEventArgs> Out_MouseDoubleClick;

        event Action<MouseEventArgs> Out_MouseUp;

        event Action<MouseEventArgs> Out_MouseDown;

        event Action<KeyEventArgs> Out_KeyDown;

        event Action<KeyEventArgs> Out_KeyUp;

        event Action<IPaintRequestMessage> Out_PaintRequest;

        event Action Out_InvalidateRequest;

        event Action<IAddShapeMessage> Out_AddShape;

        event Action<IExecutionFinishedMessage> Out_ExecutionFinished;

        event Action<IEBCDebugMessage> Out_EBCDebugMessage;

        event Action<IEBCExceptionMessage> Out_EBCWorkExceptionHandled;

        event Action<IShapeModeMessage> Out_ShapeMode;

        event Action<IErrorMessage> Out_ReportError;
    }
}