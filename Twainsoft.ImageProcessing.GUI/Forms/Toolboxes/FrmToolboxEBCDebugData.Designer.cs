namespace Twainsoft.ImageProcessing.GUI.Forms.Toolboxes
{
    partial class FrmToolboxEBCDebugData
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
            this.dataGridViewDebugData = new System.Windows.Forms.DataGridView();
            this.DataGridViewTextBoxColumnEBC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataGridViewImageColumnFirstSourceImage = new System.Windows.Forms.DataGridViewImageColumn();
            this.DataGridViewTextBoxColumnSourceImagesCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataGridViewImageColumnResultingImage = new System.Windows.Forms.DataGridViewImageColumn();
            this.DataGridViewImageColumnData = new System.Windows.Forms.DataGridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDebugData)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewDebugData
            // 
            this.dataGridViewDebugData.AllowUserToAddRows = false;
            this.dataGridViewDebugData.AllowUserToDeleteRows = false;
            this.dataGridViewDebugData.AllowUserToResizeRows = false;
            this.dataGridViewDebugData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDebugData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DataGridViewTextBoxColumnEBC,
            this.DataGridViewImageColumnFirstSourceImage,
            this.DataGridViewTextBoxColumnSourceImagesCount,
            this.DataGridViewImageColumnResultingImage,
            this.DataGridViewImageColumnData});
            this.dataGridViewDebugData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewDebugData.Location = new System.Drawing.Point(0, 25);
            this.dataGridViewDebugData.MultiSelect = false;
            this.dataGridViewDebugData.Name = "dataGridViewDebugData";
            this.dataGridViewDebugData.ReadOnly = true;
            this.dataGridViewDebugData.RowHeadersVisible = false;
            this.dataGridViewDebugData.RowTemplate.Height = 75;
            this.dataGridViewDebugData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewDebugData.ShowCellErrors = false;
            this.dataGridViewDebugData.ShowCellToolTips = false;
            this.dataGridViewDebugData.ShowEditingIcon = false;
            this.dataGridViewDebugData.ShowRowErrors = false;
            this.dataGridViewDebugData.Size = new System.Drawing.Size(470, 352);
            this.dataGridViewDebugData.TabIndex = 1;
            // 
            // DataGridViewTextBoxColumnEBC
            // 
            this.DataGridViewTextBoxColumnEBC.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.DataGridViewTextBoxColumnEBC.HeaderText = "EBC";
            this.DataGridViewTextBoxColumnEBC.Name = "DataGridViewTextBoxColumnEBC";
            this.DataGridViewTextBoxColumnEBC.ReadOnly = true;
            this.DataGridViewTextBoxColumnEBC.Width = 53;
            // 
            // DataGridViewImageColumnFirstSourceImage
            // 
            this.DataGridViewImageColumnFirstSourceImage.HeaderText = "1. Quellbild";
            this.DataGridViewImageColumnFirstSourceImage.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.DataGridViewImageColumnFirstSourceImage.Name = "DataGridViewImageColumnFirstSourceImage";
            this.DataGridViewImageColumnFirstSourceImage.ReadOnly = true;
            // 
            // DataGridViewTextBoxColumnSourceImagesCount
            // 
            this.DataGridViewTextBoxColumnSourceImagesCount.HeaderText = "# Quellbilder";
            this.DataGridViewTextBoxColumnSourceImagesCount.Name = "DataGridViewTextBoxColumnSourceImagesCount";
            this.DataGridViewTextBoxColumnSourceImagesCount.ReadOnly = true;
            // 
            // DataGridViewImageColumnResultingImage
            // 
            this.DataGridViewImageColumnResultingImage.HeaderText = "Ergebnisbild";
            this.DataGridViewImageColumnResultingImage.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.DataGridViewImageColumnResultingImage.Name = "DataGridViewImageColumnResultingImage";
            this.DataGridViewImageColumnResultingImage.ReadOnly = true;
            // 
            // DataGridViewImageColumnData
            // 
            this.DataGridViewImageColumnData.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DataGridViewImageColumnData.HeaderText = "Diagramm";
            this.DataGridViewImageColumnData.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.DataGridViewImageColumnData.Name = "DataGridViewImageColumnData";
            this.DataGridViewImageColumnData.ReadOnly = true;
            this.DataGridViewImageColumnData.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridViewImageColumnData.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // FrmToolboxEBCDebugData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 377);
            this.Controls.Add(this.dataGridViewDebugData);
            this.Name = "FrmToolboxEBCDebugData";
            this.Text = "Debugdaten";
            this.Controls.SetChildIndex(this.dataGridViewDebugData, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDebugData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewDebugData;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataGridViewTextBoxColumnEBC;
        private System.Windows.Forms.DataGridViewImageColumn DataGridViewImageColumnFirstSourceImage;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataGridViewTextBoxColumnSourceImagesCount;
        private System.Windows.Forms.DataGridViewImageColumn DataGridViewImageColumnResultingImage;
        private System.Windows.Forms.DataGridViewImageColumn DataGridViewImageColumnData;
    }
}