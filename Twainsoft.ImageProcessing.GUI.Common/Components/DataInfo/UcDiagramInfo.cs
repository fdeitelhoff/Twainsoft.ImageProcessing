#region Namespaces

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.IO;
using System.Drawing.Imaging;

#endregion

namespace Twainsoft.ImageProcessing.GUI.Common.Components.DataInfo
{
    public partial class UcDiagramInfo : UserControl
    {
        private DataPoint LastDataPoint { get; set; }

        public UcDiagramInfo()
        {
            InitializeComponent();
        }

        public UcDiagramInfo(object data)
            : this()
        {
            this.PopulateData(data);
        }

        public void PopulateData(object data)
        {
            Array dataArray = data as Array;

            if (dataArray == null)
            {
                return;
            }

            // Copy the Y-Values to a new array of type double.
            double[] yValues = new double[dataArray.Length];
            dataArray.CopyTo(yValues, 0);

            // Create an own Y-Value array, so we can bind the chart against it.
            double[] xValues = new double[dataArray.Length];
            for (int i = 0; i < xValues.Length; i++)
            {
                xValues[i] = i;
            }

            this.chartDataInfo.Series["Default"].Points.DataBindXY(xValues, yValues);
        }

        private void cbChartZoomAllowed_CheckedChanged(object sender, EventArgs e)
        {
            this.chartDataInfo.ChartAreas["Default"].AxisX.ScaleView.Zoomable = this.cbChartZoomAllowed.Checked;
            this.chartDataInfo.ChartAreas["Default"].AxisY.ScaleView.Zoomable = this.cbChartZoomAllowed.Checked;

            if (!this.cbChartZoomAllowed.Checked)
            {
                this.ResetZoom();
            }
        }

        private void btnResetZoom_Click(object sender, EventArgs e)
        {
            this.ResetZoom();
        }

        private void ResetZoom()
        {
            this.chartDataInfo.ChartAreas["Default"].AxisX.ScaleView.ZoomReset(0);
            this.chartDataInfo.ChartAreas["Default"].AxisY.ScaleView.ZoomReset(0);
        }

        private void chartDataInfo_MouseMove(object sender, MouseEventArgs e)
        {
            HitTestResult result = this.chartDataInfo.HitTest(e.X, e.Y);
            
            if (this.LastDataPoint != null)
            {
                this.LastDataPoint.BackSecondaryColor = Color.Black;
                this.LastDataPoint.BackHatchStyle = ChartHatchStyle.None;
                this.LastDataPoint.BorderWidth = 1;
            }

            if (result.ChartElementType == ChartElementType.DataPoint)
            {
                DataPoint dataPoint = this.chartDataInfo.Series[0].Points[result.PointIndex];
                
                dataPoint.BackSecondaryColor = Color.White;
                dataPoint.BackHatchStyle = ChartHatchStyle.Percent25;

                this.LastDataPoint = dataPoint;
            }

        }

        private void chartDataInfo_CursorPositionChanged(object sender, CursorEventArgs e)
        {
            this.SetPosition(e.Axis, e.NewPosition);
        }

        private void SetPosition(Axis axis, double position)
        {
            if (double.IsNaN(position))
            {
                return;
            }

            if (axis.AxisName == AxisName.X)
            {
                this.tbXPosition.Text = position.ToString();
                this.tbXData.Text = this.chartDataInfo.Series["Default"].Points[(int)position].YValues[0].ToString();
            }
            else
            {
                this.tbYPosition.Text = position.ToString();
                this.tbYData.Text = position.ToString();
            }
        }

        private void UcDiagramInfo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.S && e.Control)
            {
                this.SaveDiagram();
            }
            else if (e.KeyCode == Keys.C && e.Control)
            {
                this.CopyDiagram();
            }
        }

        private void CopyDiagram()
        {
            // create a memory stream to save the chart image    
            MemoryStream stream = new MemoryStream();

            // save the chart image to the stream    
            this.chartDataInfo.SaveImage(stream, ImageFormat.Bmp);

            // create a bitmap using the stream    
            Bitmap bmp = new Bitmap(stream);

            // save the bitmap to the clipboard    
            Clipboard.SetDataObject(bmp); 
        }

        private void btnSaveDiagram_Click(object sender, EventArgs e)
        {
            this.sfdDiagram.ShowDialog();
        }

        private void sfdDiagram_FileOk(object sender, CancelEventArgs e)
        {
            this.SaveDiagram();
        }

        private void SaveDiagram()
        {
            ChartImageFormat format = ChartImageFormat.Bmp;

            if (this.sfdDiagram.FileName.EndsWith("bmp"))
            {
                format = ChartImageFormat.Bmp;
            }
            else if (this.sfdDiagram.FileName.EndsWith("jpg"))
            {
                format = ChartImageFormat.Jpeg;
            }
            else if (this.sfdDiagram.FileName.EndsWith("emf"))
            {
                format = ChartImageFormat.Emf;
            }
            else if (this.sfdDiagram.FileName.EndsWith("gif"))
            {
                format = ChartImageFormat.Gif;
            }
            else if (this.sfdDiagram.FileName.EndsWith("png"))
            {
                format = ChartImageFormat.Png;
            }
            else if (this.sfdDiagram.FileName.EndsWith("tif"))
            {
                format = ChartImageFormat.Tiff;
            }

            // Save image with the specified format.
            this.chartDataInfo.SaveImage(this.sfdDiagram.FileName, format);
        }

        private void btnCopyDiagam_Click(object sender, EventArgs e)
        {
            this.CopyDiagram();
        }
    }
}