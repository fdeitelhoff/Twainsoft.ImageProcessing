namespace Twainsoft.ImageProcessing.Shapes.Components.Forms
{
    partial class FrmShapeDebugData
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
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.dataGridViewDebugMessages = new System.Windows.Forms.DataGridView();
            this.DataGridViewTextBoxColumnEBCName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControlDebugData = new System.Windows.Forms.TabControl();
            this.btnClearData = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDebugMessages)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(468, 460);
            // 
            // splitContainer
            // 
            this.splitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.dataGridViewDebugMessages);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.tabControlDebugData);
            this.splitContainer.Size = new System.Drawing.Size(555, 454);
            this.splitContainer.SplitterDistance = 141;
            this.splitContainer.TabIndex = 1;
            // 
            // dataGridViewDebugMessages
            // 
            this.dataGridViewDebugMessages.AllowUserToAddRows = false;
            this.dataGridViewDebugMessages.AllowUserToDeleteRows = false;
            this.dataGridViewDebugMessages.AllowUserToResizeRows = false;
            this.dataGridViewDebugMessages.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDebugMessages.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DataGridViewTextBoxColumnEBCName});
            this.dataGridViewDebugMessages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewDebugMessages.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewDebugMessages.MultiSelect = false;
            this.dataGridViewDebugMessages.Name = "dataGridViewDebugMessages";
            this.dataGridViewDebugMessages.ReadOnly = true;
            this.dataGridViewDebugMessages.RowHeadersVisible = false;
            this.dataGridViewDebugMessages.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewDebugMessages.ShowCellErrors = false;
            this.dataGridViewDebugMessages.ShowCellToolTips = false;
            this.dataGridViewDebugMessages.ShowEditingIcon = false;
            this.dataGridViewDebugMessages.ShowRowErrors = false;
            this.dataGridViewDebugMessages.Size = new System.Drawing.Size(555, 141);
            this.dataGridViewDebugMessages.TabIndex = 0;
            this.dataGridViewDebugMessages.SelectionChanged += new System.EventHandler(this.dataGridViewDebugMessages_SelectionChanged);
            // 
            // DataGridViewTextBoxColumnEBCName
            // 
            this.DataGridViewTextBoxColumnEBCName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.DataGridViewTextBoxColumnEBCName.HeaderText = "EBC";
            this.DataGridViewTextBoxColumnEBCName.Name = "DataGridViewTextBoxColumnEBCName";
            this.DataGridViewTextBoxColumnEBCName.ReadOnly = true;
            this.DataGridViewTextBoxColumnEBCName.Width = 53;
            // 
            // tabControlDebugData
            // 
            this.tabControlDebugData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlDebugData.Location = new System.Drawing.Point(0, 0);
            this.tabControlDebugData.Name = "tabControlDebugData";
            this.tabControlDebugData.SelectedIndex = 0;
            this.tabControlDebugData.Size = new System.Drawing.Size(555, 309);
            this.tabControlDebugData.TabIndex = 0;
            // 
            // btnClearData
            // 
            this.btnClearData.Location = new System.Drawing.Point(12, 460);
            this.btnClearData.Name = "btnClearData";
            this.btnClearData.Size = new System.Drawing.Size(114, 23);
            this.btnClearData.TabIndex = 2;
            this.btnClearData.Text = "Daten löschen";
            this.btnClearData.UseVisualStyleBackColor = true;
            this.btnClearData.Click += new System.EventHandler(this.btnClearData_Click);
            // 
            // FrmShapeDebugData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(555, 495);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.btnClearData);
            this.Name = "FrmShapeDebugData";
            this.Text = "Debug-Daten";
            this.Controls.SetChildIndex(this.btnClearData, 0);
            this.Controls.SetChildIndex(this.splitContainer, 0);
            this.Controls.SetChildIndex(this.btnClose, 0);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDebugMessages)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.DataGridView dataGridViewDebugMessages;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataGridViewTextBoxColumnEBCName;
        private System.Windows.Forms.TabControl tabControlDebugData;
        private System.Windows.Forms.Button btnClearData;
    }
}