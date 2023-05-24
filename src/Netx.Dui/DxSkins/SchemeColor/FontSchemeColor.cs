using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Netx.Dui
{
    public class FontSchemeColor : BaseSchemeColor
    {
        private readonly Font _font;

        public Font Font { get { return _font; } }

        public FontSchemeColor(Color primary, Font font) 
            : base(primary)
        {
            _font = font;
        }
    }
}
