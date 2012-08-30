#region Namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Twainsoft.ImageProcessing.EBC.Contracts.Base;
using Twainsoft.ImageProcessing.EBC.Contracts.Vocabulary.Messages;

#endregion

namespace Twainsoft.ImageProcessing.EBC.Contracts.Execution
{
    public interface IExecutionController
    {
        void In_ConnectEBCs(IConnectEBCMessage connectEBCMessage);

        void In_DisconnectEBCs(IDisconnectEBCMessage disconnectEBCMessage);

        void In_ExecuteFirstEBC(IExecuteFirstEBCMessage executeFirstEBCMessage);

        void In_EBCAdded(IEBCBase ebcBase);

        void In_DeleteEBC(IEBCBase ebcBase);

        event Action<IExecutionFinishedMessage> Out_ExecutionFinished;

        event Action<IEBCDebugMessage> Out_EBCDebugMessage;

        event Action<IEBCExceptionMessage> Out_EBCWorkExceptionHandled;
    }
}