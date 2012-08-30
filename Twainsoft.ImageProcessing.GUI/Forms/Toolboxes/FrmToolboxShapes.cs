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
using Twainsoft.ImageProcessing.EBC.Contracts.Portals;
using Twainsoft.ImageProcessing.EBC.Components.Portals;
using Twainsoft.ImageProcessing.EBC.Components.Shapes;
using Twainsoft.ImageProcessing.EBC.Contracts.Vocabulary.Messages;
using Twainsoft.ImageProcessing.GUI.Controls.ShapesListView;
using Twainsoft.ImageProcessing.EBC.Contracts.Vocabulary.Data;
using Twainsoft.ImageProcessing.Common.Contracts.Vocabulary.Messages;
using Twainsoft.ImageProcessing.Common.Components.Vocabulary.Messages;

#endregion

namespace Twainsoft.ImageProcessing.GUI.Forms.Toolboxes
{
    public partial class FrmToolboxShapes : FrmToolboxBase, IFrmToolboxShapes
    {
        private IShapeCollectorPortal ShapeCollectorPortal { get; set; }

        private List<ShapeListViewItem> ShapeListViewItems { get; set; }

        public FrmToolboxShapes(Form owner)
            : base(owner)
        {
            InitializeComponent();

            this.BuildOwnToolStripMenu();

            this.ShapeListViewItems = new List<ShapeListViewItem>();

            this.ShapeCollectorPortal = new ShapeCollectorPortal(new ShapeCollector());
            this.ShapeCollectorPortal.Out_AvailableShapes += new Action<IAvailableShapesMessage>(ShapeCollectorPortal_Out_AvailableShapes);

            this.ShapeCollectorPortal.In_GetAvailableShapes();
        }

        private void BuildOwnToolStripMenu()
        {
            ToolStripLabel tslSearch = new ToolStripLabel("Suche:");
            this.toolStripMain.Items.Add(tslSearch);

            ToolStripTextBox tstbSearch = new ToolStripTextBox("tstbSearch");
            tstbSearch.Text = "Suchbegriff";
            tstbSearch.ForeColor = Color.Gray;
            tstbSearch.KeyDown += new KeyEventHandler(tstbSearch_KeyDown);
            tstbSearch.GotFocus += new EventHandler(tstbSearch_GotFocus);
            tstbSearch.LostFocus += new EventHandler(tstbSearch_LostFocus);

            this.toolStripMain.Items.Add(tstbSearch);
        }

        void tstbSearch_LostFocus(object sender, EventArgs e)
        {
            if (this.toolStripMain.Items["tstbSearch"].Text == "")
            {
                this.toolStripMain.Items["tstbSearch"].ForeColor = Color.Gray;
                this.toolStripMain.Items["tstbSearch"].Text = "Suchbegriff";
            }
        }

        void tstbSearch_GotFocus(object sender, EventArgs e)
        {
            if (this.toolStripMain.Items["tstbSearch"].Text == "Suchbegriff")
            {
                this.toolStripMain.Items["tstbSearch"].ForeColor = Color.Black;
                this.toolStripMain.Items["tstbSearch"].Text = "";
            }
        }

        void tstbSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                foreach (var item in this.ShapeListViewItems)
                {
                    item.Selected = false;

                    if (item.Text.ToLower().Contains(this.toolStripMain.Items["tstbSearch"].Text.ToLower()))
                    {
                        item.Selected = true;
                        this.listViewShapes.EnsureVisible(item.Index);

                        return;
                    }
                }
            }
        }

        void ShapeCollectorPortal_Out_AvailableShapes(IAvailableShapesMessage availableShapesMessage)
        {
            ShapeListViewItem shapeListViewItem;
            
            foreach (var shapeInfoData in availableShapesMessage.ShapesToEBCs)
            {
                ListViewGroup listViewGroup = this.CreateListViewGroup(shapeInfoData.Key);

                shapeListViewItem = new ShapeListViewItem(shapeInfoData.Key.Name, shapeInfoData.Key.Type, shapeInfoData.Value);
                shapeListViewItem.Group = listViewGroup;

                if (!this.listViewShapes.Groups.Contains(listViewGroup))
                    this.listViewShapes.Groups.Add(listViewGroup);

                this.listViewShapes.Items.Add(shapeListViewItem);
                this.ShapeListViewItems.Add(shapeListViewItem);
            }
        }

        private ListViewGroup CreateListViewGroup(IShapeInfoData shapeInfoData)
        {
            string groupName = shapeInfoData.ShapeGroup.ToString();

            ListViewGroup currentGroup = this.listViewShapes.Groups[groupName];

            if (currentGroup == null)
                currentGroup = new ListViewGroup(groupName, groupName);

            return currentGroup;
        }

        public ListView.SelectedListViewItemCollection GetSelectedShapes()
        {
            return this.listViewShapes.SelectedItems;
        }

        public void ClearSelectedShapes()
        {
            this.listViewShapes.SelectedItems.Clear();
        }

        private void FrmToolboxShapes_VisibleChanged(object sender, EventArgs e)
        {
            if (!this.Visible)
            {
                this.ClearSelectedShapes();
            }
        }

        private void listViewShapes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listViewShapes.SelectedItems.Count > 0)
            {
                this.Out_AddShapeMode(new ShapeModeMessage(ShapeModes.Add));
            }
            else
            {
                this.Out_AddShapeMode(new ShapeModeMessage(ShapeModes.Edit));
            }
        }

        public event Action<IShapeModeMessage> Out_AddShapeMode;

        private void FrmToolboxShapes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.ClearSelectedShapes();
            }
        }
    }
}