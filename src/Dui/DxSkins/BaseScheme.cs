using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Netx.Dui
{
    public abstract class BaseScheme
    {
        private ColorScheme _colorScheme;
        private FontScheme _fontScheme;

        public ColorScheme ColorScheme => _colorScheme;
        public FontScheme FontScheme => _fontScheme;

        public BaseScheme()
        {
            InitScheme();
        }

        private void InitScheme()
        {
            _colorScheme = InitColorScheme();
            _fontScheme = InitFontScheme();
        }

        protected abstract FontScheme InitFontScheme();

        protected abstract ColorScheme InitColorScheme();
    }
}
