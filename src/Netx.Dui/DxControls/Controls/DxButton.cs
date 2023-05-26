using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using Netx.Dui.Common;

namespace Netx.Dui.DxControls
{
    [DefaultEvent("Click")]
    [DefaultProperty("Text")]
    [ToolboxItem(true)]
    public class DxButton : DxBaseControl, IButtonControl
    {
        private float _radius = 0.0f;

        [Description("边框圆角半径(RoundedBorder为True生效)"), Category("Dui")]
        [DefaultValue(0.0f)]
        public float Radius
        {
            get
            {
                return _radius;
            }
            set
            {
                _radius = Math.Max(value, 0.0f);
                this.Invalidate();
            }
        }

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

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            base._mouseStatus = MouseStatus.Hover;
            this.Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            base._mouseStatus = MouseStatus.Default;
            this.Invalidate();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            base._mouseStatus = MouseStatus.Pressed;
            this.Invalidate();
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            base._mouseStatus = MouseStatus.Default;
            this.Invalidate();
        }

        protected override void OnControlPaint(DuiPaintEventArgs e)
        {
            
        }

        protected override void PaintBackground(DuiPaintEventArgs e)
        {
            if (_radius >= 0)
            {
                var g = e.Graphics;
                DuiGraphicsState backupOnPaintBackgroundGraphicsState = g.Save();
                if (null != this.Parent?.BackColor)
                    g.Clear(this.Parent.BackColor);
                using (var pen = new DuiPen(BackgroundColor()))
                {
                    pen.Width = base.BorderWidth;
                    var borderRect = base.GetBorderRect();
                    g.DrawRoundedRectangle(pen, borderRect, _radius);
                    using (var backgroundBrush = new DuiSolidBrush(BackgroundColor()))
                    {
                        g.FillRoundedRectangle(backgroundBrush, borderRect, _radius);
                    }
                }
                e.Graphics.Restore(backupOnPaintBackgroundGraphicsState);
            }
            else
                base.PaintBackground(e);
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
