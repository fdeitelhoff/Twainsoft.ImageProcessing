#region Namespaces

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Twainsoft.ImageProcessing.EBC.Contracts.Portals;
using Twainsoft.ImageProcessing.EBC.Components.Portals;
using Twainsoft.ImageProcessing.EBC.Components;
using Twainsoft.ImageProcessing.EBC.Contracts.Vocabulary.Messages;
using Twainsoft.ImageProcessing.EBC.Components.Adapter;
using Twainsoft.ImageProcessing.EBC.Components.Base;
using Twainsoft.ImageProcessing.EBC.Components.Histogram;
using Twainsoft.ImageProcessing.EBC.Components.LUT;
using Twainsoft.ImageProcessing.EBC.Components.Execution;
using Twainsoft.ImageProcessing.EBC.Components.Shapes;
using Twainsoft.ImageProcessing.GUI.Controls.ShapesListView;
using Twainsoft.ImageProcessing.EBC.Contracts.Base;
using Twainsoft.ImageProcessing.Shapes.Contracts;
using Twainsoft.ImageProcessing.GUI.Forms.Toolboxes;
using Twainsoft.ImageProcessing.Shapes.Contracts.Base;
using Twainsoft.ImageProcessing.Common.Contracts.Vocabulary.Messages;
using Twainsoft.ImageProcessing.GUI.Contracts;

#endregion

namespace Twainsoft.ImageProcessing.GUI.Forms
{
    public partial class FrmMain : Form
    {
        private IPaintLeafPortal PaintLeafPortal { get; set; }        

        private FrmToolboxEBCOutputData FrmToolboxEBCOutputData { get; set; }
        private FrmToolboxEBCDebugData FrmToolboxEBCDebugData { get; set; }
        private FrmToolboxElapsedTime FrmToolboxElapsedTime { get; set; }
        private FrmToolboxShapes FrmToolboxShapes { get; set; }
        private FrmToolboxEBCErrors FrmToolboxEBCErrors { get; set; }

        private bool ToolboxesClosed { get; set; }

        public FrmMain()
        {
            InitializeComponent();

            this.PaintLeafPortal = new PaintLeafPortal(new ShapeController(), new ExecutionController(), new STEConnector());

            this.ucPaintLeaf.Paint += (object sender, PaintEventArgs e) => this.PaintLeafPortal.In_PaintRequest(e);

            this.ucPaintLeaf.MouseClick += new MouseEventHandler(ucPaintLeaf_MouseClick);
            this.ucPaintLeaf.MouseClick += (object sender, MouseEventArgs e) => this.PaintLeafPortal.In_MouseClick(e);
            this.ucPaintLeaf.MouseDoubleClick += (object sender, MouseEventArgs e) => this.PaintLeafPortal.In_MouseDoubleClick(e);
            this.ucPaintLeaf.MouseDown += (object sender, MouseEventArgs e) => this.PaintLeafPortal.In_MouseDown(e);
            this.ucPaintLeaf.MouseUp += (object sender, MouseEventArgs e) => this.PaintLeafPortal.In_MouseUp(e);
            this.ucPaintLeaf.MouseMove += (object sender, MouseEventArgs e) => this.PaintLeafPortal.In_MouseMove(e);
            this.ucPaintLeaf.KeyDown += (object sender, KeyEventArgs e) => this.PaintLeafPortal.In_KeyDown(e);
            this.ucPaintLeaf.KeyUp += (object sender, KeyEventArgs e) => this.PaintLeafPortal.In_KeyUp(e);

            this.PaintLeafPortal.Out_InvalidateRequest += new Action(PaintLeafPortal_Out_InvalidateRequest);
            this.PaintLeafPortal.Out_ExecutionFinished += (IExecutionFinishedMessage executionFinishedMessage) => this.FrmToolboxEBCOutputData.In_OutputData(executionFinishedMessage.EBCOutputData);
            this.PaintLeafPortal.Out_ExecutionFinished += (IExecutionFinishedMessage executionFinishedMessage) => this.FrmToolboxElapsedTime.In_ElapsedTime(executionFinishedMessage.EBCExecutionTime);
            this.PaintLeafPortal.Out_EBCDebugMessage += (IEBCDebugMessage ebcDebugMessage) => this.FrmToolboxEBCDebugData.In_EBCDebugMessage(ebcDebugMessage);
            this.PaintLeafPortal.Out_EBCWorkExceptionHandled += (IEBCExceptionMessage ebcExceptionMessage) => this.FrmToolboxEBCErrors.In_EBCWorkExceptionHandled(ebcExceptionMessage);
            this.PaintLeafPortal.Out_ReportError += new Action<IErrorMessage>(PaintLeafPortal_Out_ReportError);

            this.FrmToolboxEBCOutputData = new FrmToolboxEBCOutputData(this);
            this.FrmToolboxEBCDebugData = new FrmToolboxEBCDebugData(this);
            this.FrmToolboxElapsedTime = new FrmToolboxElapsedTime(this);
            this.FrmToolboxShapes = new FrmToolboxShapes(this);
            this.FrmToolboxEBCErrors = new FrmToolboxEBCErrors(this);

            this.FrmToolboxShapes.Out_AddShapeMode += (IShapeModeMessage shapeModeMessage) => this.PaintLeafPortal.In_ShapeMode(shapeModeMessage);

            this.FrmToolboxShapes.Show();
        }

        void PaintLeafPortal_Out_ReportError(IErrorMessage errorMessage)
        {
            string innerExceptionText = "";
            if (errorMessage.Exception.InnerException != null)
            {
                innerExceptionText = "\n\n" + errorMessage.Exception.InnerException;
            }

            MessageBox.Show(this, errorMessage.Exception.Message + innerExceptionText,
                "Es ist ein Fehler aufgetreten",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        void PaintLeafPortal_Out_InvalidateRequest()
        {
            this.ucPaintLeaf.Invalidate();
        }

        void ucPaintLeaf_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                foreach (ShapeListViewItem shapeListViewItem in this.FrmToolboxShapes.GetSelectedShapes())
                {
                    try
                    {
                        this.PaintLeafPortal.In_AddShape(Activator.CreateInstance(shapeListViewItem.ShapeType) as IShapeBase,
                            Activator.CreateInstance(shapeListViewItem.EBCType) as IEBCBase, e.Location);
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(this, "Das Element '" + shapeListViewItem.Text + "' konnte nicht hinzugefügt werden.\n\nFehlermeldung:\n\n" + exception.ToString(),
                            "Fehler beim Hinzufügen des Elements", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void FrmMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.FrmToolboxShapes.ClearSelectedShapes();
        }

        private void outputDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.FrmToolboxEBCOutputData.Visible)
                this.FrmToolboxEBCOutputData.Hide();
            else
                this.FrmToolboxEBCOutputData.Show();
        }

        private void viewToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            this.shapesToolStripMenuItem.Checked = this.FrmToolboxShapes.Visible;
            this.outputDataToolStripMenuItem.Checked = this.FrmToolboxEBCOutputData.Visible;
            this.debugDataToolStripMenuItem.Checked = this.FrmToolboxEBCDebugData.Visible;
            this.elapsedTimeToolStripMenuItem.Checked = this.FrmToolboxElapsedTime.Visible;
            this.errorMessagesToolStripMenuItem.Checked = this.FrmToolboxEBCErrors.Visible;
        }

        private void elapsedTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.FrmToolboxElapsedTime.Visible)
                this.FrmToolboxElapsedTime.Hide();
            else
                this.FrmToolboxElapsedTime.Show();
        }

        private void shapesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.FrmToolboxShapes.Visible)
                this.FrmToolboxShapes.Hide();
            else
                this.FrmToolboxShapes.Show();
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!this.ToolboxesClosed)
            {
                this.FrmToolboxShapes.CloseToolbox();
                this.FrmToolboxElapsedTime.CloseToolbox();
                this.FrmToolboxEBCOutputData.CloseToolbox();
                this.FrmToolboxEBCDebugData.CloseToolbox();
                this.FrmToolboxEBCErrors.CloseToolbox();

                this.ToolboxesClosed = true;

                this.Close();
            }
        }

        private void errorMessagesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.FrmToolboxEBCErrors.Visible)
                this.FrmToolboxEBCErrors.Hide();
            else
                this.FrmToolboxEBCErrors.Show();
        }

        private void debugDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.FrmToolboxEBCDebugData.Visible)
                this.FrmToolboxEBCDebugData.Hide();
            else
                this.FrmToolboxEBCDebugData.Show();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FrmAbout().ShowDialog(this);
        }
    }
}