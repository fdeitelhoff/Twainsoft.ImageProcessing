#region Namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

#endregion

namespace Twainsoft.ImageProcessing.Shapes.Contracts.Adapter
{
    public interface IImageSaveAdapterShape
    {
        event Action<string> Out_SaveImage;

        void In_GetFileName();
    }
}