#region Namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Twainsoft.ImageProcessing.Common.Contracts.Vocabulary.Messages;

#endregion

namespace Twainsoft.ImageProcessing.Common.Components.Vocabulary.Messages
{
    public class ChangeShapeStatusMessage : IChangeShapeStatusMessage
    {
        public bool IsShapeActive { get; private set; }

        public ChangeShapeStatusMessage(bool isShapeActive)
        {
            this.IsShapeActive = isShapeActive;
        }
    }
}