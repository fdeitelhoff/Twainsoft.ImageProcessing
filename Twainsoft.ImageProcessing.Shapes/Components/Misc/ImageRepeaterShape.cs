#region Namespaces

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Twainsoft.ImageProcessing.Shapes.Components.Base;
using Twainsoft.ImageProcessing.Shapes.Contracts.Misc;
using Twainsoft.ImageProcessing.Common.Contracts.Vocabulary.Messages;
using System.Windows.Forms;
using Twainsoft.ImageProcessing.Common.Components.Vocabulary.Messages;

#endregion

namespace Twainsoft.ImageProcessing.Shapes.Components.Misc
{
    public partial class ImageRepeaterShape : ShapeBase, IImageRepeaterShape
    {
        public ImageRepeaterShape()
        {
            InitializeComponent();

            this.BuildOwnContextMenu();
        }

        private void BuildOwnContextMenu()
        {
            this.MergeContextMenuItems(this.cmsRepeaterOptions);

            this.tsmiRepeatCount.TextChanged += new EventHandler(tsmiRepeatCount_TextChanged);
            this.tsmiRepeatCount.KeyDown += new System.Windows.Forms.KeyEventHandler(tsmiRepeatCount_KeyDown);
            this.tsmiRepeatCount.GotFocus += new EventHandler(tsmiRepeatCount_GotFocus);
        }

        void tsmiRepeatCount_GotFocus(object sender, EventArgs e)
        {
            if (this.tsmiRepeatCount.Text == "Wiederholungen")
            {
                this.tsmiRepeatCount.Text = "";
            }
        }

        void tsmiRepeatCount_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.RepeatCountChanged();
            }
        }

        void tsmiRepeatCount_TextChanged(object sender, EventArgs e)
        {
            this.RepeatCountChanged();
        }

        private void RepeatCountChanged()
        {
            string repeatCountText = this.tsmiRepeatCount.Text;
            int repeatCount = 1;

            if (!String.IsNullOrWhiteSpace(repeatCountText))
            {
                if (!Int32.TryParse(repeatCountText, out repeatCount))
                {
                    repeatCount = 1;
                    this.tsmiRepeatCount.Text = "1";
                }
                else if (repeatCount < 1)
                {
                    repeatCount = 1;
                    this.tsmiRepeatCount.Text = "1";
                }
            }
            else
            {
                this.tsmiRepeatCount.Text = "1";
            }

            this.tsmiRepeatCount.Text = repeatCount.ToString();

            this.Out_RepeatCountChanged(new RepeatCountChangedMessage(repeatCount));
        }

        public event Action<IRepeatCountChangedMessage> Out_RepeatCountChanged;
    }
}