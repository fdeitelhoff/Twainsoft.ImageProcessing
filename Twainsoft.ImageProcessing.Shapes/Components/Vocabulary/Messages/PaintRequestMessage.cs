using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Twainsoft.ImageProcessing.Shapes.Contracts.Vocabulary.Messages;

namespace Twainsoft.ImageProcessing.Shapes.Components.Vocabulary.Messages
{
    public class PaintRequestMessage : IPaintRequestMessage
    {
        public Graphics Graphics { get; private set; }

        public PaintRequestMessage(Graphics graphics)
        {
            this.Graphics = graphics;
        }
    }
}
