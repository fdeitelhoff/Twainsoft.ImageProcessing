﻿#region Namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Twainsoft.ImageProcessing.EBC.Contracts.Vocabulary.Messages;
using Twainsoft.ImageProcessing.EBC.Contracts.Base;

#endregion

namespace Twainsoft.ImageProcessing.EBC.Components.Vocabulary.Messages
{
    public class DisconnectEBCMessage : IDisconnectEBCMessage
    {
        public IEBCBase OutputEBC { get; private set; }

        public IEBCBase InputEBC { get; private set; }

        public DisconnectEBCMessage(IEBCBase outputEBC, IEBCBase inputEBC)
        {
            this.OutputEBC = outputEBC;
            this.InputEBC = inputEBC;
        }
    }
}