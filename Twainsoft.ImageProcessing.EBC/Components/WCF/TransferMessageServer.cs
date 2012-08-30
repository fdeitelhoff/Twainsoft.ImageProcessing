#region Namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Description;
using Twainsoft.ImageProcessing.EBC.Contracts.Vocabulary.WCF;
using Twainsoft.ImageProcessing.EBC.Contracts.WCF;
using Twainsoft.ImageProcessing.EBC.Contracts.Vocabulary.Messages;
using Twainsoft.ImageProcessing.EBC.Components.Vocabulary.Messages;
using Twainsoft.ImageProcessing.EBC.Contracts.Vocabulary.Data;
using Twainsoft.ImageProcessing.EBC.Components.Vocabulary.Message;

#endregion

namespace Twainsoft.ImageProcessing.EBC.Components.WCF
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class TransferMessageServer : ITransferMessageServer
    {
        public TransferMessageServer() { }

        public void TransferMessage(TransferMessage ebcMessage)
        {
            // If there was a message through the WCF channel, inform the "environment".
            this.OnOut_MessageTransfered(ebcMessage.EBCMessageData);
        }

        public void StartServer()
        {
            // The WCF service host.
            ServiceHost host = new ServiceHost(this, new Uri("http://localhost:8090/Twainsoft/ImageProcessing/TransferMessage"));
            
            // Set different options (quota and security) for the http binding.
            WSHttpBinding wsHttpBinding = new WSHttpBinding();
            wsHttpBinding.Security.Mode = SecurityMode.None;
            wsHttpBinding.Security.Transport.ClientCredentialType = HttpClientCredentialType.None;
            wsHttpBinding.Security.Message.EstablishSecurityContext = false;
            wsHttpBinding.MaxReceivedMessageSize = Int32.MaxValue;
            wsHttpBinding.MaxBufferPoolSize = Int32.MaxValue;
            wsHttpBinding.ReaderQuotas.MaxArrayLength = Int32.MaxValue;
            wsHttpBinding.ReaderQuotas.MaxBytesPerRead = Int32.MaxValue;
            wsHttpBinding.ReaderQuotas.MaxStringContentLength = Int32.MaxValue;

            // Add the endpoint.
            host.AddServiceEndpoint(typeof(ITransferMessage), wsHttpBinding, "");

            // Enable metadata exchange.
            host.Description.Behaviors.Add(new ServiceMetadataBehavior() { HttpGetEnabled = true });

            host.Open();
        }

        public event Action<IEBCMessage> Out_MessageTransfered;

        private void OnOut_MessageTransfered(IEBCMessageData ebcMessageData)
        {
            if (this.Out_MessageTransfered != null)
            {
                this.Out_MessageTransfered(new EBCMessage(ebcMessageData));
            }
        }
    }
}
