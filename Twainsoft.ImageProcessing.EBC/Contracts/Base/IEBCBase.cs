#region Namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Twainsoft.ImageProcessing.EBC.Contracts.Vocabulary.Messages;
using Twainsoft.ImageProcessing.Common.Contracts.Vocabulary.Messages;
using Twainsoft.ImageProcessing.EBC.Contracts.Vocabulary.Data;

#endregion

namespace Twainsoft.ImageProcessing.EBC.Contracts.Base
{
    public interface IEBCBase
    {
        string Name { get; set; }

        bool CanProtocolOutputData { get; }

        event Action<IEBCMessage> Out_SendMessage;

        event Action<IShapeDebugMessage> Out_ShapeDebugMessage;

        event Action<IEBCDebugMessage> Out_EBCDebugMessage;

        event Action<IEBCExceptionMessage> Out_WorkException;

        event Action<IExceptionInfoMessage> Out_ExceptionInfo;

        event Action<IExecutionTimeMessage> Out_ExecutionFinished;

        void In_ReceiveMessage(IEBCMessage ebcMessage);

        void In_ChangePinStatus(IChangePinStatusMessage changePinStatusMessage);

        void In_ChangeDataBehaviour(IChangeDataBehaviourMessage changeDataBehaviourMessage);

        void RemoveEvents();

        void ExecutionFinished(IExecutionTimeMessage executionTimeMessage);

        void In_ImageType(IImageTypeMessage imageTypeMessage);
    }
}