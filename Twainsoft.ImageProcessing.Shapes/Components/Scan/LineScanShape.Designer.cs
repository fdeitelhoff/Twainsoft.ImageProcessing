namespace Twainsoft.ImageProcessing.Shapes.Components.Scan
{
    partial class LineScanShape
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
            this.cmsLineScan = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsLineScan.SuspendLayout();
            // 
            // cmsLineScan
            // 
            this.cmsLineScan.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemOptions});
            this.cmsLineScan.Name = "cmsLineScan";
            this.cmsLineScan.Size = new System.Drawing.Size(125, 26);
            // 
            // toolStripMenuItemOptions
            // 
            this.toolStripMenuItemOptions.Name = "toolStripMenuItemOptions";
            this.toolStripMenuItemOptions.Size = new System.Drawing.Size(124, 22);
            this.toolStripMenuItemOptions.Text = "Optionen";
            this.cmsLineScan.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip cmsLineScan;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemOptions;
    }
}
