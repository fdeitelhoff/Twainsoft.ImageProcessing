#region Namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Twainsoft.ImageProcessing.EBC.Contracts.Base;
using Twainsoft.ImageProcessing.EBC.Contracts.Vocabulary.Messages;
using System.Windows.Forms;
using Twainsoft.ImageProcessing.EBC.Components.Vocabulary.Messages;
using Twainsoft.ImageProcessing.Common.Contracts.Vocabulary.Exceptions;
using Twainsoft.ImageProcessing.Common.Contracts.Vocabulary.Messages;
using Twainsoft.ImageProcessing.Common.Components.Vocabulary.Messages;
using Twainsoft.ImageProcessing.EBC.Contracts.Vocabulary.Data;
using Twainsoft.ImageProcessing.Common.Components.Vocabulary.Exceptions;
using Twainsoft.ImageProcessing.Common.Components.Vocabulary.Data;
using Twainsoft.ImageProcessing.Common.Contracts.Vocabulary.Data;

#endregion

namespace Twainsoft.ImageProcessing.EBC.Components.Base
{
    public abstract class EBCBase : IEBCBase
    {
        public string Name { get; set; }

        private IEBCMessage LastReceivedEBCMessage { get; set; }
        private IEBCMessage LastSendEBCMessage { get; set; }

        private bool CanReceiveMessages { get; set; }
        private bool CanSendMessages { get; set; }

        private bool CanProtocolDebugData { get; set; }
        public bool CanProtocolOutputData { get; private set; }

        protected ImageTypes ImageType { get; set; }

        public EBCBase()
        {
            this.Name = "EBCBase";

            this.CanReceiveMessages = true;
            this.CanSendMessages = true;

            this.CanProtocolOutputData = true;
            this.CanProtocolDebugData = true;
        }

        public event Action<IEBCMessage> Out_SendMessage;

        public void In_ReceiveMessage(IEBCMessage ebcMessage)
        {
            this.LastReceivedEBCMessage = ebcMessage;

            if (this.CanReceiveMessages)
            {
                this.InnerReceiveMessage(ebcMessage);
            }
        }

        private void InnerReceiveMessage(IEBCMessage ebcMessage)
        {
            // Catch all exceptions and send them to the environment and the connected shape.
            try
            {
                this.MessageReceived(ebcMessage);
            }
            catch (Exception exception)
            {
                this.OnOut_WorkException(new WorkException(exception));
            }
        }

        public abstract void MessageReceived(IEBCMessage ebcMessage);

        protected void OnOut_SendResult(IEBCMessage ebcMessage)
        {
            this.LastSendEBCMessage = ebcMessage;

            if (this.ImageType != ImageTypes.Default)
            {
                this.LastSendEBCMessage.EBCMessageData.ImageType = this.ImageType;
            }

            if (this.CanSendMessages && this.Out_SendMessage != null)
            {
                this.Out_SendMessage(ebcMessage);
            }

            // We assume that there was no error, if the result can be send.
            this.OnOut_ExceptionInfo(null);
        }

        public event Action<IEBCExceptionMessage> Out_WorkException;

        private void OnOut_WorkException(IWorkException workException)
        {
            // First, send the message to the associated portal to inform the environment.
            if (this.Out_WorkException != null)
            {
                this.Out_WorkException(new EBCExceptionMessage(this, workException));
            }

            // Inform the connected shape about the error.
            this.OnOut_ExceptionInfo(workException);
        }

        public void In_ChangePinStatus(IChangePinStatusMessage changePinStatusMessage)
        {
            if (changePinStatusMessage.PinType == PinTypes.Input)
            {
                // Change the status.
                this.CanReceiveMessages = changePinStatusMessage.Status;

                // If the status is true and there is a message, process it.
                if (this.CanReceiveMessages && this.LastReceivedEBCMessage != null)
                {
                    this.InnerReceiveMessage(this.LastReceivedEBCMessage);
                }
            }
            else if (changePinStatusMessage.PinType == PinTypes.Output)
            {
                // Change the status.
                this.CanSendMessages = changePinStatusMessage.Status;

                // If the status is true and there is a result, send it.
                if (this.CanSendMessages && this.LastSendEBCMessage != null)
                {
                    this.OnOut_SendResult(this.LastSendEBCMessage);
                }
            }
        }

        public event Action<IExceptionInfoMessage> Out_ExceptionInfo;

        protected void OnOut_ExceptionInfo(IWorkException workException)
        {
            if (this.Out_ExceptionInfo != null)
            {
                this.Out_ExceptionInfo(new ExceptionInfoMessage(workException));
            }
        }

        public event Action<IShapeDebugMessage> Out_ShapeDebugMessage;

        protected void OnOut_ShapeDebugMessage(IDebugData debugData)
        {
            if (this.Out_ShapeDebugMessage != null)
            {
                // Transform the EBCMessageData to a DebugMessage, so the shapes can handle them.
                this.Out_ShapeDebugMessage(new ShapeDebugMessage(this.Name, debugData));
            }

            // Send the debug data to the environment (to protocol them in the Output-Data-Toolbox).
            if (this.CanProtocolDebugData && this.Out_EBCDebugMessage != null)
            {
                //this.Out_EBCDebugMessage(ebcMessageData);
                this.Out_EBCDebugMessage(new EBCDebugMessage(this, debugData));
            }
        }

        public event Action<IEBCDebugMessage> Out_EBCDebugMessage;

        public void In_ChangeDataBehaviour(IChangeDataBehaviourMessage changeDataBehaviourMessage)
        {
            this.CanProtocolOutputData = changeDataBehaviourMessage.CanProcotolOutputData;
            this.CanProtocolDebugData = changeDataBehaviourMessage.CanProtocolDebugData;
        }

        public void RemoveEvents()
        {
            this.Out_EBCDebugMessage = null;
            this.Out_ExceptionInfo = null;
            this.Out_SendMessage = null;
            this.Out_ShapeDebugMessage = null;
            this.Out_WorkException = null;
        }

        public event Action<IExecutionTimeMessage> Out_ExecutionFinished;

        public void ExecutionFinished(IExecutionTimeMessage executionTimeMessage)
        {
            if (this.Out_ExecutionFinished != null)
            {
                this.Out_ExecutionFinished(executionTimeMessage);
            }
        }

        public void In_ImageType(IImageTypeMessage imageTypeMessage)
        {
            this.ImageType = imageTypeMessage.ImageType;
        }
    }
}