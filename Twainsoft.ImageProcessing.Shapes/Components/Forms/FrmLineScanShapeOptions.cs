#region Namespaces

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

#endregion

namespace Twainsoft.ImageProcessing.Shapes.Components.Forms
{
    public partial class FrmLineScanShapeOptions : FrmShapeOptionsBase
    {
        public Dictionary<int, int> Points { get; set; }

        public FrmLineScanShapeOptions()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Points = this.ucLineScanSelection.Points;

            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void SetSourceImage(Bitmap sourceImage)
        {
            this.ucLineScanSelection.SetSourceImage(sourceImage);
        }
    }
}