#region Namespaces

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Twainsoft.ImageProcessing.Shapes.Components.Base;
using Twainsoft.ImageProcessing.Shapes.Contracts.Misc;
using Twainsoft.ImageProcessing.Common.Contracts.Vocabulary.Messages;
using Twainsoft.ImageProcessing.Shapes.Components.Forms.Misc;
using System.Drawing;
using Twainsoft.ImageProcessing.Common.Components.Vocabulary.Messages;

#endregion

namespace Twainsoft.ImageProcessing.Shapes.Components.Misc
{
    public partial class ImageCacheShape : ShapeBase, IImageCacheShape
    {
        private List<Bitmap> CachedImages { get; set; }
        private FrmImageCacheShapeOptions.SendCachedImageEventHandler SendCachedImageEventHandler { get; set; }

        public ImageCacheShape()
        {
            InitializeComponent();

            this.CachedImages = new List<Bitmap>();
            this.SendCachedImageEventHandler = new FrmImageCacheShapeOptions.SendCachedImageEventHandler(FrmImageCacheShapeOptions_SendCachedImage);

            this.BuildOwnContextMenu();
        }

        void FrmImageCacheShapeOptions_SendCachedImage(object sender, CachedImageEventArgs e)
        {
            this.Out_SendCachedImage(new CachedImageMessage(e.CachedImage));
        }

        private void BuildOwnContextMenu()
        {
            this.MergeContextMenuItems(this.cmsOptions);

            this.tsmiSavedImages.Click += new EventHandler(tsmiSavedImages_Click);
        }

        void tsmiSavedImages_Click(object sender, EventArgs e)
        {
            FrmImageCacheShapeOptions frmImageCacheShapeOptions = new FrmImageCacheShapeOptions();
            frmImageCacheShapeOptions.SendCachedImage += this.FrmImageCacheShapeOptions_SendCachedImage;
            frmImageCacheShapeOptions.SetCachedImages(this.CachedImages);
            frmImageCacheShapeOptions.ShowDialog();
            frmImageCacheShapeOptions.SendCachedImage -= this.FrmImageCacheShapeOptions_SendCachedImage;
        }

        public void In_CachedImage(ICachedImageMessage cachedImageMessage)
        {
            this.CachedImages.Add(cachedImageMessage.CachedImage);
        }

        public event Action<ICachedImageMessage> Out_SendCachedImage;
    }
}