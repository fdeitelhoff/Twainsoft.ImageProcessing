#region Namespaces

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Twainsoft.ImageProcessing.Common.Components.Vocabulary.Data;

#endregion

namespace Twainsoft.ImageProcessing.Shapes.Components.Forms.Adapter
{
    public partial class FrmImageLoadAdapterShapeOptions : FrmShapeOptionsBase
    {
        public FrmImageLoadAdapterShapeOptions()
        {
            InitializeComponent();

            foreach (ImageTypes imageType in Enum.GetValues(typeof(ImageTypes)))
            {
                this.cmbImageType.Items.Add(new ImageTypeComboBoxItem(imageType));
            }
        }

        public FrmImageLoadAdapterShapeOptions(ImageTypes imageType)
            : this()
        {
            this.cmbImageType.SelectedItem = imageType;
        }

        public ImageTypes GetSelectedImageType()
        {
            ImageTypes selectedImageType = ImageTypes.Default;

            ImageTypeComboBoxItem imageTypeComboBoxItem = this.cmbImageType.SelectedItem as ImageTypeComboBoxItem;

            if (imageTypeComboBoxItem != null)
            {
                selectedImageType = imageTypeComboBoxItem.ImageType;
            }

            return selectedImageType;
        }
    }
}