using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Netx.Dui
{
    public abstract class BaseSkinScheme
    {
        private readonly Color _primary;

        public Color Primary { get { return _primary; } }

        public BaseSkinScheme(Color primary)
        {
            this._primary = primary;
        }
    }
}
