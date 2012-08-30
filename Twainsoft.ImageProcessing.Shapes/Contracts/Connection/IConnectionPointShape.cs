#region Namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

#endregion

namespace Twainsoft.ImageProcessing.Shapes.Contracts.Connection
{
    public interface IConnectionPointShape
    {
        bool CheckClickStatus(Point location);

        event Action Out_PointDragged;
    }
}