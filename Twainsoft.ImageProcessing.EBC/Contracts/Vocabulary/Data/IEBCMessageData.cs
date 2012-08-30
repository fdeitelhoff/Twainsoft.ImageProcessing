#region Namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Twainsoft.ImageProcessing.Common.Components.Vocabulary.Data;
using System.Drawing;
using System.Runtime.Serialization;

#endregion

namespace Twainsoft.ImageProcessing.EBC.Contracts.Vocabulary.Data
{
    public interface IEBCMessageData
    {
        Bitmap Image { get; }

        ImageTypes ImageType { get; set; }

        DataResultTypes DataResultType { get; }

        bool HasImage { get; }

        bool HasData { get; }

        object Data { get; }
    }
}