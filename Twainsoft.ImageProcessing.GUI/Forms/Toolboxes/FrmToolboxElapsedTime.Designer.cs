namespace Twainsoft.ImageProcessing.GUI.Forms.Toolboxes
{
    partial class FrmToolboxElapsedTime
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
            this.dataGridViewElapsedTime = new System.Windows.Forms.DataGridView();
            this.DataGridViewTextBoxColumnEBCName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataGridViewTextBoxColumnTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataGridViewTextBoxColumnEndTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewElapsedTime)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewElapsedTime
            // 
            this.dataGridViewElapsedTime.AllowUserToAddRows = false;
            this.dataGridViewElapsedTime.AllowUserToDeleteRows = false;
            this.dataGridViewElapsedTime.AllowUserToResizeColumns = false;
            this.dataGridViewElapsedTime.AllowUserToResizeRows = false;
            this.dataGridViewElapsedTime.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewElapsedTime.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DataGridViewTextBoxColumnEBCName,
            this.DataGridViewTextBoxColumnTime,
            this.DataGridViewTextBoxColumnEndTime});
            this.dataGridViewElapsedTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewElapsedTime.Location = new System.Drawing.Point(0, 25);
            this.dataGridViewElapsedTime.Name = "dataGridViewElapsedTime";
            this.dataGridViewElapsedTime.RowHeadersVisible = false;
            this.dataGridViewElapsedTime.RowTemplate.ReadOnly = true;
            this.dataGridViewElapsedTime.Size = new System.Drawing.Size(325, 352);
            this.dataGridViewElapsedTime.TabIndex = 1;
            // 
            // DataGridViewTextBoxColumnEBCName
            // 
            this.DataGridViewTextBoxColumnEBCName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.DataGridViewTextBoxColumnEBCName.HeaderText = "EBC";
            this.DataGridViewTextBoxColumnEBCName.Name = "DataGridViewTextBoxColumnEBCName";
            this.DataGridViewTextBoxColumnEBCName.Width = 53;
            // 
            // DataGridViewTextBoxColumnTime
            // 
            this.DataGridViewTextBoxColumnTime.HeaderText = "Dauer";
            this.DataGridViewTextBoxColumnTime.Name = "DataGridViewTextBoxColumnTime";
            // 
            // DataGridViewTextBoxColumnEndTime
            // 
            this.DataGridViewTextBoxColumnEndTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DataGridViewTextBoxColumnEndTime.HeaderText = "Ende";
            this.DataGridViewTextBoxColumnEndTime.Name = "DataGridViewTextBoxColumnEndTime";
            // 
            // FrmToolboxElapsedTime
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(325, 377);
            this.Controls.Add(this.dataGridViewElapsedTime);
            this.Name = "FrmToolboxElapsedTime";
            this.Text = "Benötigte Zeit";
            this.Controls.SetChildIndex(this.dataGridViewElapsedTime, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewElapsedTime)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewElapsedTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataGridViewTextBoxColumnEBCName;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataGridViewTextBoxColumnTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataGridViewTextBoxColumnEndTime;
    }
}