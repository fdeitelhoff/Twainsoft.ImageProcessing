namespace Twainsoft.ImageProcessing.Shapes.Components.Misc
{
    partial class ReceiveImageShape
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
            this.cmsServiceOptions = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiStartServer = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsServiceOptions.SuspendLayout();
            // 
            // cmsServiceOptions
            // 
            this.cmsServiceOptions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.tsmiStartServer});
            this.cmsServiceOptions.Name = "cmsServiceOptions";
            this.cmsServiceOptions.Size = new System.Drawing.Size(146, 32);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(142, 6);
            // 
            // tsmiStartServer
            // 
            this.tsmiStartServer.Name = "tsmiStartServer";
            this.tsmiStartServer.Size = new System.Drawing.Size(145, 22);
            this.tsmiStartServer.Text = "Server starten";
            this.cmsServiceOptions.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip cmsServiceOptions;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsmiStartServer;
    }
}
