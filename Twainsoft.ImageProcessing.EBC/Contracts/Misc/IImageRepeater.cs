﻿#region Namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Twainsoft.ImageProcessing.Common.Contracts.Vocabulary.Messages;

#endregion

namespace Twainsoft.ImageProcessing.EBC.Contracts.Misc
{
    public interface IImageRepeater
    {
        void In_RepeatCountChanged(IRepeatCountChangedMessage repeatCountChangedMessage);
    }
}