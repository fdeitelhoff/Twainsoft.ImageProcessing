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

#endregion

namespace Twainsoft.ImageProcessing.GUI.Forms.Toolboxes
{
    public partial class FrmToolboxEBCErrors : FrmToolboxBase, IFrmToolboxEBCErrors
    {
        public FrmToolboxEBCErrors(Form owner)
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
            this.dataGridViewErrors.Rows.Clear();
        }

        public void In_EBCWorkExceptionHandled(IEBCExceptionMessage ebcExceptionMessage)
        {
            this.dataGridViewErrors.Rows.Add(new object[] { 
                ebcExceptionMessage.EBC.Name,
                ebcExceptionMessage.WorkException.Message,
                ebcExceptionMessage.WorkException.InnerException });
        }
    }
}