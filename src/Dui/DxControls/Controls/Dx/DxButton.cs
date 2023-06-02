using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Netx.Dui.DxControls
{
    [DefaultEvent("Click")]
    [DefaultProperty("Text")]
    [ToolboxItem(true)]
    public class DxButton : DxBaseControl, IButtonControl
    {
        /// <summary>
        /// 指定标识符以指示对话框的返回值
        /// </summary>
        [DefaultValue(DialogResult.None)]
        [Description("指定标识符以指示对话框的返回值"), Category("Dui")]
        public DialogResult DialogResult { get; set; } = DialogResult.None;

        public DxButton()
        {
            TabStop = true;
            base.MinimumSize = new Size(1, 1);
            Size = new Size(85, 35);
            Cursor = Cursors.Hand;
        }

        protected override void OnControlPaint(DuiPaintEventArgs e)
        {

        }

        /// <summary>
        /// 通知控件它是默认按钮
        /// </summary>
        /// <param name="value"></param>
        public void NotifyDefault(bool value)
        {

        }

        /// <summary>
        /// 执行点击事件
        /// </summary>
        public void PerformClick()
        {
            if (!this.Enabled)
                return;
            base.InvokeOnClick(this, EventArgs.Empty);
        }
    }
}
