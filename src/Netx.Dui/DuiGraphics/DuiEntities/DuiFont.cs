using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Netx.Dui
{
    public class DuiFont : IDisposable
    {
        private System.Drawing.Font font = null;
        private ContentAlignment _align = ContentAlignment.MiddleLeft;

        [NonSerialized]
        private SharpDX.DirectWrite.TextFormat textFormat = null;

        private SharpDX.DirectWrite.TextFormat TextFormat
        {
            get
            {
                if (textFormat == null)
                    textFormat = DxConvert.ToTextFormat(this.font);
                var align = _align.ToDxAlignment();
                textFormat.TextAlignment = align.textAlign;
                textFormat.ParagraphAlignment = align.paragraphAlign;
                return textFormat;
            }
        }

        /// <summary> 使用指定的大小初始化新 DUIFont
        /// </summary>
        /// <param name="font">新的Font</param>
        public DuiFont(Font font)
        {
            this.font = font;
        }

        /// <summary> 使用指定的大小初始化新 DUIFont
        /// </summary>
        /// <param name="font">新的Font</param>
        public DuiFont(string familyName)
            : this(new Font(familyName, 9F))
        {
        }

        /// <summary> 使用指定的大小初始化新 DUIFont
        /// </summary>
        /// <param name="family">新 DUIFont 的 System.Drawing.FontFamily</param>
        /// <param name="emSize">新字体的全身大小（以磅值为单位）。</param>
        public DuiFont(FontFamily family, float emSize)
        {
            this.font = new System.Drawing.Font(family, emSize);
        }

        /// <summary> 使用指定的大小初始化新 DUIFont
        /// </summary>
        /// <param name="family">新 DUIFont 的 System.Drawing.FontFamily 的字符串表示形式</param>
        /// <param name="emSize">新字体的全身大小（以磅值为单位）。</param>
        public DuiFont(string familyName, float emSize)
        {
            try
            {
                this.font = new System.Drawing.Font(familyName, emSize);
            }
            catch (Exception ex)
            {
                familyName = "宋体";
                this.font = new System.Drawing.Font(familyName, emSize);
            }
        }

        /// <summary> 使用指定的大小初始化新 DUIFont
        /// </summary>
        /// <param name="family">新 DUIFont 的 System.Drawing.FontFamily 的字符串表示形式</param>
        /// <param name="emSize">新字体的全身大小（以磅值为单位）。</param>
        public DuiFont(string familyName, float emSize, FontStyle style)
        {
            this.font = new System.Drawing.Font(familyName, emSize, style);
        }

        /// <summary> 使用指定的大小和样式初始化新 DUIFont
        /// </summary>
        /// <param name="family">新 DUIFont 的 System.Drawing.FontFamily 的字符串表示形式</param>
        /// <param name="emSize">新字体的全身大小（以磅值为单位）。</param>
        /// <param name="style">新字体的 System.Drawing.FontStyle</param>
        public DuiFont(FontFamily family, float emSize, FontStyle style)
        {
            this.font = new System.Drawing.Font(family, emSize, style);
        }

        public DuiFont(Font font, ContentAlignment align)
        {
            this.font = font;
            this._align = align;
        }

        /// <summary> 返回此字体的行距（以像素为单位）。
        /// </summary>
        /// <returns>此字体的行距（以像素为单位）。</returns>
        public float GetHeight()
        {
            return this.font.GetHeight();
        }

        public static implicit operator SharpDX.DirectWrite.TextFormat(DuiFont dUIFont)
        {
            return dUIFont.TextFormat;
        }

        public static implicit operator System.Drawing.Font(DuiFont dUIFont)
        {
            return dUIFont.font;
        }

        public void Dispose()
        {
            if (this.font != null)
            {
                this.font.Dispose();
            }
            if (this.textFormat != null)
            {
                this.textFormat.Dispose();
            }
        }
    }
}
