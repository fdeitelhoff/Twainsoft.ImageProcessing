#region Namespaces

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Twainsoft.ImageProcessing.Shapes.Contracts.Scan;
using Twainsoft.ImageProcessing.Shapes.Components.Forms;
using System.Windows.Forms;
using System.Drawing;
using Twainsoft.ImageProcessing.Shapes.Contracts.Vocabulary.Messages;
using Twainsoft.ImageProcessing.Shapes.Components.Vocabulary.Messages;
using Twainsoft.ImageProcessing.Shapes.Components.Base;

#endregion

namespace Twainsoft.ImageProcessing.Shapes.Components.Scan
{
    public partial class EllipseScanShape : ShapeBase, IEllipseScanShape
    {
        private FrmEllipseScanShapeOptions FrmEllipseScanShapeOptions { get; set; }
        private Bitmap SourceImage { get; set; }

        public EllipseScanShape()
        {
            InitializeComponent();

            this.FrmEllipseScanShapeOptions = new FrmEllipseScanShapeOptions();

            this.BuildOwnContextMenu();
        }

        private void BuildOwnContextMenu()
        {
            this.MergeContextMenuItems(this.cmsOptions);

            this.tsmiOptions.Click += (object sender, EventArgs e) => this.In_GetEllipseScanCoordinates(this.SourceImage);
        }

        public void In_GetEllipseScanCoordinates(Bitmap sourceImage)
        {
            this.SourceImage = sourceImage;

            this.FrmEllipseScanShapeOptions.SetSourceImage(this.SourceImage);

            if (this.FrmEllipseScanShapeOptions.ShowDialog() == DialogResult.OK)
            {
                this.Out_ScanImage(this.FrmEllipseScanShapeOptions.GetEllipseScanCoordinatesMessage());
            }
        }

        public event Action<IEllipseScanCoordinatesMessage> Out_ScanImage;
    }
}