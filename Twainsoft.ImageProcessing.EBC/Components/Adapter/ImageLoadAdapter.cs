#region Namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Twainsoft.ImageProcessing.EBC.Contracts.Adapter;
using Twainsoft.ImageProcessing.EBC.Contracts.Vocabulary.Messages;
using Twainsoft.ImageProcessing.EBC.Components.Base;
using System.IO;
using System.Drawing;
using Twainsoft.ImageProcessing.EBC.Components.Vocabulary.Messages;
using Twainsoft.ImageProcessing.EBC.Components.Vocabulary.Data;
using Twainsoft.ImageProcessing.Common.Components.Vocabulary.Exceptions;
using Twainsoft.ImageProcessing.Common.Components.Vocabulary.Data;
using Twainsoft.ImageProcessing.Common.Contracts.Vocabulary.Messages;

#endregion

namespace Twainsoft.ImageProcessing.EBC.Components.Adapter
{
    public class ImageLoadAdapter : EBCBase, IImageLoadAdapter
    {
        private string FileName { get; set; }

        public ImageLoadAdapter()
        {
            this.Name = "Bild laden";
        }

        public void In_LoadImage(string fileName)
        {
            this.FileName = fileName;
        }

        public override void MessageReceived(IEBCMessage ebcMessage)
        {
            if (this.FileName != null)
            {
                this.StartProcess();
            }
            else
            {
                this.Out_GetFileName();

                this.StartProcess();
            }
        }

        private void StartProcess()
        {
            Bitmap image = null;

            using (StreamReader streamReader = new StreamReader(this.FileName))
            {
                image = new Bitmap(streamReader.BaseStream);
            }

            this.OnOut_SendResult(new EBCMessage(new EBCMessageData(DataResultTypes.LoadImage, image, this.ImageType)));
        }

        public event Action Out_GetFileName;
    }
}