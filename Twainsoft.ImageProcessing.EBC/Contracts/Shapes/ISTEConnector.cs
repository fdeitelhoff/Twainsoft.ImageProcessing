﻿#region Namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Twainsoft.ImageProcessing.EBC.Contracts.Vocabulary.Messages;

#endregion

namespace Twainsoft.ImageProcessing.EBC.Contracts.Shapes
{
    public interface ISTEConnector
    {
        void In_STEAutoConnect(ISTEConnectMessage steConnectMessage);
    }
}