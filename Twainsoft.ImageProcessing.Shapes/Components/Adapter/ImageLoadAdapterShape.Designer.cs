namespace Twainsoft.ImageProcessing.Shapes.Components.Adapter
{
    partial class ImageLoadAdapterShape
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.cmsLoad = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiLoadImage = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialogImage = new System.Windows.Forms.OpenFileDialog();
            this.cmsLoad.SuspendLayout();
            // 
            // cmsLoad
            // 
            this.cmsLoad.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator,
            this.tsmiLoadImage});
            this.cmsLoad.Name = "cmsLoad";
            this.cmsLoad.Size = new System.Drawing.Size(163, 54);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(159, 6);
            // 
            // tsmiLoadImage
            // 
            this.tsmiLoadImage.Name = "tsmiLoadImage";
            this.tsmiLoadImage.Size = new System.Drawing.Size(162, 22);
            this.tsmiLoadImage.Text = "Bild laden";
            // 
            // openFileDialogImage
            // 
            this.openFileDialogImage.Title = "Bild laden";
            this.cmsLoad.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip cmsLoad;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripMenuItem tsmiLoadImage;
        private System.Windows.Forms.OpenFileDialog openFileDialogImage;
    }
}
