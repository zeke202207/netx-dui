using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Netx.Dui
{
    public class DefaultScheme : BaseScheme
    {
        public DefaultScheme() 
        {

        }

        /// <summary>
        /// 配置
        /// </summary>
        /// <returns></returns>
        protected override ColorScheme InitColorScheme()
        {
            ColorScheme backgroundScheme = new ColorScheme(
                ColorTranslator.FromHtml("#409EFF"),
                ColorTranslator.FromHtml("#A0CFFF"),
                ColorTranslator.FromHtml("#337ECC"),
                ColorTranslator.FromHtml("#337ECC"),
                ColorTranslator.FromHtml("#C6E2FF"),
                ColorTranslator.FromHtml("#E91095"),
                ColorTranslator.FromHtml("#555252")
                );
            return backgroundScheme;
        }

        /// <summary>
        /// 配置字体
        /// </summary>
        /// <returns></returns>
        protected override FontScheme InitFontScheme()
        {
            return new FontScheme(ColorTranslator.FromHtml("#FFFFFF"), Color.Black, new Font("宋体", 13.0f));
        }
    }
}
