#region Namespaces

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Twainsoft.ImageProcessing.GUI.Base;
using Twainsoft.ImageProcessing.GUI.Contracts;
using Twainsoft.ImageProcessing.EBC.Contracts.Vocabulary.Data;
using Twainsoft.ImageProcessing.GUI.Properties;
using Twainsoft.ImageProcessing.GUI.Forms.DataInfos;
using Twainsoft.ImageProcessing.Common.Components.Vocabulary.Data;
using Twainsoft.ImageProcessing.EBC.Components.Vocabulary.Data;

#endregion

namespace Twainsoft.ImageProcessing.GUI.Forms.Toolboxes
{
    public partial class FrmToolboxEBCOutputData : FrmToolboxBase, IFrmToolboxEBCData
    {
        private Bitmap EmptyImage { get; set; }
        private Dictionary<int, IEBCOutputData> RowToEBCOutputData { get; set; }

        public FrmToolboxEBCOutputData(Form owner)
            : base(owner)
        {
            InitializeComponent();

            this.BuildOwnToolStripMenu();

            this.EmptyImage = new Bitmap(1, 1);

            this.RowToEBCOutputData = new Dictionary<int, IEBCOutputData>();
        }

        private void BuildOwnToolStripMenu()
        {
            ToolStripButton toolStripButtonClear = new ToolStripButton(Resources.ClearAll);
            toolStripButtonClear.ToolTipText = "Alles löschen";
            toolStripButtonClear.Click += new EventHandler(toolStripButtonClear_Click);

            this.toolStripMain.Items.Add(toolStripButtonClear);
        }

        void toolStripButtonClear_Click(object sender, EventArgs e)
        {
            this.dataGridViewOutputData.Rows.Clear();
            this.RowToEBCOutputData.Clear();
        }

        public void In_OutputData(IEBCOutputData ebcOutputData)        
        {
            if (ebcOutputData != null)
            {
                IEBCMessageData ebcMessageData = ebcOutputData.EBCMessageData;

                int rowIndex = this.dataGridViewOutputData.Rows.Add(new object[] { 
                this.GetOutputDataTypeName(ebcOutputData.EBCOutputDataType),
                ebcOutputData.EBC.Name,
                ebcMessageData.Image,
                ebcMessageData.HasData ? Resources.Diagram : this.EmptyImage });

                this.RowToEBCOutputData.Add(rowIndex, ebcOutputData);
            }
        }

        private object GetOutputDataTypeName(EBCOutputDataTypes eBCOutputDataTypes)
        {
            switch (eBCOutputDataTypes)
            {
                case EBCOutputDataTypes.Debug:
                    return "Debug";
                case EBCOutputDataTypes.Result:
                    return "Ergebnis";
                default:
                    return "Unknown";
            }
        }

        private void dataGridView_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string columnHeaderText = this.dataGridViewOutputData.Columns[e.ColumnIndex].HeaderText;

            if (columnHeaderText == "Diagramm")
            {
                IEBCOutputData ebcOutputData = this.RowToEBCOutputData[e.RowIndex];

                if (ebcOutputData.EBCMessageData.HasData)
                {
                    FrmDiagramInfo frmDiagramInfo = new FrmDiagramInfo();
                    frmDiagramInfo.SetOutputData(ebcOutputData);
                    frmDiagramInfo.Show();
                }
            }
        }
    }
}