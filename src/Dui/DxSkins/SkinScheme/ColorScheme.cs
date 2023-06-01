using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Netx.Dui
{
    public class ColorScheme : BaseSkinScheme
    {
        private readonly Color _hoverColor;
        private readonly Color _pressedColor;
        private readonly Color _selectedColor;
        private readonly Color _disabledColor;

        public Color HoverColor { get { return _hoverColor; } }
        public Color PressedColor { get { return _pressedColor; } }
        public Color SelectedColor { get { return _selectedColor; } }
        public Color DisabledColor { get { return _disabledColor; } }
        
        public ColorScheme(Color backgroundColor, Color hoverColor, Color pressedColor, Color selectedColor, Color disabledColor)
            : base(backgroundColor)
        {
            this._hoverColor = hoverColor;
            this._pressedColor = pressedColor;
            this._selectedColor = selectedColor;
            this._disabledColor = disabledColor;
        }
    }
}
