namespace Twainsoft.ImageProcessing.GUI.Forms.Toolboxes
{
    partial class FrmToolboxShapes
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmToolboxShapes));
            this.listViewShapes = new System.Windows.Forms.ListView();
            this.imageListShapesListView = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // listViewShapes
            // 
            this.listViewShapes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewShapes.FullRowSelect = true;
            this.listViewShapes.HideSelection = false;
            this.listViewShapes.LargeImageList = this.imageListShapesListView;
            this.listViewShapes.Location = new System.Drawing.Point(0, 25);
            this.listViewShapes.Name = "listViewShapes";
            this.listViewShapes.Size = new System.Drawing.Size(318, 502);
            this.listViewShapes.TabIndex = 1;
            this.listViewShapes.UseCompatibleStateImageBehavior = false;
            this.listViewShapes.SelectedIndexChanged += new System.EventHandler(this.listViewShapes_SelectedIndexChanged);
            // 
            // imageListShapesListView
            // 
            this.imageListShapesListView.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListShapesListView.ImageStream")));
            this.imageListShapesListView.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListShapesListView.Images.SetKeyName(0, "ShapeIcon.png");
            // 
            // FrmToolboxShapes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(318, 527);
            this.Controls.Add(this.listViewShapes);
            this.KeyPreview = true;
            this.Name = "FrmToolboxShapes";
            this.Text = "Vorhandene Elemente";
            this.VisibleChanged += new System.EventHandler(this.FrmToolboxShapes_VisibleChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmToolboxShapes_KeyDown);
            this.Controls.SetChildIndex(this.listViewShapes, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listViewShapes;
        private System.Windows.Forms.ImageList imageListShapesListView;
    }
}