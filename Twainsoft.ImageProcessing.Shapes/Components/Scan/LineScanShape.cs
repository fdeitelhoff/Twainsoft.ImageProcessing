#region Namespaces

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Twainsoft.ImageProcessing.Shapes.Components.Forms;
using Twainsoft.ImageProcessing.Shapes.Contracts;
using Twainsoft.ImageProcessing.Shapes.Contracts.Vocabulary.Messages;
using Twainsoft.ImageProcessing.Shapes.Components.Vocabulary.Messages;
using System.Drawing;
using Twainsoft.ImageProcessing.Shapes.Contracts.Scan;
using Twainsoft.ImageProcessing.Shapes.Components.Base;

#endregion

namespace Twainsoft.ImageProcessing.Shapes.Components.Scan
{
    public partial class LineScanShape : ShapeBase, ILineScanShape
    {
        FrmLineScanShapeOptions frmLineScanShapeOptions = new FrmLineScanShapeOptions();
        private Bitmap SourceImage { get; set; }

        public LineScanShape()
        {
            InitializeComponent();

            this.BuildOwnContextMenu();
        }

        private void BuildOwnContextMenu()
        {
            this.MergeContextMenuItems(this.cmsLineScan);

            this.toolStripMenuItemOptions.Click += (object sender, EventArgs e) => this.In_GetLineScanCoordinates(this.SourceImage);
        }

        public void In_GetLineScanCoordinates(Bitmap sourceImage)
        {
            this.SourceImage = sourceImage;
            frmLineScanShapeOptions.SetSourceImage(this.SourceImage);
            System.Windows.Forms.DialogResult r = frmLineScanShapeOptions.ShowDialog();

            if (r == System.Windows.Forms.DialogResult.OK)
            {
                this.Out_ScanImage(new LineScanCoordinatesMessage(frmLineScanShapeOptions.Points));
            }
        }

        public event Action<ILineScanCoordinatesMessage> Out_ScanImage;
    }
}