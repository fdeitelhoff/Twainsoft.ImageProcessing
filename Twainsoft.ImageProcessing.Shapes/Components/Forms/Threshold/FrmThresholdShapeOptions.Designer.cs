namespace Twainsoft.ImageProcessing.Shapes.Components.Forms.Threshold
{
    partial class FrmThresholdShapeOptions
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
            this.dgvThresholds = new System.Windows.Forms.DataGridView();
            this.dataGridViewColumnMin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewColumnMax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewColumnValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbAddThreshold = new System.Windows.Forms.GroupBox();
            this.btnCreateThreshold = new System.Windows.Forms.Button();
            this.lblNewGrayValue = new System.Windows.Forms.Label();
            this.nupGrayValue = new System.Windows.Forms.NumericUpDown();
            this.nupMaxValue = new System.Windows.Forms.NumericUpDown();
            this.lblMaxValue = new System.Windows.Forms.Label();
            this.nupMinValue = new System.Windows.Forms.NumericUpDown();
            this.lblMinValue = new System.Windows.Forms.Label();
            this.btnDeleteThreshold = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThresholds)).BeginInit();
            this.gbAddThreshold.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupGrayValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupMaxValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupMinValue)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(280, 336);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(199, 336);
            // 
            // dgvThresholds
            // 
            this.dgvThresholds.AllowUserToAddRows = false;
            this.dgvThresholds.AllowUserToResizeRows = false;
            this.dgvThresholds.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvThresholds.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvThresholds.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewColumnMin,
            this.dataGridViewColumnMax,
            this.dataGridViewColumnValue});
            this.dgvThresholds.Location = new System.Drawing.Point(0, 0);
            this.dgvThresholds.Name = "dgvThresholds";
            this.dgvThresholds.ReadOnly = true;
            this.dgvThresholds.RowHeadersVisible = false;
            this.dgvThresholds.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvThresholds.Size = new System.Drawing.Size(367, 200);
            this.dgvThresholds.TabIndex = 2;
            this.dgvThresholds.SelectionChanged += new System.EventHandler(this.dgvThresholds_SelectionChanged);
            // 
            // dataGridViewColumnMin
            // 
            this.dataGridViewColumnMin.HeaderText = "Untergrenze";
            this.dataGridViewColumnMin.Name = "dataGridViewColumnMin";
            this.dataGridViewColumnMin.ReadOnly = true;
            // 
            // dataGridViewColumnMax
            // 
            this.dataGridViewColumnMax.HeaderText = "Obergrenze";
            this.dataGridViewColumnMax.Name = "dataGridViewColumnMax";
            this.dataGridViewColumnMax.ReadOnly = true;
            // 
            // dataGridViewColumnValue
            // 
            this.dataGridViewColumnValue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewColumnValue.HeaderText = "Wert";
            this.dataGridViewColumnValue.Name = "dataGridViewColumnValue";
            this.dataGridViewColumnValue.ReadOnly = true;
            // 
            // gbAddThreshold
            // 
            this.gbAddThreshold.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbAddThreshold.Controls.Add(this.btnCreateThreshold);
            this.gbAddThreshold.Controls.Add(this.lblNewGrayValue);
            this.gbAddThreshold.Controls.Add(this.nupGrayValue);
            this.gbAddThreshold.Controls.Add(this.nupMaxValue);
            this.gbAddThreshold.Controls.Add(this.lblMaxValue);
            this.gbAddThreshold.Controls.Add(this.nupMinValue);
            this.gbAddThreshold.Controls.Add(this.lblMinValue);
            this.gbAddThreshold.Location = new System.Drawing.Point(12, 231);
            this.gbAddThreshold.Name = "gbAddThreshold";
            this.gbAddThreshold.Size = new System.Drawing.Size(343, 99);
            this.gbAddThreshold.TabIndex = 3;
            this.gbAddThreshold.TabStop = false;
            this.gbAddThreshold.Text = "Schwellwert hinzufügen";
            // 
            // btnCreateThreshold
            // 
            this.btnCreateThreshold.Location = new System.Drawing.Point(217, 42);
            this.btnCreateThreshold.Name = "btnCreateThreshold";
            this.btnCreateThreshold.Size = new System.Drawing.Size(75, 23);
            this.btnCreateThreshold.TabIndex = 6;
            this.btnCreateThreshold.Text = "Anlegen";
            this.btnCreateThreshold.UseVisualStyleBackColor = true;
            this.btnCreateThreshold.Click += new System.EventHandler(this.btnCreateThreshold_Click);
            // 
            // lblNewGrayValue
            // 
            this.lblNewGrayValue.AutoSize = true;
            this.lblNewGrayValue.Location = new System.Drawing.Point(6, 73);
            this.lblNewGrayValue.Name = "lblNewGrayValue";
            this.lblNewGrayValue.Size = new System.Drawing.Size(53, 13);
            this.lblNewGrayValue.TabIndex = 5;
            this.lblNewGrayValue.Text = "Grauwert:";
            // 
            // nupGrayValue
            // 
            this.nupGrayValue.Location = new System.Drawing.Point(80, 71);
            this.nupGrayValue.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nupGrayValue.Name = "nupGrayValue";
            this.nupGrayValue.Size = new System.Drawing.Size(78, 20);
            this.nupGrayValue.TabIndex = 4;
            // 
            // nupMaxValue
            // 
            this.nupMaxValue.Location = new System.Drawing.Point(80, 45);
            this.nupMaxValue.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nupMaxValue.Name = "nupMaxValue";
            this.nupMaxValue.Size = new System.Drawing.Size(78, 20);
            this.nupMaxValue.TabIndex = 3;
            // 
            // lblMaxValue
            // 
            this.lblMaxValue.AutoSize = true;
            this.lblMaxValue.Location = new System.Drawing.Point(6, 47);
            this.lblMaxValue.Name = "lblMaxValue";
            this.lblMaxValue.Size = new System.Drawing.Size(65, 13);
            this.lblMaxValue.TabIndex = 2;
            this.lblMaxValue.Text = "Obergrenze:";
            // 
            // nupMinValue
            // 
            this.nupMinValue.Location = new System.Drawing.Point(80, 19);
            this.nupMinValue.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nupMinValue.Name = "nupMinValue";
            this.nupMinValue.Size = new System.Drawing.Size(78, 20);
            this.nupMinValue.TabIndex = 1;
            // 
            // lblMinValue
            // 
            this.lblMinValue.AutoSize = true;
            this.lblMinValue.Location = new System.Drawing.Point(6, 21);
            this.lblMinValue.Name = "lblMinValue";
            this.lblMinValue.Size = new System.Drawing.Size(68, 13);
            this.lblMinValue.TabIndex = 0;
            this.lblMinValue.Text = "Untergrenze:";
            // 
            // btnDeleteThreshold
            // 
            this.btnDeleteThreshold.Enabled = false;
            this.btnDeleteThreshold.Location = new System.Drawing.Point(280, 206);
            this.btnDeleteThreshold.Name = "btnDeleteThreshold";
            this.btnDeleteThreshold.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteThreshold.TabIndex = 4;
            this.btnDeleteThreshold.Text = "Entfernen";
            this.btnDeleteThreshold.UseVisualStyleBackColor = true;
            this.btnDeleteThreshold.Click += new System.EventHandler(this.btnDeleteThreshold_Click);
            // 
            // FrmThresholdShapeOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(367, 371);
            this.Controls.Add(this.dgvThresholds);
            this.Controls.Add(this.gbAddThreshold);
            this.Controls.Add(this.btnDeleteThreshold);
            this.Name = "FrmThresholdShapeOptions";
            this.Text = "Schwellwerte";
            this.Controls.SetChildIndex(this.btnDeleteThreshold, 0);
            this.Controls.SetChildIndex(this.gbAddThreshold, 0);
            this.Controls.SetChildIndex(this.dgvThresholds, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.btnOK, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgvThresholds)).EndInit();
            this.gbAddThreshold.ResumeLayout(false);
            this.gbAddThreshold.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupGrayValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupMaxValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupMinValue)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvThresholds;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewColumnMin;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewColumnMax;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewColumnValue;
        private System.Windows.Forms.GroupBox gbAddThreshold;
        private System.Windows.Forms.Label lblNewGrayValue;
        private System.Windows.Forms.NumericUpDown nupGrayValue;
        private System.Windows.Forms.NumericUpDown nupMaxValue;
        private System.Windows.Forms.Label lblMaxValue;
        private System.Windows.Forms.NumericUpDown nupMinValue;
        private System.Windows.Forms.Label lblMinValue;
        private System.Windows.Forms.Button btnCreateThreshold;
        private System.Windows.Forms.Button btnDeleteThreshold;
    }
}