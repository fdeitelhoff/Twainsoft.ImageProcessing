#region Namespaces

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

#endregion

namespace Twainsoft.ImageProcessing.GUI.Base
{
    public partial class FrmToolboxBase : Form
    {
        private bool HideOnClose { get; set; }

        public FrmToolboxBase()
        {
            InitializeComponent();

            this.HideOnClose = true;
        }

        public FrmToolboxBase(Form owner)
            : this()
        {
            this.Owner = owner;
        }

        private void FrmToolboxBase_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.HideOnClose)
            {
                e.Cancel = true;

                this.Hide();
            }
        }

        private void toolStripButtonTopMost_Click(object sender, EventArgs e)
        {
            this.toolStripButtonTopMost.Checked = !this.toolStripButtonTopMost.Checked;

            this.TopMost = this.toolStripButtonTopMost.Checked;
        }

        public void CloseToolbox()
        {
            this.HideOnClose = false;

            this.Close();
        }
    }
}