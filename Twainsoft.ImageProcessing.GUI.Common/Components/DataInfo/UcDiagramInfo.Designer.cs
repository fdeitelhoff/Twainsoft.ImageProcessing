namespace Twainsoft.ImageProcessing.GUI.Common.Components.DataInfo
{
    partial class UcDiagramInfo
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chartDataInfo = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.gbCurrentPositionData = new System.Windows.Forms.GroupBox();
            this.lblPosition = new System.Windows.Forms.Label();
            this.lblYData = new System.Windows.Forms.Label();
            this.tbYData = new System.Windows.Forms.TextBox();
            this.tbXData = new System.Windows.Forms.TextBox();
            this.lblXValue = new System.Windows.Forms.Label();
            this.lblData = new System.Windows.Forms.Label();
            this.tbYPosition = new System.Windows.Forms.TextBox();
            this.lblYPosition = new System.Windows.Forms.Label();
            this.tbXPosition = new System.Windows.Forms.TextBox();
            this.lblXPosition = new System.Windows.Forms.Label();
            this.gbChartZoom = new System.Windows.Forms.GroupBox();
            this.btnResetZoom = new System.Windows.Forms.Button();
            this.cbChartZoomAllowed = new System.Windows.Forms.CheckBox();
            this.gbSaveDiagram = new System.Windows.Forms.GroupBox();
            this.btnCopyDiagam = new System.Windows.Forms.Button();
            this.btnSaveDiagram = new System.Windows.Forms.Button();
            this.sfdDiagram = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.chartDataInfo)).BeginInit();
            this.gbCurrentPositionData.SuspendLayout();
            this.gbChartZoom.SuspendLayout();
            this.gbSaveDiagram.SuspendLayout();
            this.SuspendLayout();
            // 
            // chartDataInfo
            // 
            this.chartDataInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.chartDataInfo.BackColor = System.Drawing.SystemColors.Control;
            chartArea3.AxisX.IsMarginVisible = false;
            chartArea3.AxisX2.IsMarginVisible = false;
            chartArea3.CursorX.IsUserEnabled = true;
            chartArea3.CursorX.IsUserSelectionEnabled = true;
            chartArea3.CursorY.IsUserEnabled = true;
            chartArea3.CursorY.IsUserSelectionEnabled = true;
            chartArea3.Name = "Default";
            this.chartDataInfo.ChartAreas.Add(chartArea3);
            this.chartDataInfo.Location = new System.Drawing.Point(3, 3);
            this.chartDataInfo.Name = "chartDataInfo";
            series3.ChartArea = "Default";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Area;
            series3.CustomProperties = "EmptyPointValue=Zero";
            series3.Name = "Default";
            series3.ToolTip = "X=#VALX; Y=#VAL";
            this.chartDataInfo.Series.Add(series3);
            this.chartDataInfo.Size = new System.Drawing.Size(515, 468);
            this.chartDataInfo.TabIndex = 0;
            this.chartDataInfo.CursorPositionChanged += new System.EventHandler<System.Windows.Forms.DataVisualization.Charting.CursorEventArgs>(this.chartDataInfo_CursorPositionChanged);
            this.chartDataInfo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.chartDataInfo_MouseMove);
            // 
            // gbCurrentPositionData
            // 
            this.gbCurrentPositionData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gbCurrentPositionData.Controls.Add(this.lblPosition);
            this.gbCurrentPositionData.Controls.Add(this.lblYData);
            this.gbCurrentPositionData.Controls.Add(this.tbYData);
            this.gbCurrentPositionData.Controls.Add(this.tbXData);
            this.gbCurrentPositionData.Controls.Add(this.lblXValue);
            this.gbCurrentPositionData.Controls.Add(this.lblData);
            this.gbCurrentPositionData.Controls.Add(this.tbYPosition);
            this.gbCurrentPositionData.Controls.Add(this.lblYPosition);
            this.gbCurrentPositionData.Controls.Add(this.tbXPosition);
            this.gbCurrentPositionData.Controls.Add(this.lblXPosition);
            this.gbCurrentPositionData.Location = new System.Drawing.Point(510, 16);
            this.gbCurrentPositionData.Name = "gbCurrentPositionData";
            this.gbCurrentPositionData.Size = new System.Drawing.Size(173, 166);
            this.gbCurrentPositionData.TabIndex = 1;
            this.gbCurrentPositionData.TabStop = false;
            this.gbCurrentPositionData.Text = "Daten bei aktueller Position";
            // 
            // lblPosition
            // 
            this.lblPosition.AutoSize = true;
            this.lblPosition.Location = new System.Drawing.Point(6, 20);
            this.lblPosition.Name = "lblPosition";
            this.lblPosition.Size = new System.Drawing.Size(47, 13);
            this.lblPosition.TabIndex = 9;
            this.lblPosition.Text = "Position:";
            // 
            // lblYData
            // 
            this.lblYData.AutoSize = true;
            this.lblYData.Location = new System.Drawing.Point(6, 138);
            this.lblYData.Name = "lblYData";
            this.lblYData.Size = new System.Drawing.Size(17, 13);
            this.lblYData.TabIndex = 8;
            this.lblYData.Text = "Y:";
            // 
            // tbYData
            // 
            this.tbYData.Location = new System.Drawing.Point(29, 135);
            this.tbYData.Name = "tbYData";
            this.tbYData.ReadOnly = true;
            this.tbYData.Size = new System.Drawing.Size(138, 20);
            this.tbYData.TabIndex = 7;
            // 
            // tbXData
            // 
            this.tbXData.Location = new System.Drawing.Point(29, 109);
            this.tbXData.Name = "tbXData";
            this.tbXData.ReadOnly = true;
            this.tbXData.Size = new System.Drawing.Size(138, 20);
            this.tbXData.TabIndex = 6;
            // 
            // lblXValue
            // 
            this.lblXValue.AutoSize = true;
            this.lblXValue.Location = new System.Drawing.Point(6, 112);
            this.lblXValue.Name = "lblXValue";
            this.lblXValue.Size = new System.Drawing.Size(17, 13);
            this.lblXValue.TabIndex = 5;
            this.lblXValue.Text = "X:";
            // 
            // lblData
            // 
            this.lblData.AutoSize = true;
            this.lblData.Location = new System.Drawing.Point(6, 90);
            this.lblData.Name = "lblData";
            this.lblData.Size = new System.Drawing.Size(39, 13);
            this.lblData.TabIndex = 4;
            this.lblData.Text = "Daten:";
            // 
            // tbYPosition
            // 
            this.tbYPosition.Location = new System.Drawing.Point(29, 64);
            this.tbYPosition.Name = "tbYPosition";
            this.tbYPosition.ReadOnly = true;
            this.tbYPosition.Size = new System.Drawing.Size(138, 20);
            this.tbYPosition.TabIndex = 3;
            // 
            // lblYPosition
            // 
            this.lblYPosition.AutoSize = true;
            this.lblYPosition.Location = new System.Drawing.Point(6, 67);
            this.lblYPosition.Name = "lblYPosition";
            this.lblYPosition.Size = new System.Drawing.Size(17, 13);
            this.lblYPosition.TabIndex = 2;
            this.lblYPosition.Text = "Y:";
            // 
            // tbXPosition
            // 
            this.tbXPosition.Location = new System.Drawing.Point(29, 38);
            this.tbXPosition.Name = "tbXPosition";
            this.tbXPosition.ReadOnly = true;
            this.tbXPosition.Size = new System.Drawing.Size(138, 20);
            this.tbXPosition.TabIndex = 1;
            // 
            // lblXPosition
            // 
            this.lblXPosition.AutoSize = true;
            this.lblXPosition.Location = new System.Drawing.Point(6, 41);
            this.lblXPosition.Name = "lblXPosition";
            this.lblXPosition.Size = new System.Drawing.Size(17, 13);
            this.lblXPosition.TabIndex = 0;
            this.lblXPosition.Text = "X:";
            // 
            // gbChartZoom
            // 
            this.gbChartZoom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gbChartZoom.Controls.Add(this.btnResetZoom);
            this.gbChartZoom.Controls.Add(this.cbChartZoomAllowed);
            this.gbChartZoom.Location = new System.Drawing.Point(510, 188);
            this.gbChartZoom.Name = "gbChartZoom";
            this.gbChartZoom.Size = new System.Drawing.Size(173, 74);
            this.gbChartZoom.TabIndex = 2;
            this.gbChartZoom.TabStop = false;
            this.gbChartZoom.Text = "Zoom";
            // 
            // btnResetZoom
            // 
            this.btnResetZoom.Location = new System.Drawing.Point(9, 42);
            this.btnResetZoom.Name = "btnResetZoom";
            this.btnResetZoom.Size = new System.Drawing.Size(158, 23);
            this.btnResetZoom.TabIndex = 1;
            this.btnResetZoom.Text = "&Zurücksetzen";
            this.btnResetZoom.UseVisualStyleBackColor = true;
            this.btnResetZoom.Click += new System.EventHandler(this.btnResetZoom_Click);
            // 
            // cbChartZoomAllowed
            // 
            this.cbChartZoomAllowed.AutoSize = true;
            this.cbChartZoomAllowed.Checked = true;
            this.cbChartZoomAllowed.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbChartZoomAllowed.Location = new System.Drawing.Point(9, 19);
            this.cbChartZoomAllowed.Name = "cbChartZoomAllowed";
            this.cbChartZoomAllowed.Size = new System.Drawing.Size(94, 17);
            this.cbChartZoomAllowed.TabIndex = 0;
            this.cbChartZoomAllowed.Text = "Zoom erlaubt?";
            this.cbChartZoomAllowed.UseVisualStyleBackColor = true;
            this.cbChartZoomAllowed.CheckedChanged += new System.EventHandler(this.cbChartZoomAllowed_CheckedChanged);
            // 
            // gbSaveDiagram
            // 
            this.gbSaveDiagram.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gbSaveDiagram.Controls.Add(this.btnCopyDiagam);
            this.gbSaveDiagram.Controls.Add(this.btnSaveDiagram);
            this.gbSaveDiagram.Location = new System.Drawing.Point(510, 268);
            this.gbSaveDiagram.Name = "gbSaveDiagram";
            this.gbSaveDiagram.Size = new System.Drawing.Size(173, 80);
            this.gbSaveDiagram.TabIndex = 3;
            this.gbSaveDiagram.TabStop = false;
            this.gbSaveDiagram.Text = "Speichern && kopieren";
            // 
            // btnCopyDiagam
            // 
            this.btnCopyDiagam.Location = new System.Drawing.Point(9, 48);
            this.btnCopyDiagam.Name = "btnCopyDiagam";
            this.btnCopyDiagam.Size = new System.Drawing.Size(158, 23);
            this.btnCopyDiagam.TabIndex = 1;
            this.btnCopyDiagam.Text = "Diagramm &kopieren";
            this.btnCopyDiagam.UseVisualStyleBackColor = true;
            this.btnCopyDiagam.Click += new System.EventHandler(this.btnCopyDiagam_Click);
            // 
            // btnSaveDiagram
            // 
            this.btnSaveDiagram.Location = new System.Drawing.Point(9, 19);
            this.btnSaveDiagram.Name = "btnSaveDiagram";
            this.btnSaveDiagram.Size = new System.Drawing.Size(158, 23);
            this.btnSaveDiagram.TabIndex = 0;
            this.btnSaveDiagram.Text = "&Diagramm speichern";
            this.btnSaveDiagram.UseVisualStyleBackColor = true;
            this.btnSaveDiagram.Click += new System.EventHandler(this.btnSaveDiagram_Click);
            // 
            // sfdDiagram
            // 
            this.sfdDiagram.Filter = "Bitmap (*.bmp)|*.bmp|JPEG (*.jpg)|*.jpg|EMF (*.emf)|*.emf|PNG (*.png)|*.png|SVG (" +
                "*.svg)|*.svg|GIF (*.gif)|*.gif|TIFF (*.tif)|*.tif";
            this.sfdDiagram.FilterIndex = 2;
            this.sfdDiagram.RestoreDirectory = true;
            this.sfdDiagram.SupportMultiDottedExtensions = true;
            this.sfdDiagram.FileOk += new System.ComponentModel.CancelEventHandler(this.sfdDiagram_FileOk);
            // 
            // UcDiagramInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbSaveDiagram);
            this.Controls.Add(this.gbChartZoom);
            this.Controls.Add(this.gbCurrentPositionData);
            this.Controls.Add(this.chartDataInfo);
            this.Name = "UcDiagramInfo";
            this.Size = new System.Drawing.Size(698, 474);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UcDiagramInfo_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.chartDataInfo)).EndInit();
            this.gbCurrentPositionData.ResumeLayout(false);
            this.gbCurrentPositionData.PerformLayout();
            this.gbChartZoom.ResumeLayout(false);
            this.gbChartZoom.PerformLayout();
            this.gbSaveDiagram.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartDataInfo;
        private System.Windows.Forms.GroupBox gbCurrentPositionData;
        private System.Windows.Forms.TextBox tbYPosition;
        private System.Windows.Forms.Label lblYPosition;
        private System.Windows.Forms.TextBox tbXPosition;
        private System.Windows.Forms.Label lblXPosition;
        private System.Windows.Forms.GroupBox gbChartZoom;
        private System.Windows.Forms.CheckBox cbChartZoomAllowed;
        private System.Windows.Forms.Button btnResetZoom;
        private System.Windows.Forms.TextBox tbXData;
        private System.Windows.Forms.Label lblXValue;
        private System.Windows.Forms.Label lblData;
        private System.Windows.Forms.Label lblYData;
        private System.Windows.Forms.TextBox tbYData;
        private System.Windows.Forms.Label lblPosition;
        private System.Windows.Forms.GroupBox gbSaveDiagram;
        private System.Windows.Forms.Button btnSaveDiagram;
        private System.Windows.Forms.SaveFileDialog sfdDiagram;
        private System.Windows.Forms.Button btnCopyDiagam;
    }
}
