#region Namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using Twainsoft.ImageProcessing.Shapes.Contracts.Vocabulary.Messages;
using Twainsoft.ImageProcessing.Shapes.Contracts.Vocabulary.Data;
using Twainsoft.ImageProcessing.Common.Contracts.Vocabulary.Messages;

#endregion

namespace Twainsoft.ImageProcessing.Shapes.Contracts.Base
{
    public interface IShapeBase
    {
        Guid ID { get; }

        string Name { get; set; }
        
        void Paint(Graphics graphics);

        bool IsSelected { get; set; }
        
        bool CheckHoverStatus(Point point);

        bool CheckMousePosition(MouseEventArgs mouseEventArgs);

        bool IsHovered { get; set; }

        bool IsDraged { get; set; }

        bool IsActive { get; set; }

        void SetInitialPosition(Point location);

        event Action<IEBCPinClickedMessage> Out_PinClicked;

        event Action Out_PaintRequest;

        event Action<IShapeDraggedMessage> Out_ShapeDragged;

        event Action Out_StartProcess;

        void In_MouseClick(MouseEventArgs mouseEventArgs);

        void In_MouseDoubleClick(MouseEventArgs mouseEventArgs);

        void In_MouseDown(MouseEventArgs mouseEventArgs);

        void In_MouseMove(MouseEventArgs mouseEventArgs);

        void In_MouseUp(MouseEventArgs mouseEventArgs);        

        Point InputPinCenter();

        Point OutputPinCenter();

        event Action<IChangePinStatusMessage> Out_ChangePinStatus;

        void In_ExceptionInfo(IExceptionInfoMessage exceptionInfoMessage);

        void In_ChangeShapeStatus(IChangeShapeStatusMessage changeShapeStatus);

        void In_ShapeDebugMessage(IShapeDebugMessage debugMessage);

        void In_ExecutionFinished(IExecutionTimeMessage executionTimeMessage);

        event Action<IChangeDataBehaviourMessage> Out_ChangeDataBehaviour;

        void RemoveEvents();

        int MultiSelectNumber { get; set; }

        bool IsInputPinEnabled { get; set; }

        bool IsOutputPinEnabled { get; set; }

        event Action<IImageTypeMessage> Out_ImageType;
    }
}