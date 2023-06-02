using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Netx.Dui
{
    public abstract class BaseSkinScheme
    {
        protected readonly Color _primary;

        public BaseSkinScheme(Color primary)
        {
            this._primary = primary;
        }
    }
}
