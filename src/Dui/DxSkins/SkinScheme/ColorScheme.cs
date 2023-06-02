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
        private readonly Color _animationColor;
        private readonly Color _borderColor;

        public ColorScheme(
            Color backgroundColor,
            Color hoverColor,
            Color pressedColor,
            Color selectedColor,
            Color disabledColor,
            Color animationColor,
            Color borderColor)
            : base(backgroundColor)
        {
            this._hoverColor = hoverColor;
            this._pressedColor = pressedColor;
            this._selectedColor = selectedColor;
            this._disabledColor = disabledColor;
            this._animationColor = animationColor;
            this._borderColor = borderColor;
        }

        /// <summary>
        /// 获取皮肤设定颜色
        /// </summary>
        /// <param name="colorType"></param>
        /// <returns></returns>
        public Color GetColor(ColorType colorType) =>
            colorType switch
            {
                ColorType.Primary => base._primary,
                ColorType.Hover => this._hoverColor, 
                ColorType.Pressed => this._pressedColor,
                ColorType.Selected => this._selectedColor,
                ColorType.Disabled => this._disabledColor,
                ColorType.Animation => this._animationColor,
                ColorType.Border => this._borderColor,
                _ => throw new NotImplementedException()
            };
       
    }
}
