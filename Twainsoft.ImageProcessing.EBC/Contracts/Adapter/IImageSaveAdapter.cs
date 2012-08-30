#region Namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

#endregion

namespace Twainsoft.ImageProcessing.EBC.Contracts.Adapter
{
    public interface IImageSaveAdapter
    {
        void In_SaveImage(string fileName);

        event Action Out_GetFileName;
    }
}