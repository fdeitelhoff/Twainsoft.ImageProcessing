namespace Twainsoft.ImageProcessing.GUI.Base
{
    partial class FrmToolboxBase
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmToolboxBase));
            this.toolStripMain = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonTopMost = new System.Windows.Forms.ToolStripButton();
            this.toolStripMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripMain
            // 
            this.toolStripMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonTopMost});
            this.toolStripMain.Location = new System.Drawing.Point(0, 0);
            this.toolStripMain.Name = "toolStripMain";
            this.toolStripMain.Size = new System.Drawing.Size(325, 25);
            this.toolStripMain.TabIndex = 0;
            // 
            // toolStripButtonTopMost
            // 
            this.toolStripButtonTopMost.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButtonTopMost.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonTopMost.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonTopMost.Image")));
            this.toolStripButtonTopMost.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonTopMost.Name = "toolStripButtonTopMost";
            this.toolStripButtonTopMost.Size = new System.Drawing.Size(62, 22);
            this.toolStripButtonTopMost.Text = "Top most";
            this.toolStripButtonTopMost.Click += new System.EventHandler(this.toolStripButtonTopMost_Click);
            // 
            // FrmToolboxBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(325, 377);
            this.Controls.Add(this.toolStripMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "FrmToolboxBase";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmToolboxBase";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmToolboxBase_FormClosing);
            this.toolStripMain.ResumeLayout(false);
            this.toolStripMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripButton toolStripButtonTopMost;
        protected System.Windows.Forms.ToolStrip toolStripMain;
    }
}