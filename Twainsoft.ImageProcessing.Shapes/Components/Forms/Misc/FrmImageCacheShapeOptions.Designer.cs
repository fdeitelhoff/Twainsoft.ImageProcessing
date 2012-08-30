namespace Twainsoft.ImageProcessing.Shapes.Components.Forms.Misc
{
    partial class FrmImageCacheShapeOptions
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainerImages = new System.Windows.Forms.SplitContainer();
            this.lblImageCountData = new System.Windows.Forms.Label();
            this.lblImageCount = new System.Windows.Forms.Label();
            this.dataGridViewCachedImages = new System.Windows.Forms.DataGridView();
            this.DataGridViewImageColumnImage = new System.Windows.Forms.DataGridViewImageColumn();
            this.pbCachedImage = new System.Windows.Forms.PictureBox();
            this.btnSendImage = new System.Windows.Forms.Button();
            this.btnClearImages = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerImages)).BeginInit();
            this.splitContainerImages.Panel1.SuspendLayout();
            this.splitContainerImages.Panel2.SuspendLayout();
            this.splitContainerImages.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCachedImages)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCachedImage)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(480, 411);
            // 
            // splitContainerImages
            // 
            this.splitContainerImages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainerImages.Location = new System.Drawing.Point(0, 0);
            this.splitContainerImages.Name = "splitContainerImages";
            // 
            // splitContainerImages.Panel1
            // 
            this.splitContainerImages.Panel1.Controls.Add(this.lblImageCountData);
            this.splitContainerImages.Panel1.Controls.Add(this.lblImageCount);
            this.splitContainerImages.Panel1.Controls.Add(this.dataGridViewCachedImages);
            // 
            // splitContainerImages.Panel2
            // 
            this.splitContainerImages.Panel2.Controls.Add(this.pbCachedImage);
            this.splitContainerImages.Size = new System.Drawing.Size(567, 405);
            this.splitContainerImages.SplitterDistance = 157;
            this.splitContainerImages.TabIndex = 1;
            // 
            // lblImageCountData
            // 
            this.lblImageCountData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblImageCountData.AutoSize = true;
            this.lblImageCountData.Location = new System.Drawing.Point(80, 5);
            this.lblImageCountData.Name = "lblImageCountData";
            this.lblImageCountData.Size = new System.Drawing.Size(0, 13);
            this.lblImageCountData.TabIndex = 2;
            // 
            // lblImageCount
            // 
            this.lblImageCount.AutoSize = true;
            this.lblImageCount.Location = new System.Drawing.Point(3, 5);
            this.lblImageCount.Name = "lblImageCount";
            this.lblImageCount.Size = new System.Drawing.Size(71, 13);
            this.lblImageCount.TabIndex = 1;
            this.lblImageCount.Text = "Anzahl Bilder:";
            // 
            // dataGridViewCachedImages
            // 
            this.dataGridViewCachedImages.AllowUserToAddRows = false;
            this.dataGridViewCachedImages.AllowUserToDeleteRows = false;
            this.dataGridViewCachedImages.AllowUserToResizeColumns = false;
            this.dataGridViewCachedImages.AllowUserToResizeRows = false;
            this.dataGridViewCachedImages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewCachedImages.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCachedImages.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DataGridViewImageColumnImage});
            this.dataGridViewCachedImages.Location = new System.Drawing.Point(0, 21);
            this.dataGridViewCachedImages.MultiSelect = false;
            this.dataGridViewCachedImages.Name = "dataGridViewCachedImages";
            this.dataGridViewCachedImages.ReadOnly = true;
            this.dataGridViewCachedImages.RowHeadersVisible = false;
            this.dataGridViewCachedImages.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridViewCachedImages.RowTemplate.Height = 50;
            this.dataGridViewCachedImages.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewCachedImages.Size = new System.Drawing.Size(155, 384);
            this.dataGridViewCachedImages.TabIndex = 0;
            this.dataGridViewCachedImages.SelectionChanged += new System.EventHandler(this.dataGridViewCachedImages_SelectionChanged);
            // 
            // DataGridViewImageColumnImage
            // 
            this.DataGridViewImageColumnImage.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DataGridViewImageColumnImage.HeaderText = "Gespeichertes Bild";
            this.DataGridViewImageColumnImage.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.DataGridViewImageColumnImage.Name = "DataGridViewImageColumnImage";
            this.DataGridViewImageColumnImage.ReadOnly = true;
            // 
            // pbCachedImage
            // 
            this.pbCachedImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbCachedImage.Location = new System.Drawing.Point(0, 0);
            this.pbCachedImage.Name = "pbCachedImage";
            this.pbCachedImage.Size = new System.Drawing.Size(406, 405);
            this.pbCachedImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbCachedImage.TabIndex = 0;
            this.pbCachedImage.TabStop = false;
            // 
            // btnSendImage
            // 
            this.btnSendImage.Enabled = false;
            this.btnSendImage.Location = new System.Drawing.Point(12, 411);
            this.btnSendImage.Name = "btnSendImage";
            this.btnSendImage.Size = new System.Drawing.Size(86, 23);
            this.btnSendImage.TabIndex = 2;
            this.btnSendImage.Text = "&Bild senden";
            this.btnSendImage.UseVisualStyleBackColor = true;
            this.btnSendImage.Click += new System.EventHandler(this.btnSendImage_Click);
            // 
            // btnClearImages
            // 
            this.btnClearImages.Location = new System.Drawing.Point(104, 411);
            this.btnClearImages.Name = "btnClearImages";
            this.btnClearImages.Size = new System.Drawing.Size(88, 23);
            this.btnClearImages.TabIndex = 3;
            this.btnClearImages.Text = "Alles löschen";
            this.btnClearImages.UseVisualStyleBackColor = true;
            this.btnClearImages.Click += new System.EventHandler(this.btnClearImages_Click);
            // 
            // FrmImageCacheShapeOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 446);
            this.Controls.Add(this.splitContainerImages);
            this.Controls.Add(this.btnSendImage);
            this.Controls.Add(this.btnClearImages);
            this.Name = "FrmImageCacheShapeOptions";
            this.Text = "Zwischengespeicherte Bilder";
            this.Controls.SetChildIndex(this.btnClearImages, 0);
            this.Controls.SetChildIndex(this.btnSendImage, 0);
            this.Controls.SetChildIndex(this.splitContainerImages, 0);
            this.Controls.SetChildIndex(this.btnClose, 0);
            this.splitContainerImages.Panel1.ResumeLayout(false);
            this.splitContainerImages.Panel1.PerformLayout();
            this.splitContainerImages.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerImages)).EndInit();
            this.splitContainerImages.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCachedImages)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCachedImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainerImages;
        private System.Windows.Forms.DataGridView dataGridViewCachedImages;
        private System.Windows.Forms.DataGridViewImageColumn DataGridViewImageColumnImage;
        private System.Windows.Forms.PictureBox pbCachedImage;
        private System.Windows.Forms.Button btnSendImage;
        private System.Windows.Forms.Label lblImageCountData;
        private System.Windows.Forms.Label lblImageCount;
        private System.Windows.Forms.Button btnClearImages;
    }
}