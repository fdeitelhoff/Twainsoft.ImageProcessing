namespace Twainsoft.ImageProcessing.Shapes.Components.Base
{
    partial class ShapeBase
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
            this.cmsMain = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiStart = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiShowError = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiShowDebugData = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiProtocolOutputData = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiProtocolDebugData = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiProtocolBoth = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiChangeInputPinStatus = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiChangeOutputPinStatus = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiChangeBothPinStatus = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiImageType = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsMain.SuspendLayout();
            // 
            // cmsMain
            // 
            this.cmsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiStart,
            this.toolStripSeparator1,
            this.tsmiShowError,
            this.toolStripSeparator2,
            this.tsmiShowDebugData,
            this.toolStripSeparator3,
            this.tsmiProtocolOutputData,
            this.tsmiProtocolDebugData,
            this.tsmiProtocolBoth,
            this.toolStripSeparator4,
            this.tsmiChangeInputPinStatus,
            this.tsmiChangeOutputPinStatus,
            this.tsmiChangeBothPinStatus,
            this.toolStripSeparator5,
            this.tsmiImageType});
            this.cmsMain.Name = "cmsMain";
            this.cmsMain.Size = new System.Drawing.Size(227, 254);
            this.cmsMain.Opening += new System.ComponentModel.CancelEventHandler(this.cmsMain_Opening);
            // 
            // tsmiStart
            // 
            this.tsmiStart.Name = "tsmiStart";
            this.tsmiStart.Size = new System.Drawing.Size(226, 22);
            this.tsmiStart.Text = "Start";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(223, 6);
            // 
            // tsmiShowError
            // 
            this.tsmiShowError.Name = "tsmiShowError";
            this.tsmiShowError.Size = new System.Drawing.Size(226, 22);
            this.tsmiShowError.Text = "Fehler anzeigen";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(223, 6);
            // 
            // tsmiShowDebugData
            // 
            this.tsmiShowDebugData.Name = "tsmiShowDebugData";
            this.tsmiShowDebugData.Size = new System.Drawing.Size(226, 22);
            this.tsmiShowDebugData.Text = "Debugdaten anzeigen";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(223, 6);
            // 
            // tsmiProtocolOutputData
            // 
            this.tsmiProtocolOutputData.Checked = true;
            this.tsmiProtocolOutputData.CheckOnClick = true;
            this.tsmiProtocolOutputData.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsmiProtocolOutputData.Name = "tsmiProtocolOutputData";
            this.tsmiProtocolOutputData.Size = new System.Drawing.Size(226, 22);
            this.tsmiProtocolOutputData.Text = "Ergebnisdaten protokollieren";
            // 
            // tsmiProtocolDebugData
            // 
            this.tsmiProtocolDebugData.Checked = true;
            this.tsmiProtocolDebugData.CheckOnClick = true;
            this.tsmiProtocolDebugData.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsmiProtocolDebugData.Name = "tsmiProtocolDebugData";
            this.tsmiProtocolDebugData.Size = new System.Drawing.Size(226, 22);
            this.tsmiProtocolDebugData.Text = "Debugdaten protokollieren";
            // 
            // tsmiProtocolBoth
            // 
            this.tsmiProtocolBoth.Checked = true;
            this.tsmiProtocolBoth.CheckOnClick = true;
            this.tsmiProtocolBoth.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsmiProtocolBoth.Name = "tsmiProtocolBoth";
            this.tsmiProtocolBoth.Size = new System.Drawing.Size(226, 22);
            this.tsmiProtocolBoth.Text = "Beides protokollieren";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(223, 6);
            // 
            // tsmiChangeInputPinStatus
            // 
            this.tsmiChangeInputPinStatus.Checked = true;
            this.tsmiChangeInputPinStatus.CheckOnClick = true;
            this.tsmiChangeInputPinStatus.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsmiChangeInputPinStatus.Name = "tsmiChangeInputPinStatus";
            this.tsmiChangeInputPinStatus.Size = new System.Drawing.Size(226, 22);
            this.tsmiChangeInputPinStatus.Text = "Eingang aktiv";
            // 
            // tsmiChangeOutputPinStatus
            // 
            this.tsmiChangeOutputPinStatus.Checked = true;
            this.tsmiChangeOutputPinStatus.CheckOnClick = true;
            this.tsmiChangeOutputPinStatus.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsmiChangeOutputPinStatus.Name = "tsmiChangeOutputPinStatus";
            this.tsmiChangeOutputPinStatus.Size = new System.Drawing.Size(226, 22);
            this.tsmiChangeOutputPinStatus.Text = "Ausgang aktiv";
            // 
            // tsmiChangeBothPinStatus
            // 
            this.tsmiChangeBothPinStatus.Checked = true;
            this.tsmiChangeBothPinStatus.CheckOnClick = true;
            this.tsmiChangeBothPinStatus.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsmiChangeBothPinStatus.Name = "tsmiChangeBothPinStatus";
            this.tsmiChangeBothPinStatus.Size = new System.Drawing.Size(226, 22);
            this.tsmiChangeBothPinStatus.Text = "Beide aktiv";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(223, 6);
            // 
            // tsmiImageType
            // 
            this.tsmiImageType.Name = "tsmiImageType";
            this.tsmiImageType.Size = new System.Drawing.Size(226, 22);
            this.tsmiImageType.Text = "Bildtyp festlegen";
            this.cmsMain.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip cmsMain;
        private System.Windows.Forms.ToolStripMenuItem tsmiStart;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsmiShowError;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem tsmiChangeInputPinStatus;
        private System.Windows.Forms.ToolStripMenuItem tsmiChangeOutputPinStatus;
        private System.Windows.Forms.ToolStripMenuItem tsmiChangeBothPinStatus;
        private System.Windows.Forms.ToolStripMenuItem tsmiShowDebugData;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem tsmiProtocolOutputData;
        private System.Windows.Forms.ToolStripMenuItem tsmiProtocolDebugData;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem tsmiProtocolBoth;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem tsmiImageType;
    }
}
