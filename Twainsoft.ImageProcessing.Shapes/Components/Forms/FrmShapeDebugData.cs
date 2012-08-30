#region Namespaces

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Twainsoft.ImageProcessing.Common.Contracts.Vocabulary.Messages;
using Twainsoft.ImageProcessing.GUI.Common.Components.DataInfo;

#endregion

namespace Twainsoft.ImageProcessing.Shapes.Components.Forms
{
    public partial class FrmShapeDebugData : FrmShapeWindowBase
    {
        private List<IShapeDebugMessage> DebugMessages { get; set; }

        public FrmShapeDebugData()
        {
            InitializeComponent();
        }

        public void SetDebugMessages(List<IShapeDebugMessage> debugMessages)
        {
            this.DebugMessages = debugMessages;

            foreach (var debugMessage in debugMessages)
            {
                this.dataGridViewDebugMessages.Rows.Add(new object[] {
                    debugMessage.EBCName
                });
            }
        }

        private void dataGridViewDebugMessages_SelectionChanged(object sender, EventArgs e)
        {
            this.tabControlDebugData.TabPages.Clear();

            if (this.dataGridViewDebugMessages.SelectedRows.Count == 1)
            {
                IShapeDebugMessage debugMessage = this.DebugMessages[this.dataGridViewDebugMessages.SelectedRows[0].Index];

                int sourceImageCounter = 1;
                foreach (var sourceImage in debugMessage.DebugData.SourceImages)
                {
                    this.tabControlDebugData.TabPages.Add(this.CreateSourceImageTabPage(sourceImage, sourceImageCounter,
                        debugMessage.DebugData.SourceImages.Count));

                    sourceImageCounter++;
                }

                if (debugMessage.DebugData.HasResultingImage)
                {
                    this.tabControlDebugData.TabPages.Add(this.CreateResultingImageTabPage(debugMessage.DebugData.ResultingImage));
                }

                if (debugMessage.DebugData.HasData)
                {
                    this.tabControlDebugData.TabPages.Add(this.CreateDataTabPage(debugMessage.DebugData.Data));
                }
            }
        }

        private TabPage CreateDataTabPage(object data)
        {
            TabPage tabPage = new TabPage("Daten");
            tabPage.Controls.Add(new UcDiagramInfo(data)
            {
                AutoScroll = true,
                Dock = DockStyle.Fill
            });

            return tabPage;
        }

        private TabPage CreateResultingImageTabPage(Bitmap resultingImage)
        {
            TabPage tabPage = new TabPage("Ergebnisbild");
            tabPage.Controls.Add(new PictureBox()
            {
                SizeMode = PictureBoxSizeMode.Zoom,
                Image = resultingImage,
                Dock = DockStyle.Fill
            });

            return tabPage;
        }

        private TabPage CreateSourceImageTabPage(Bitmap sourceImage, int sourceImageCounter, int sourceImages)
        {
            TabPage tabPage = new TabPage(String.Format("Quellbild {0}/{1}", new object[] { sourceImageCounter, sourceImages }));
            tabPage.Controls.Add(new PictureBox()
            {
                SizeMode = PictureBoxSizeMode.Zoom,
                Image = sourceImage,
                Dock = DockStyle.Fill
            });

            return tabPage;
        }

        private void btnClearData_Click(object sender, EventArgs e)
        {
            this.DebugMessages.Clear();
            this.dataGridViewDebugMessages.Rows.Clear();
        }
    }
}