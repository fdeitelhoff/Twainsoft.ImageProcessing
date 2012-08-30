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
    public enum ImageTypes
    {
        [EnumMember]
        Default,
        [EnumMember]
        Minuend,
        [EnumMember]
        Subtrahend,
        [EnumMember]
        FirstSummand,
        [EnumMember]
        SecondSummand
    }
}