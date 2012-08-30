#region Namespaces

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Twainsoft.ImageProcessing.Shapes.Components.Base;

#endregion

namespace Twainsoft.ImageProcessing.Shapes.Components.LUT
{
    public partial class LookUpTableShape : ShapeBase
    {
        public LookUpTableShape()
            : base()
        {
            InitializeComponent();

            this.Name = "Look-Up-Table";
        }
    }
}