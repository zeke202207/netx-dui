using Netx.Dui.Common;
using Netx.Dui.DxControls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Netx.Dui
{
    /// <summary>
    /// 绘制管理类
    /// </summary>
    internal interface IPaintManager
    {
        /// <summary>
        /// 用于绘制的Graphics对象
        /// </summary>
        DuiGraphics DGraphics { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="control">创建绘制对象的控件</param>
        /// <param name="msg">系统消息</param>
        /// <param name="OnPaint">绘制委托</param>
        void WndProcHandler(Control control, int msg, Action<DuiPaintEventArgs> OnPaint);
    }
}
