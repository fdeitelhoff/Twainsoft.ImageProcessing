#region Namespaces

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Twainsoft.ImageProcessing.Common.Contracts.Vocabulary.Data;
using Twainsoft.ImageProcessing.Common.Components.Vocabulary.Data;

#endregion

namespace Twainsoft.ImageProcessing.Shapes.Components.Forms.Threshold
{
    public partial class FrmThresholdShapeOptions : FrmShapeOptionsBase
    {
        public List<IThresholdData> ThresholdData { get; private set; }

        public FrmThresholdShapeOptions()
        {
            InitializeComponent();

            this.ThresholdData = new List<IThresholdData>();
        }

        private void btnCreateThreshold_Click(object sender, EventArgs e)
        {
            int min = Convert.ToInt32(this.nupMinValue.Value);
            int max = Convert.ToInt32(this.nupMaxValue.Value);
            int grayValue = Convert.ToInt32(this.nupGrayValue.Value);

            ThresholdData thresholdData = new ThresholdData(min, max, grayValue);

            this.ThresholdData.Add(thresholdData);

            this.dgvThresholds.Rows.Add(new object[] { min, max, grayValue });
        }

        private void btnDeleteThreshold_Click(object sender, EventArgs e)
        {
            for (int i = this.dgvThresholds.SelectedRows.Count - 1; i >= 0; i--)
            {
                this.ThresholdData.RemoveAt(this.dgvThresholds.SelectedRows[i].Index);

                this.dgvThresholds.Rows.Remove(this.dgvThresholds.SelectedRows[i]);
            }
        }

        private void dgvThresholds_SelectionChanged(object sender, EventArgs e)
        {
            this.btnDeleteThreshold.Enabled = this.dgvThresholds.SelectedRows.Count > 0;
        }
    }
}