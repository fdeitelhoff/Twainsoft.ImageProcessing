#region Namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

#endregion

namespace Twainsoft.ImageProcessing.Common.Components.Vocabulary.Data
{
    [DataContract]
    public enum DataResultTypes
    {
        [EnumMember]
        LoadImage,
        [EnumMember]
        GrayValueHistogram,
        [EnumMember]
        CumulativeHistogram,
        [EnumMember]
        LookUpTable,
        [EnumMember]
        HistogramEqualiziation,
        [EnumMember]
        SaveImage,
        [EnumMember]
        LineScan,
        [EnumMember]
        EllipseScan,
        [EnumMember]
        Subtraction,
        [EnumMember]
        ImageRepeater,
        [EnumMember]
        CachedImage,
        [EnumMember]
        Threshold,
        [EnumMember]
        Addition,
        [EnumMember]
        Dilatation,
        [EnumMember]
        Erodation,
        [EnumMember]
        Median,
        [EnumMember]
        Opening,
        [EnumMember]
        Closing,
        [EnumMember]
        Laplace,
        [EnumMember]
        GradientOut,
        [EnumMember]
        GradientIn,
        [EnumMember]
        ROICenter,
        [EnumMember]
        FloodFill,
        [EnumMember]
        IncreaseContrast,
        [EnumMember]
        BottleCheck
    }
}