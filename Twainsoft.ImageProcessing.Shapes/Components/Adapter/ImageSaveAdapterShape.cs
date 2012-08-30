#region Namespaces

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Twainsoft.ImageProcessing.Shapes.Contracts.Adapter;
using Twainsoft.ImageProcessing.Shapes.Components.Base;

#endregion

namespace Twainsoft.ImageProcessing.Shapes.Components.Adapter
{
    public partial class ImageSaveAdapterShape : ShapeBase, IImageSaveAdapterShape
    {
        public ImageSaveAdapterShape()
            : base()
        {
            InitializeComponent();
            
            this.Name = "Bild speichern";

            this.BuildOwnContextMenu();

            this.saveFileDialogImage.FileOk += (object s, CancelEventArgs cancelEventArgs) => this.Out_SaveImage(this.saveFileDialogImage.FileName);
        }

        private void BuildOwnContextMenu()
        {
            this.MergeContextMenuItems(this.cmsSave);

            this.tsmiSaveImage.Click += (object sender, EventArgs e) => this.In_GetFileName();
        }

        public void In_GetFileName()
        {
            this.saveFileDialogImage.ShowDialog();
        }

        public event Action<string> Out_SaveImage;
    }
}