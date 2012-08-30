namespace Twainsoft.ImageProcessing.Shapes.Components.Forms
{
    partial class FrmLineScanShapeOptions
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
            this.ucLineScanSelection = new Twainsoft.ImageProcessing.Shapes.Components.Forms.Controls.UcLineScanSelection();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(229, 309);
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(148, 309);
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // ucLineScanSelection
            // 
            this.ucLineScanSelection.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ucLineScanSelection.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ucLineScanSelection.Location = new System.Drawing.Point(12, 12);
            this.ucLineScanSelection.Name = "ucLineScanSelection";
            this.ucLineScanSelection.Size = new System.Drawing.Size(290, 291);
            this.ucLineScanSelection.TabIndex = 2;
            // 
            // FrmLineScanShapeOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(316, 344);
            this.Controls.Add(this.ucLineScanSelection);
            this.Name = "FrmLineScanShapeOptions";
            this.Text = "Line-Scan erstellen";
            this.Controls.SetChildIndex(this.ucLineScanSelection, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.btnOK, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.UcLineScanSelection ucLineScanSelection;

    }
}