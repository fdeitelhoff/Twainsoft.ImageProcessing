namespace Twainsoft.ImageProcessing.GUI.Forms.Toolboxes
{
    partial class FrmToolboxEBCOutputData
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
            this.dataGridViewOutputData = new System.Windows.Forms.DataGridView();
            this.DataGridViewTextBoxColumnType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataGridViewTextBoxColumnEBCName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataGridViewImageColumnResultingImage = new System.Windows.Forms.DataGridViewImageColumn();
            this.DataGridViewImageColumnDiagram = new System.Windows.Forms.DataGridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOutputData)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewOutputData
            // 
            this.dataGridViewOutputData.AllowUserToAddRows = false;
            this.dataGridViewOutputData.AllowUserToResizeColumns = false;
            this.dataGridViewOutputData.AllowUserToResizeRows = false;
            this.dataGridViewOutputData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOutputData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DataGridViewTextBoxColumnType,
            this.DataGridViewTextBoxColumnEBCName,
            this.DataGridViewImageColumnResultingImage,
            this.DataGridViewImageColumnDiagram});
            this.dataGridViewOutputData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewOutputData.Location = new System.Drawing.Point(0, 25);
            this.dataGridViewOutputData.MultiSelect = false;
            this.dataGridViewOutputData.Name = "dataGridViewOutputData";
            this.dataGridViewOutputData.ReadOnly = true;
            this.dataGridViewOutputData.RowHeadersVisible = false;
            this.dataGridViewOutputData.RowTemplate.Height = 75;
            this.dataGridViewOutputData.RowTemplate.ReadOnly = true;
            this.dataGridViewOutputData.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewOutputData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewOutputData.Size = new System.Drawing.Size(340, 475);
            this.dataGridViewOutputData.TabIndex = 1;
            this.dataGridViewOutputData.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView_CellMouseDoubleClick);
            // 
            // DataGridViewTextBoxColumnType
            // 
            this.DataGridViewTextBoxColumnType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.DataGridViewTextBoxColumnType.HeaderText = "Typ";
            this.DataGridViewTextBoxColumnType.Name = "DataGridViewTextBoxColumnType";
            this.DataGridViewTextBoxColumnType.ReadOnly = true;
            this.DataGridViewTextBoxColumnType.Width = 50;
            // 
            // DataGridViewTextBoxColumnEBCName
            // 
            this.DataGridViewTextBoxColumnEBCName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.DataGridViewTextBoxColumnEBCName.HeaderText = "EBC";
            this.DataGridViewTextBoxColumnEBCName.Name = "DataGridViewTextBoxColumnEBCName";
            this.DataGridViewTextBoxColumnEBCName.ReadOnly = true;
            this.DataGridViewTextBoxColumnEBCName.Width = 53;
            // 
            // DataGridViewImageColumnResultingImage
            // 
            this.DataGridViewImageColumnResultingImage.HeaderText = "Ergebnisbild";
            this.DataGridViewImageColumnResultingImage.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.DataGridViewImageColumnResultingImage.Name = "DataGridViewImageColumnResultingImage";
            this.DataGridViewImageColumnResultingImage.ReadOnly = true;
            // 
            // DataGridViewImageColumnDiagram
            // 
            this.DataGridViewImageColumnDiagram.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DataGridViewImageColumnDiagram.HeaderText = "Diagramm";
            this.DataGridViewImageColumnDiagram.Name = "DataGridViewImageColumnDiagram";
            this.DataGridViewImageColumnDiagram.ReadOnly = true;
            this.DataGridViewImageColumnDiagram.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridViewImageColumnDiagram.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // FrmToolboxEBCOutputData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(340, 500);
            this.Controls.Add(this.dataGridViewOutputData);
            this.Name = "FrmToolboxEBCOutputData";
            this.Text = "Ergebnisdaten";
            this.Controls.SetChildIndex(this.dataGridViewOutputData, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOutputData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewOutputData;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataGridViewTextBoxColumnType;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataGridViewTextBoxColumnEBCName;
        private System.Windows.Forms.DataGridViewImageColumn DataGridViewImageColumnResultingImage;
        private System.Windows.Forms.DataGridViewImageColumn DataGridViewImageColumnDiagram;

    }
}