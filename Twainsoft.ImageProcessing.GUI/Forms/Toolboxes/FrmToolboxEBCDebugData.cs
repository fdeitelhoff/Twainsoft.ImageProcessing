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
using Twainsoft.ImageProcessing.EBC.Contracts.Vocabulary.Messages;
using Twainsoft.ImageProcessing.GUI.Properties;
using Twainsoft.ImageProcessing.Common.Contracts.Vocabulary.Data;

#endregion

namespace Twainsoft.ImageProcessing.GUI.Forms.Toolboxes
{
    public partial class FrmToolboxEBCDebugData : FrmToolboxBase, IFrmToolboxEBCDebugData
    {
        private Bitmap EmptyImage { get; set; }

        public FrmToolboxEBCDebugData(Form owner)
            : base(owner)
        {
            InitializeComponent();

            this.BuildOwnToolStripMenu();

            this.EmptyImage = new Bitmap(1, 1);
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
            this.dataGridViewDebugData.Rows.Clear();
        }

        public void In_EBCDebugMessage(IEBCDebugMessage ebcDebugMessage)
        {
            if (ebcDebugMessage != null)
            {
                IDebugData debugData = ebcDebugMessage.DebugData;

                this.dataGridViewDebugData.Rows.Add(new object[] { 
                    ebcDebugMessage.EBC.Name,
                    debugData.HasSourceImages ? debugData.SourceImages[0] : this.EmptyImage,
                    debugData.SourceImages.Count,
                    debugData.ResultingImage,
                    debugData.HasData ? Resources.Diagram : this.EmptyImage });
            }
        }
    }
}