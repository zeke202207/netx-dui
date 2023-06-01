using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Netx.Dui
{
    public abstract class BaseSchemeColor
    {
        private readonly Color _primary;

        public Color Primary { get { return _primary; } }

        public BaseSchemeColor(Color primary)
        {
            this._primary = primary;
        }
    }
}
