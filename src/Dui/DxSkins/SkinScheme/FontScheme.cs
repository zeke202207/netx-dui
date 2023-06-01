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

        public Font Font { get { return _font; } }

        public FontScheme(Color primary, Font font) 
            : base(primary)
        {
            _font = font;
        }
    }
}
