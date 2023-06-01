using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Netx.Dui
{
    public class DuiRectangleF
    {
        private System.Drawing.RectangleF rectangle = new RectangleF();
        private SharpDX.Mathematics.Interop.RawRectangleF dxRectangleF = new SharpDX.Mathematics.Interop.RawRectangleF();

        internal SharpDX.Mathematics.Interop.RawRectangleF DxRectangleF
        {
            get { return dxRectangleF; }
        }
        public DuiRectangleF(System.Drawing.RectangleF rectangle)
        {
            this.rectangle = rectangle;
            this.dxRectangleF = new SharpDX.Mathematics.Interop.RawRectangleF(this.rectangle.Left, this.rectangle.Top, this.rectangle.Right, this.rectangle.Bottom);
        }
        public static implicit operator SharpDX.Mathematics.Interop.RawRectangleF(DuiRectangleF dUIRectangle)
        {
            return dUIRectangle.DxRectangleF;
        }
        public static implicit operator System.Drawing.RectangleF(DuiRectangleF dUIRectangle)
        {
            return dUIRectangle.rectangle;
        }
    }
}
