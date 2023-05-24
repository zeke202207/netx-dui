using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Netx.Dui
{
    public abstract class BaseScheme
    {
        private BackgroundSchemeColor _bgSchemeColor;
        private FontSchemeColor _fontSchemeColor;

        public BackgroundSchemeColor bgSchemeColor => _bgSchemeColor;
        public FontSchemeColor fontSchemeColor => _fontSchemeColor;

        public BaseScheme()
        {
            InitScheme();
        }

        private void InitScheme()
        {
            _bgSchemeColor = InitBackgroundSchemeColor();
            _fontSchemeColor = InitFontSchemeColor();
        }

        protected abstract FontSchemeColor InitFontSchemeColor();
        protected abstract BackgroundSchemeColor InitBackgroundSchemeColor();
    }
}
