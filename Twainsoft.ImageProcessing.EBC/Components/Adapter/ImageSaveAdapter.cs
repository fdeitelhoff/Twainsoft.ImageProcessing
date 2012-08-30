#region Namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Twainsoft.ImageProcessing.EBC.Contracts.Adapter;
using Twainsoft.ImageProcessing.EBC.Components.Base;
using Twainsoft.ImageProcessing.EBC.Contracts.Vocabulary.Messages;
using Twainsoft.ImageProcessing.EBC.Contracts.Vocabulary.Data;
using System.Drawing;
using Twainsoft.ImageProcessing.EBC.Components.Vocabulary.Messages;
using Twainsoft.ImageProcessing.EBC.Components.Vocabulary.Data;
using Twainsoft.ImageProcessing.Common.Components.Vocabulary.Exceptions;
using Twainsoft.ImageProcessing.Common.Components.Vocabulary.Data;

#endregion

namespace Twainsoft.ImageProcessing.EBC.Components.Adapter
{
    public class ImageSaveAdapter : EBCBase, IImageSaveAdapter
    {
        private string FileName { get; set; }

        public IEBCMessageData LastEBCMessageData { get; set; }

        public ImageSaveAdapter()
        {
            this.Name = "Bild speichern";
        }

        public override void MessageReceived(IEBCMessage ebcMessage)
        {
            this.LastEBCMessageData = ebcMessage.EBCMessageData;

            if (!String.IsNullOrEmpty(this.FileName))
            {
                this.SaveImage();
            }
            else
            {
                this.Out_GetFileName();

                this.SaveImage();
            }
        }

        private void SaveImage()
        {
            this.LastEBCMessageData.Image.Save(this.FileName);

            this.OnOut_SendResult(new EBCMessage(new EBCMessageData(DataResultTypes.SaveImage, new Bitmap(this.LastEBCMessageData.Image))));
        }

        public void In_SaveImage(string fileName)
        {
            this.FileName = fileName;
        }

        public event Action Out_GetFileName;
    }
}