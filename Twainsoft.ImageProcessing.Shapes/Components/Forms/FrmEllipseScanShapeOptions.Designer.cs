namespace Twainsoft.ImageProcessing.Shapes.Components.Forms
{
    partial class FrmEllipseScanShapeOptions
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
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.lblEllipseCenter = new System.Windows.Forms.Label();
            this.tbEllipseCenter = new System.Windows.Forms.TextBox();
            this.lblEllipseWidth = new System.Windows.Forms.Label();
            this.nudEllipseWidth = new System.Windows.Forms.NumericUpDown();
            this.nudEllipseHeight = new System.Windows.Forms.NumericUpDown();
            this.lblEllipseHeight = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudEllipseWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudEllipseHeight)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(355, 272);
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(274, 272);
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pictureBox.Location = new System.Drawing.Point(12, 12);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(250, 250);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox.TabIndex = 2;
            this.pictureBox.TabStop = false;
            this.pictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox_Paint);
            this.pictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseDown);
            this.pictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseMove);
            this.pictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseUp);
            // 
            // lblEllipseCenter
            // 
            this.lblEllipseCenter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEllipseCenter.AutoSize = true;
            this.lblEllipseCenter.Location = new System.Drawing.Point(273, 12);
            this.lblEllipseCenter.Name = "lblEllipseCenter";
            this.lblEllipseCenter.Size = new System.Drawing.Size(62, 13);
            this.lblEllipseCenter.TabIndex = 3;
            this.lblEllipseCenter.Text = "Mittelpunkt:";
            // 
            // tbEllipseCenter
            // 
            this.tbEllipseCenter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbEllipseCenter.Location = new System.Drawing.Point(341, 9);
            this.tbEllipseCenter.Name = "tbEllipseCenter";
            this.tbEllipseCenter.ReadOnly = true;
            this.tbEllipseCenter.Size = new System.Drawing.Size(89, 20);
            this.tbEllipseCenter.TabIndex = 4;
            // 
            // lblEllipseWidth
            // 
            this.lblEllipseWidth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEllipseWidth.AutoSize = true;
            this.lblEllipseWidth.Location = new System.Drawing.Point(273, 37);
            this.lblEllipseWidth.Name = "lblEllipseWidth";
            this.lblEllipseWidth.Size = new System.Drawing.Size(37, 13);
            this.lblEllipseWidth.TabIndex = 5;
            this.lblEllipseWidth.Text = "Breite:";
            // 
            // nudEllipseWidth
            // 
            this.nudEllipseWidth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nudEllipseWidth.Location = new System.Drawing.Point(341, 35);
            this.nudEllipseWidth.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.nudEllipseWidth.Name = "nudEllipseWidth";
            this.nudEllipseWidth.Size = new System.Drawing.Size(89, 20);
            this.nudEllipseWidth.TabIndex = 6;
            this.nudEllipseWidth.ThousandsSeparator = true;
            this.nudEllipseWidth.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nudEllipseWidth.ValueChanged += new System.EventHandler(this.nudEllipseWidth_ValueChanged);
            // 
            // nudEllipseHeight
            // 
            this.nudEllipseHeight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nudEllipseHeight.Location = new System.Drawing.Point(341, 61);
            this.nudEllipseHeight.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.nudEllipseHeight.Name = "nudEllipseHeight";
            this.nudEllipseHeight.Size = new System.Drawing.Size(89, 20);
            this.nudEllipseHeight.TabIndex = 7;
            this.nudEllipseHeight.ThousandsSeparator = true;
            this.nudEllipseHeight.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nudEllipseHeight.ValueChanged += new System.EventHandler(this.nudEllipseHeight_ValueChanged);
            // 
            // lblEllipseHeight
            // 
            this.lblEllipseHeight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEllipseHeight.AutoSize = true;
            this.lblEllipseHeight.Location = new System.Drawing.Point(273, 63);
            this.lblEllipseHeight.Name = "lblEllipseHeight";
            this.lblEllipseHeight.Size = new System.Drawing.Size(36, 13);
            this.lblEllipseHeight.TabIndex = 8;
            this.lblEllipseHeight.Text = "Höhe:";
            // 
            // FrmEllipseScanShapeOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(442, 307);
            this.Controls.Add(this.lblEllipseHeight);
            this.Controls.Add(this.nudEllipseHeight);
            this.Controls.Add(this.nudEllipseWidth);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.lblEllipseCenter);
            this.Controls.Add(this.lblEllipseWidth);
            this.Controls.Add(this.tbEllipseCenter);
            this.Name = "FrmEllipseScanShapeOptions";
            this.Text = "Elliptischen Scan erstellen";
            this.Controls.SetChildIndex(this.tbEllipseCenter, 0);
            this.Controls.SetChildIndex(this.lblEllipseWidth, 0);
            this.Controls.SetChildIndex(this.lblEllipseCenter, 0);
            this.Controls.SetChildIndex(this.pictureBox, 0);
            this.Controls.SetChildIndex(this.nudEllipseWidth, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.btnOK, 0);
            this.Controls.SetChildIndex(this.nudEllipseHeight, 0);
            this.Controls.SetChildIndex(this.lblEllipseHeight, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudEllipseWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudEllipseHeight)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Label lblEllipseCenter;
        private System.Windows.Forms.TextBox tbEllipseCenter;
        private System.Windows.Forms.Label lblEllipseWidth;
        private System.Windows.Forms.NumericUpDown nudEllipseWidth;
        private System.Windows.Forms.NumericUpDown nudEllipseHeight;
        private System.Windows.Forms.Label lblEllipseHeight;
    }
}