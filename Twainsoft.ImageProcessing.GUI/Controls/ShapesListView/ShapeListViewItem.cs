#region Namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

#endregion

namespace Twainsoft.ImageProcessing.GUI.Controls.ShapesListView
{
    public class ShapeListViewItem : ListViewItem
    {
        public Type ShapeType { get; private set; }
        public Type EBCType { get; private set; }

        public ShapeListViewItem(string name)
            : base(name)
        {
            this.ImageIndex = 0;
        }

        public ShapeListViewItem(string name, Type shapeType, Type ebcType)
            : this(name)
        {
            this.ShapeType = shapeType;
            this.EBCType = ebcType;
        }
    }
}