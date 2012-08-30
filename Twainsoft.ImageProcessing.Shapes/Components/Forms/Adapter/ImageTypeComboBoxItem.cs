#region Namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Twainsoft.ImageProcessing.Common.Components.Vocabulary.Data;

#endregion

namespace Twainsoft.ImageProcessing.Shapes.Components.Forms.Adapter
{
    public class ImageTypeComboBoxItem
    {
        public string Name { get; set; }
        public ImageTypes ImageType { get; set; }

        public ImageTypeComboBoxItem(ImageTypes imageType)
        {
            this.Name = imageType.ToString();
            this.ImageType = imageType;
        }

        public ImageTypeComboBoxItem(ImageTypes imageType, string name)
        {
            this.Name = name;
            this.ImageType = imageType;
        }

        public override string ToString()
        {
            return this.Name;
        }

        public override bool Equals(object obj)
        {
            if (!String.IsNullOrEmpty(obj.ToString()))
            {
                try
                {
                    ImageTypes imageType = (ImageTypes)Enum.Parse(typeof(ImageTypes), obj.ToString(), true);

                    return imageType == this.ImageType;
                }
                catch
                {
                    return false;
                }
            }

            ImageTypeComboBoxItem imageTypeComboBoxItem = obj as ImageTypeComboBoxItem;

            if (imageTypeComboBoxItem == null)
            {
                return false;
            }

            return imageTypeComboBoxItem.ImageType == this.ImageType;
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode();
        }
    }
}