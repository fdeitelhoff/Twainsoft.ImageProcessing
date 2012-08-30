#region Namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Twainsoft.ImageProcessing.Shapes.Contracts.Vocabulary.Messages;
using Twainsoft.ImageProcessing.Common.Contracts.Vocabulary.Messages;

#endregion

namespace Twainsoft.ImageProcessing.Shapes.Contracts.Adapter
{
    public interface IImageLoadAdapterShape
    {
        event Action<string> Out_LoadImage;

        void In_GetFileName();
    }
}