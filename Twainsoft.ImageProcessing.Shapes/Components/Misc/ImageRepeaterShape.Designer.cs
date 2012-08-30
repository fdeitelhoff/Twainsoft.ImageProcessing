namespace Twainsoft.ImageProcessing.Shapes.Components.Misc
{
    partial class ImageRepeaterShape
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
            this.cmsRepeaterOptions = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiRepeatCount = new System.Windows.Forms.ToolStripTextBox();
            this.cmsRepeaterOptions.SuspendLayout();
            // 
            // cmsRepeaterOptions
            // 
            this.cmsRepeaterOptions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.tsmiRepeatCount});
            this.cmsRepeaterOptions.Name = "cmsRepeaterOptions";
            this.cmsRepeaterOptions.Size = new System.Drawing.Size(161, 35);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(157, 6);
            // 
            // tsmiRepeatCount
            // 
            this.tsmiRepeatCount.Name = "tsmiRepeatCount";
            this.tsmiRepeatCount.Size = new System.Drawing.Size(100, 23);
            this.tsmiRepeatCount.Text = "Wiederholungen";
            this.cmsRepeaterOptions.ResumeLayout(false);
            this.cmsRepeaterOptions.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip cmsRepeaterOptions;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripTextBox tsmiRepeatCount;
    }
}
