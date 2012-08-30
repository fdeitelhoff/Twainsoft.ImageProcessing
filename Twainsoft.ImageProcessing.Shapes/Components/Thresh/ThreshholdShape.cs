#region Namespaces

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Twainsoft.ImageProcessing.Shapes.Components.Base;
using Twainsoft.ImageProcessing.Shapes.Contracts.Threshold;
using Twainsoft.ImageProcessing.Shapes.Components.Forms.Threshold;
using System.Windows.Forms;
using Twainsoft.ImageProcessing.Common.Contracts.Vocabulary.Messages;
using Twainsoft.ImageProcessing.Common.Components.Vocabulary.Messages;

#endregion

namespace Twainsoft.ImageProcessing.Shapes.Components.Thresh
{
    public partial class ThresholdShape : ShapeBase, IThresholdShape
    {
        private FrmThresholdShapeOptions FrmThresholdShapeOptions { get; set; }

        public ThresholdShape()
        {
            InitializeComponent();

            this.FrmThresholdShapeOptions = new FrmThresholdShapeOptions();

            this.BuildOwnContextMenu();
        }

        private void BuildOwnContextMenu()
        {
            this.MergeContextMenuItems(this.cmsOptions);

            this.tsmiThresholds.Click += (object sender, EventArgs e) => this.In_SelectThresholds();
        }

        public void In_SelectThresholds()
        {
            if (this.FrmThresholdShapeOptions.ShowDialog() == DialogResult.OK)
            {
                this.Out_ThresholdsSelected(new ThresholdMessage(this.FrmThresholdShapeOptions.ThresholdData));
            }
        }
        
        public event Action<IThresholdMessage> Out_ThresholdsSelected;
    }
}