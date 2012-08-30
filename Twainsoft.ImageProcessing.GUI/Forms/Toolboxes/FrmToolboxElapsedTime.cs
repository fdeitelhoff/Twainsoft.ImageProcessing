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

#endregion

namespace Twainsoft.ImageProcessing.GUI.Forms.Toolboxes
{
    public partial class FrmToolboxElapsedTime : FrmToolboxBase, IFrmToolboxElapsedTime
    {
        public FrmToolboxElapsedTime(Form owner)
            : base(owner)
        {
            InitializeComponent();

            this.BuildOwnToolStripMenu();
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
            this.dataGridViewElapsedTime.Rows.Clear();
        }

        public void In_ElapsedTime(IEBCExecutionTimeData ebcExecutionTimeData)
        {
            if (ebcExecutionTimeData != null)
            {
                this.dataGridViewElapsedTime.Rows.Add(new object[] {
                    ebcExecutionTimeData.EBC.Name,
                    ebcExecutionTimeData.UsedMilliseconds,
                    ebcExecutionTimeData.EndTime.ToString(@"hh\:mm\:ss") + " Uhr" });
            }
        }
    }
}