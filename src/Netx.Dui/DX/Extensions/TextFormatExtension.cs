using SharpDX.DirectWrite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MSDrwing = System.Drawing;

namespace Netx.Dui
{
    public static class TextFormatExtension
    {
        /// <summary>
        /// dx文本对齐方式转换
        /// </summary>
        /// <param name="algin"></param>
        /// <returns></returns>
        public static (TextAlignment textAlign, ParagraphAlignment paragraphAlign) ToDxTextAlignment(this MSDrwing.ContentAlignment algin)
        {
            switch (algin)
            {
                default:
                case MSDrwing.ContentAlignment.TopLeft:
                    return (textAlign: TextAlignment.Leading, paragraphAlign: ParagraphAlignment.Near);
                case MSDrwing.ContentAlignment.TopCenter:
                    return (textAlign: TextAlignment.Center, paragraphAlign: ParagraphAlignment.Near);
                case MSDrwing.ContentAlignment.TopRight:
                    return (textAlign: TextAlignment.Trailing, paragraphAlign: ParagraphAlignment.Near);

                case MSDrwing.ContentAlignment.MiddleLeft:
                    return (textAlign: TextAlignment.Leading, paragraphAlign: ParagraphAlignment.Center);
                case MSDrwing.ContentAlignment.MiddleCenter:
                    return (textAlign: TextAlignment.Center, paragraphAlign: ParagraphAlignment.Center);
                case MSDrwing.ContentAlignment.MiddleRight:
                    return (textAlign: TextAlignment.Trailing, paragraphAlign: ParagraphAlignment.Center);

                case MSDrwing.ContentAlignment.BottomLeft:
                    return (textAlign: TextAlignment.Leading, paragraphAlign: ParagraphAlignment.Far);
                case MSDrwing.ContentAlignment.BottomCenter:
                    return (textAlign: TextAlignment.Center, paragraphAlign: ParagraphAlignment.Far);
                case MSDrwing.ContentAlignment.BottomRight:
                    return (textAlign: TextAlignment.Trailing, paragraphAlign: ParagraphAlignment.Far);
            }
        }

        /// <summary>
        /// 字体weight转换
        /// </summary>
        /// <param name="wStyle"></param>
        /// <returns></returns>
        public static FontWeight ToDxFontWeight(this WeightStyle wStyle)
        {
            switch (wStyle)
            {
                default:
                case WeightStyle.Regular:
                    return FontWeight.Normal;
                case WeightStyle.Bold:
                    return FontWeight.Bold;
            }
        }

        /// <summary>
        /// 斜体转换
        /// </summary>
        /// <param name="iStyle"></param>
        /// <returns></returns>
        public static FontStyle ToDxFontStyle(this ItalicStyle iStyle)
        {
            switch (iStyle)
            {
                default:
                case ItalicStyle.Normal:
                    return FontStyle.Normal;
                case ItalicStyle.Italic:
                    return FontStyle.Italic;
            }
        }
    }
}
