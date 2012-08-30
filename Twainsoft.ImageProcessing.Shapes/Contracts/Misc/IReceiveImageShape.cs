#region Namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

#endregion

namespace Twainsoft.ImageProcessing.Shapes.Contracts.Misc
{
    public interface IReceiveImageShape
    {
        event Action Out_StartService;

        void In_ServiceStarted();
    }
}