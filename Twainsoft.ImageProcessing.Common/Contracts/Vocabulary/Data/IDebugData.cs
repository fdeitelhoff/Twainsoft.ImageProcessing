#region Namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Twainsoft.ImageProcessing.Common.Components.Vocabulary.Data;

#endregion

namespace Twainsoft.ImageProcessing.Common.Contracts.Vocabulary.Data
{
    public interface IDebugData
    {
        DataResultTypes DataResultType { get; }

        List<Bitmap> SourceImages { get; }

        Bitmap ResultingImage { get; }

        bool HasSourceImages { get; }

        bool HasResultingImage { get; }

        bool HasData { get; }

        object Data { get; }

        void AddSourceImage(Bitmap sourceImage);
    }
}