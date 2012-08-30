namespace Twainsoft.ImageProcessing.GUI.Forms.Toolboxes
{
    partial class FrmToolboxEBCErrors
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
            this.dataGridViewErrors = new System.Windows.Forms.DataGridView();
            this.DataGridViewTextBoxColumnEBCName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataGridViewTextBoxColumnMessage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataGridViewTextBoxColumnInnerException = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewErrors)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewErrors
            // 
            this.dataGridViewErrors.AllowUserToAddRows = false;
            this.dataGridViewErrors.AllowUserToDeleteRows = false;
            this.dataGridViewErrors.AllowUserToResizeRows = false;
            this.dataGridViewErrors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewErrors.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DataGridViewTextBoxColumnEBCName,
            this.DataGridViewTextBoxColumnMessage,
            this.DataGridViewTextBoxColumnInnerException});
            this.dataGridViewErrors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewErrors.Location = new System.Drawing.Point(0, 25);
            this.dataGridViewErrors.Name = "dataGridViewErrors";
            this.dataGridViewErrors.ReadOnly = true;
            this.dataGridViewErrors.RowHeadersVisible = false;
            this.dataGridViewErrors.Size = new System.Drawing.Size(377, 398);
            this.dataGridViewErrors.TabIndex = 1;
            // 
            // DataGridViewTextBoxColumnEBCName
            // 
            this.DataGridViewTextBoxColumnEBCName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.DataGridViewTextBoxColumnEBCName.HeaderText = "EBC";
            this.DataGridViewTextBoxColumnEBCName.Name = "DataGridViewTextBoxColumnEBCName";
            this.DataGridViewTextBoxColumnEBCName.ReadOnly = true;
            this.DataGridViewTextBoxColumnEBCName.Width = 53;
            // 
            // DataGridViewTextBoxColumnMessage
            // 
            this.DataGridViewTextBoxColumnMessage.HeaderText = "Meldung";
            this.DataGridViewTextBoxColumnMessage.Name = "DataGridViewTextBoxColumnMessage";
            this.DataGridViewTextBoxColumnMessage.ReadOnly = true;
            // 
            // DataGridViewTextBoxColumnInnerException
            // 
            this.DataGridViewTextBoxColumnInnerException.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DataGridViewTextBoxColumnInnerException.HeaderText = "InnerException";
            this.DataGridViewTextBoxColumnInnerException.Name = "DataGridViewTextBoxColumnInnerException";
            this.DataGridViewTextBoxColumnInnerException.ReadOnly = true;
            // 
            // FrmToolboxEBCErrors
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(377, 423);
            this.Controls.Add(this.dataGridViewErrors);
            this.Name = "FrmToolboxEBCErrors";
            this.Text = "Fehlermeldungen";
            this.Controls.SetChildIndex(this.dataGridViewErrors, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewErrors)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewErrors;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataGridViewTextBoxColumnEBCName;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataGridViewTextBoxColumnMessage;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataGridViewTextBoxColumnInnerException;
    }
}