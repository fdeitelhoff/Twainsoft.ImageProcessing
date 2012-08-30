#region Namespaces

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Twainsoft.ImageProcessing.Common.Contracts.Vocabulary.Exceptions;

#endregion

namespace Twainsoft.ImageProcessing.Shapes.Components.Forms
{
    public partial class FrmShapeError : FrmShapeWindowBase
    {
        public FrmShapeError()
        {
            InitializeComponent();
        }

        internal void SetWorkException(IWorkException workException)
        {
            this.richTextBoxError.Text = workException.Message;

            this.richTextBoxError.Text += "\n\n" + workException.InnerException.ToString();
        }
    }
}