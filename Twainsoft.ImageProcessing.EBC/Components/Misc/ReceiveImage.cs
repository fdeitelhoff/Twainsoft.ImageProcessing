#region Namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Twainsoft.ImageProcessing.EBC.Components.Base;
using Twainsoft.ImageProcessing.EBC.Contracts.Misc;
using System.ServiceModel;
using System.ServiceModel.Description;
using Twainsoft.ImageProcessing.EBC.Contracts.Vocabulary.Messages;
using System.ServiceModel.Channels;
using Twainsoft.ImageProcessing.EBC.Components.Vocabulary.Messages;
using Twainsoft.ImageProcessing.EBC.Contracts.WCF;
using Twainsoft.ImageProcessing.EBC.Components.WCF;
using Twainsoft.ImageProcessing.Common.Components.Vocabulary.Exceptions;

#endregion

namespace Twainsoft.ImageProcessing.EBC.Components.Misc
{
    public class ReceiveImage : EBCBase, IReceiveImage
    {
        private ITransferMessageServer TransferMessageServer { get; set; }

        public ReceiveImage()
        {
            this.Name = "Empfänger";

            this.TransferMessageServer = new TransferMessageServer();
            this.TransferMessageServer.Out_MessageTransfered += (IEBCMessage ebcMessage) => this.In_MessageTransfered(ebcMessage);
        }

        public override void MessageReceived(IEBCMessage ebcMessage)
        {
            // This is not allowed here! The EBC sends messages only over the WCF communication channel!
            throw new InvalidOperationException("The EBC '" + this.Name + "' can't send data through the normal EBC communication channel!");
        }

        public void In_StartService()
        {
            try
            {
                // Start the proxy object and send the ServiceStarted event, if there was no error.
                this.TransferMessageServer.StartServer();

                this.Out_ServiceStarted();
            }
            catch (Exception exception)
            {
                this.OnOut_ExceptionInfo(new WorkException("Beim Starten des WCF-Services ist ein Fehler aufgetreten!", exception));
            }
        }

        public void In_MessageTransfered(IEBCMessage ebcMessage)
        {
            // If a message was received, send it through ne normal EBC communication channel.
            this.OnOut_SendResult(new EBCMessage(ebcMessage.EBCMessageData));
        }

        public event Action Out_ServiceStarted;
    }
}