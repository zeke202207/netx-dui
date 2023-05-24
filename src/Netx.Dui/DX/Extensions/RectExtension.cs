using SharpDX;
using SharpDX.Mathematics.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Netx.Dui
{
    public static class RectExtension
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="rect"></param>
        /// <param name="horizontalAmount"></param>
        /// <param name="verticalAmount"></param>
        /// <param name="offsize"></param>
        /// <returns></returns>
        public static RawRectangleF Inflate(this RawRectangleF rect,float horizontalAmount, float verticalAmount, float offsize = 0)
        {
            var r = new RectangleF(rect.Left, rect.Top, rect.Right + offsize, rect.Bottom + offsize);
            r.Inflate(horizontalAmount,verticalAmount);
            return r;
        }
    }
}
