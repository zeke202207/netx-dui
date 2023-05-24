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
        protected override BackgroundSchemeColor InitBackgroundSchemeColor()
        {
            BackgroundSchemeColor backgroundScheme = new BackgroundSchemeColor(
                Color.DarkGray,
                Color.DarkGreen,
                Color.DarkRed,
                Color.DarkOrange,
                Color.DarkSalmon
                );
            return backgroundScheme;
        }

        /// <summary>
        /// 配置字体
        /// </summary>
        /// <returns></returns>
        protected override FontSchemeColor InitFontSchemeColor()
        {
            return new FontSchemeColor(ColorTranslator.FromHtml("#FFFFFF"), new Font("宋体", 9.0f));
        }
    }
}
