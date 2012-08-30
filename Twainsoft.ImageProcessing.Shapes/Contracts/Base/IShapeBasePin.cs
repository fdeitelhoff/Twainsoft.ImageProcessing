#region Namespaces

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

#endregion

namespace Twainsoft.ImageProcessing.Shapes.Contracts.Base
{
    public interface IShapeBasePin
    {
        void Paint(Graphics graphics);

        void MoveTo(Rectangle rectangle);

        void SetPosition(Rectangle rectangle);

        Point Center();

        bool Contains(Point point);

        bool IsActive { set; }

        bool IsEnabled { get; set; }
    }
}