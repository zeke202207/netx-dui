using Netx.Dui;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Simple
{
    public class MyScheme : BaseScheme
    {
        public MyScheme()
        {

        }

        /// <summary>
        /// 配置
        /// </summary>
        /// <returns></returns>
        protected override ColorScheme InitColorScheme()
        {
            ColorScheme backgroundScheme = new ColorScheme(
                Color.DarkGray,
                Color.DarkGreen,
                Color.DarkRed,
                Color.DarkOrange,
                Color.DarkSalmon,
                Color.Green,
                Color.DarkRed
                );
            return backgroundScheme;
        }

        /// <summary>
        /// 配置字体
        /// </summary>
        /// <returns></returns>
        protected override FontScheme InitFontScheme()
        {
            return new FontScheme(ColorTranslator.FromHtml("#FFFFFF"), ColorTranslator.FromHtml("#3B3939") , new Font("宋体", 9.0f));
        }
    }
}
