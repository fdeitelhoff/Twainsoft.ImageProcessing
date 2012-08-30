namespace Twainsoft.ImageProcessing.GUI.Forms
{
    partial class FrmMain
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
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shapesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.outputDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.debugDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.elapsedTimeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.errorMessagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.infoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ucPaintLeaf = new Twainsoft.ImageProcessing.GUI.Controls.PaintLeaf.UcPaintLeaf();
            this.menuStripMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStripMain
            // 
            this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewToolStripMenuItem,
            this.infoToolStripMenuItem});
            this.menuStripMain.Location = new System.Drawing.Point(0, 0);
            this.menuStripMain.Name = "menuStripMain";
            this.menuStripMain.Size = new System.Drawing.Size(851, 24);
            this.menuStripMain.TabIndex = 1;
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.shapesToolStripMenuItem,
            this.outputDataToolStripMenuItem,
            this.debugDataToolStripMenuItem,
            this.elapsedTimeToolStripMenuItem,
            this.errorMessagesToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "&View";
            this.viewToolStripMenuItem.DropDownOpening += new System.EventHandler(this.viewToolStripMenuItem_DropDownOpening);
            // 
            // shapesToolStripMenuItem
            // 
            this.shapesToolStripMenuItem.Name = "shapesToolStripMenuItem";
            this.shapesToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.shapesToolStripMenuItem.Text = "&Shapes";
            this.shapesToolStripMenuItem.Click += new System.EventHandler(this.shapesToolStripMenuItem_Click);
            // 
            // outputDataToolStripMenuItem
            // 
            this.outputDataToolStripMenuItem.Name = "outputDataToolStripMenuItem";
            this.outputDataToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.outputDataToolStripMenuItem.Text = "&Ergebnisdaten";
            this.outputDataToolStripMenuItem.Click += new System.EventHandler(this.outputDataToolStripMenuItem_Click);
            // 
            // debugDataToolStripMenuItem
            // 
            this.debugDataToolStripMenuItem.Name = "debugDataToolStripMenuItem";
            this.debugDataToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.debugDataToolStripMenuItem.Text = "&Debugdaten";
            this.debugDataToolStripMenuItem.Click += new System.EventHandler(this.debugDataToolStripMenuItem_Click);
            // 
            // elapsedTimeToolStripMenuItem
            // 
            this.elapsedTimeToolStripMenuItem.Name = "elapsedTimeToolStripMenuItem";
            this.elapsedTimeToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.elapsedTimeToolStripMenuItem.Text = "Verstriche &Zeit";
            this.elapsedTimeToolStripMenuItem.Click += new System.EventHandler(this.elapsedTimeToolStripMenuItem_Click);
            // 
            // errorMessagesToolStripMenuItem
            // 
            this.errorMessagesToolStripMenuItem.Name = "errorMessagesToolStripMenuItem";
            this.errorMessagesToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.errorMessagesToolStripMenuItem.Text = "&Fehlermeldungen";
            this.errorMessagesToolStripMenuItem.Click += new System.EventHandler(this.errorMessagesToolStripMenuItem_Click);
            // 
            // infoToolStripMenuItem
            // 
            this.infoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.infoToolStripMenuItem.Name = "infoToolStripMenuItem";
            this.infoToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.infoToolStripMenuItem.Text = "&Info";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.aboutToolStripMenuItem.Text = "&About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // ucPaintLeaf
            // 
            this.ucPaintLeaf.BackColor = System.Drawing.Color.White;
            this.ucPaintLeaf.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucPaintLeaf.Location = new System.Drawing.Point(0, 24);
            this.ucPaintLeaf.Name = "ucPaintLeaf";
            this.ucPaintLeaf.Size = new System.Drawing.Size(851, 594);
            this.ucPaintLeaf.TabIndex = 2;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(851, 618);
            this.Controls.Add(this.ucPaintLeaf);
            this.Controls.Add(this.menuStripMain);
            this.DoubleBuffered = true;
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStripMain;
            this.Name = "FrmMain";
            this.Text = "ImageProcessing Workflow Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmMain_KeyDown);
            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStripMain;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem outputDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem elapsedTimeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem shapesToolStripMenuItem;
        private Controls.PaintLeaf.UcPaintLeaf ucPaintLeaf;
        private System.Windows.Forms.ToolStripMenuItem errorMessagesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem debugDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem infoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;


    }
}