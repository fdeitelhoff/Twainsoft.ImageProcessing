namespace Twainsoft.ImageProcessing.GUI.Forms.DataInfos
{
    partial class FrmDiagramInfo
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
            this.ucDiagramInfo = new Twainsoft.ImageProcessing.GUI.Common.Components.DataInfo.UcDiagramInfo();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(541, 437);
            // 
            // ucDiagramInfo
            // 
            this.ucDiagramInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucDiagramInfo.Location = new System.Drawing.Point(0, 0);
            this.ucDiagramInfo.Name = "ucDiagramInfo";
            this.ucDiagramInfo.Size = new System.Drawing.Size(628, 472);
            this.ucDiagramInfo.TabIndex = 1;
            // 
            // FrmDiagramInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(628, 472);
            this.Controls.Add(this.ucDiagramInfo);
            this.Name = "FrmDiagramInfo";
            this.Text = "Diagramm-Info";
            this.Controls.SetChildIndex(this.ucDiagramInfo, 0);
            this.Controls.SetChildIndex(this.btnClose, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private Common.Components.DataInfo.UcDiagramInfo ucDiagramInfo;

    }
}