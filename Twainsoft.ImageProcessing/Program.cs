#region Namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Twainsoft.ImageProcessing.GUI.Forms;

#endregion

namespace Twainsoft.ImageProcessing
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmMain());
        }
    }
}