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

namespace Twainsoft.ImageProcessing.Shapes.Components.Forms.Misc
{
    public partial class FrmImageCacheShapeOptions : FrmShapeWindowBase
    {
        private List<Bitmap> CachedImages { get; set; }

        public delegate void SendCachedImageEventHandler(object sender, CachedImageEventArgs e);
        public event SendCachedImageEventHandler SendCachedImage;

        public FrmImageCacheShapeOptions()
        {
            InitializeComponent();
        }

        private void dataGridViewCachedImages_SelectionChanged(object sender, EventArgs e)
        {
            if (this.dataGridViewCachedImages.SelectedRows.Count == 1)
            {
                this.pbCachedImage.Image = this.CachedImages[this.dataGridViewCachedImages.SelectedRows[0].Index];
            }

            this.btnSendImage.Enabled = this.dataGridViewCachedImages.SelectedRows.Count == 1;
        }

        private void btnSendImage_Click(object sender, EventArgs e)
        {
            this.SendCachedImage(this, new CachedImageEventArgs(this.pbCachedImage.Image as Bitmap));
        }

        public void SetCachedImages(List<Bitmap> cachedImages)
        {
            this.CachedImages = cachedImages;

            foreach (var cachedImage in this.CachedImages)
            {
                this.dataGridViewCachedImages.Rows.Add(new object[] {
                    cachedImage,
                });
            }

            this.lblImageCountData.Text = this.CachedImages.Count.ToString();
        }

        private void btnClearImages_Click(object sender, EventArgs e)
        {
            this.dataGridViewCachedImages.Rows.Clear();
            this.CachedImages.Clear();

            this.lblImageCountData.Text = this.CachedImages.Count.ToString();
        }
    }
}