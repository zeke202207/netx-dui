using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Netx.Dui.DxControls.Controls
{
    [ToolboxItem(true)]
    public class DxTextBox : DxBasePannel
    {
        private readonly TextBoxItem textBoxItem = new TextBoxItem();
        protected HorizontalAlignment _textAlgin = HorizontalAlignment.Left;

        [Description("文字对齐方式"), Category("Dui")]
        [DefaultValue(typeof(ContentAlignment), "MiddleCenter")]
        public HorizontalAlignment TextAlign
        {
            get
            {
                return _textAlgin;
            }
            set
            {
                _textAlgin = value;
                this.textBoxItem.TextAlign = _textAlgin;
            }
        }

        public DxTextBox()
        {
            this.Padding = new Padding(5);
            textBoxItem.Location = new Point(
                this.Padding.Left + textBoxItem.Location.X,
                this.Padding.Top + textBoxItem.Location.Y);
            this.Controls.Add(textBoxItem);
            this.SizeChanged += DxTextBox_SizeChanged;
            this.TextChanged += DxTextBox_TextChanged;
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            SkinManager.ColorSchemeChanged += (s) =>
            {
                this.textBoxItem.Font = UseSkin ? SkinManager.Scheme.FontScheme.Font : this.Font;
                this.textBoxItem.ForeColor = UseSkin ? SkinManager.Scheme.FontScheme.GetColor(FontColorType.Primary) : this.ForeColor;
            };
            this.FontChanged += (s, e) => this.textBoxItem.Font = UseSkin ? SkinManager.Scheme.FontScheme.Font : this.Font;
            this.ForeColorChanged += (s, e) => this.textBoxItem.ForeColor = UseSkin ? SkinManager.Scheme.FontScheme.GetColor(FontColorType.Primary) : this.ForeColor;
        }

        private void DxTextBox_TextChanged(object sender, EventArgs e)
        {
            this.textBoxItem.Text = this.Text;
            this.textBoxItem.Invalidate();
        }

        private void DxTextBox_SizeChanged(object sender, EventArgs e)
        {
            textBoxItem.Width = this.Width - Padding.Left - Padding.Right;
            textBoxItem.Height = this.Height - Padding.Top - Padding.Bottom;
            textBoxItem.Top = this.Padding.Top;
            textBoxItem.Left = this.Padding.Left;
            textBoxItem.Invalidate();
        }

        #region 

        protected override void BackGroundColorChanged()
        {
            base.BackGroundColorChanged();
            this.textBoxItem.BackColor = BackgroundColor();
            this.textBoxItem.Invalidate();
        }

        protected override Color BackgroundColor()
        {
            this.textBoxItem.BackColor = base.BackgroundColor();
            return this.textBoxItem.BackColor;
        }

        #endregion

        #region 绘制

        protected override void OnControlPaint(DuiPaintEventArgs e)
        {
            
        }

        protected override void OnPaintIcon(DuiPaintEventArgs e)
        {
            
        }

        protected override void OnPaintForeground(DuiPaintEventArgs e)
        {
            
        }

        protected override void OnPaintAnimationLayer(DuiPaintEventArgs e)
        {
            
        }

        #endregion
    }
}
