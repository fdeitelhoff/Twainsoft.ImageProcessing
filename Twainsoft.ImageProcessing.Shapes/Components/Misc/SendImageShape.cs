#region Namespaces

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Twainsoft.ImageProcessing.Shapes.Components.Base;

#endregion

namespace Twainsoft.ImageProcessing.Shapes.Components.Misc
{
    public partial class SendImageShape : ShapeBase
    {
        public SendImageShape()
        {
            InitializeComponent();

            this.IsOutputPinEnabled = false;
        }
    }
}