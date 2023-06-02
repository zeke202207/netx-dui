using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Netx.Dui
{
    public class FontScheme : BaseSkinScheme
    {
        private readonly Font _font;
        private readonly Color _transparencyColor;

        public Font Font { get { return _font; } }

        public FontScheme(Color primary , Color transparency, Font font) 
            : base(primary)
        {
            _transparencyColor = transparency;
            _font = font;
        }

        /// <summary>
        /// 获取字体设定颜色
        /// </summary>
        /// <param name="colorType"></param>
        /// <returns></returns>
        public Color GetColor(FontColorType fontColor) =>
            fontColor switch
            {
                FontColorType.Primary => base._primary,
                FontColorType.Transparency => this._transparencyColor,
                _ => throw new NotImplementedException()
            };
    }
}
