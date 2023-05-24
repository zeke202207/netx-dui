using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using DColor = SharpDX.Color;
using Color = System.Drawing.Color;
using System.Runtime.CompilerServices;
using SharpDX.Mathematics.Interop;

namespace Netx.Dui
{
    /// <summary>
    /// 颜色转换
    /// </summary>
    public static class ColorExtension
    {
        public static DColor ToDColor(this Color color)
        {
            return new DColor(color.R, color.G, color.B, color.A);
        }

        public static Color ToColor(this DColor color)
        {
            return Color.FromArgb(color.A, color.R, color.G, color.B);
        }
    }
}
