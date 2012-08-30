namespace Twainsoft.ImageProcessing.Shapes.Components.Adapter
{
    partial class ImageSaveAdapterShape
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
            this.cmsSave = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiSaveImage = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialogImage = new System.Windows.Forms.SaveFileDialog();
            this.cmsSave.SuspendLayout();
            // 
            // cmsSave
            // 
            this.cmsSave.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator,
            this.tsmiSaveImage});
            this.cmsSave.Name = "cmsSave";
            this.cmsSave.Size = new System.Drawing.Size(149, 26);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(6, 6);
            // 
            // tsmiSaveImage
            // 
            this.tsmiSaveImage.Name = "tsmiSaveImage";
            this.tsmiSaveImage.Size = new System.Drawing.Size(148, 22);
            this.tsmiSaveImage.Text = "Bild speichern";
            // 
            // saveFileDialogImage
            // 
            this.saveFileDialogImage.Title = "Bild speichern";
            this.cmsSave.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip cmsSave;
        private System.Windows.Forms.ToolStripMenuItem tsmiSaveImage;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.SaveFileDialog saveFileDialogImage;
    }
}
