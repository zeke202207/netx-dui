using SharpDX.DirectWrite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MSDrwing = System.Drawing;

namespace Netx.Dui
{
    internal class TextFormatHelper
    {
        /// <summary>
        /// dx文本格式转换
        /// </summary>
        /// <param name="fontName">字体名称</param>
        /// <param name="fontSize">字号</param>
        /// <returns></returns>
        public static TextFormat ToDxTextFormat(
            string fontName,
            float fontSize)
        {
            return ToDxTextFormat(fontName, fontSize, WeightStyle.Regular);
        }

        /// <summary>
        /// dx文本格式转换
        /// </summary>
        /// <param name="fontName">字体名称</param>
        /// <param name="fontSize">字号</param>
        /// <param name="fontStyle">字体样式</param>
        /// <returns></returns>
        public static TextFormat ToDxTextFormat(
            string fontName,
            float fontSize,
            WeightStyle wStyle)
        {
            return ToDxTextFormat(fontName, fontSize, wStyle, ItalicStyle.Normal, MSDrwing.ContentAlignment.MiddleCenter);
        }

        /// <summary>
        /// dx文本格式转换
        /// </summary>
        /// <param name="fontName">字体名称</param>
        /// <param name="fontSize">字号</param>
        /// <param name="fontStyle">字体样式</param>
        /// <param name="algin">对齐方式</param>
        /// <param name="rightToLeft">文字方向</param>
        /// <returns></returns>
        public static TextFormat ToDxTextFormat(
            string fontName,
            float fontSize,
            WeightStyle wStyle,
            ItalicStyle iStyle,
            MSDrwing.ContentAlignment algin)
        {
            var align = algin.ToDxTextAlignment();
            var fontWeight = wStyle.ToDxFontWeight();
            var fontStyle = iStyle.ToDxFontStyle();
            var textFormat = new TextFormat(DxDirectSingleton.Instance.DwFactory, fontName, fontWeight, fontStyle, fontSize);
            textFormat.TextAlignment = align.textAlign;
            textFormat.ParagraphAlignment = align.paragraphAlign;
            return textFormat;
        }
    }
}
