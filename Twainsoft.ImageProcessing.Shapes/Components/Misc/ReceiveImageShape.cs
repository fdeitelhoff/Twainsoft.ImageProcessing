#region Namespaces

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Twainsoft.ImageProcessing.Shapes.Components.Base;
using Twainsoft.ImageProcessing.Shapes.Contracts.Misc;

#endregion

namespace Twainsoft.ImageProcessing.Shapes.Components.Misc
{
    public partial class ReceiveImageShape : ShapeBase, IReceiveImageShape
    {
        public ReceiveImageShape()
        {
            InitializeComponent();

            this.IsInputPinEnabled = false;

            this.BuildOwnContextMenu();
        }

        private void BuildOwnContextMenu()
        {
            this.MergeContextMenuItems(this.cmsServiceOptions);

            this.tsmiStartServer.Click += (object sender, EventArgs e) => this.Out_StartService();
        }

        public event Action Out_StartService;

        public void In_ServiceStarted()
        {
            this.tsmiStartServer.Text = "Server gestartet";
            this.tsmiStartServer.Enabled = false;
            this.tsmiStartServer.Checked = true;
        }
    }
}