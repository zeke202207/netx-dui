﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Netx.Dui
{
    public class DuiColor
    {
        private System.Drawing.Color color = new Color();
        private SharpDX.Mathematics.Interop.RawColor4 dxColor4 = new SharpDX.Mathematics.Interop.RawColor4();

        internal SharpDX.Mathematics.Interop.RawColor4 DxColor4
        {
            get { return dxColor4; }
        }
        public DuiColor(System.Drawing.Color color)
        {
            this.color = color;
            this.dxColor4 = new SharpDX.Mathematics.Interop.RawColor4((float)color.R / 255f, (float)color.G / 255f, (float)color.B / 255f, (float)color.A / 255f);
        }
        public static implicit operator SharpDX.Mathematics.Interop.RawColor4(DuiColor dUIColor)
        {
            return dUIColor.DxColor4;
        }
        public static implicit operator System.Drawing.Color(DuiColor dUIColor)
        {
            return dUIColor.color;
        }
    }
}
