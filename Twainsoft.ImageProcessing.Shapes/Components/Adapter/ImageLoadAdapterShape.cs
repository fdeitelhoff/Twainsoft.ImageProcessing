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
using Twainsoft.ImageProcessing.Shapes.Components.Forms.Adapter;
using Twainsoft.ImageProcessing.Common.Components.Vocabulary.Data;
using Twainsoft.ImageProcessing.Shapes.Contracts.Vocabulary.Messages;
using Twainsoft.ImageProcessing.Common.Contracts.Vocabulary.Messages;
using Twainsoft.ImageProcessing.Common.Components.Vocabulary.Messages;

#endregion

namespace Twainsoft.ImageProcessing.Shapes.Components.Adapter
{
    public partial class ImageLoadAdapterShape : ShapeBase, IImageLoadAdapterShape
    {
        public ImageLoadAdapterShape()
            : base()
        {
            InitializeComponent();

            this.BuildOwnContextMenu();

            this.openFileDialogImage.FileOk += (object obj, CancelEventArgs cancelEventArgs) => this.Out_LoadImage(this.openFileDialogImage.FileName);
        }

        private void BuildOwnContextMenu()
        {
            this.MergeContextMenuItems(this.cmsLoad);

            this.tsmiLoadImage.Click += (object sender, EventArgs e) => this.In_GetFileName();
        }

        public event Action<string> Out_LoadImage;

        public void In_GetFileName()
        {
            this.openFileDialogImage.ShowDialog();
        }
    }
}