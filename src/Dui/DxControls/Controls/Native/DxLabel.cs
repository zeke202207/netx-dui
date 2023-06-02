using Netx.Dui.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Netx.Dui.DxControls.Controls
{
    [ToolboxItem(true)]
    public class DxLabel : Label , ISkinManager
    {
        #region 私有变量

        [Browsable(false)]
        public DxSkinManager SkinManager => DxSkinManager.Instance;
        internal IPaintManager _paintManager = new PaintManager();
        private bool _useSkin = true;
        private bool _transparency =true;

        #endregion

        #region Dx 属性

        /// <summary>
        /// 是否使用皮肤配色
        /// </summary>
        [DefaultValue(true)]
        [Description("是否使用皮肤配色"), Category("Dui")]
        public bool UseSkin
        {
            get
            {
                return _useSkin;
            }
            set
            {
                _useSkin = value;
                this.Invalidate();
            }
        }

        [DefaultValue(true)]
        [Description("是否使用透明背景（假透明，与父控件背景颜色相同）"), Category("Dui")]
        public bool Transparency
        {
            get { return _transparency; }
            set 
            { 
                _transparency = value;
                this.Invalidate();
            }
        }

        #endregion

        public DxLabel()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint 
                | ControlStyles.SupportsTransparentBackColor 
                | ControlStyles.ResizeRedraw, 
                true);
            SetStyle(ControlStyles.UserPaint 
                | ControlStyles.Opaque, 
                false);
            UpdateStyles();
        }

        #region 私有方法

        //protected override CreateParams CreateParams
        //{
        //    get
        //    {
        //        CreateParams cp = base.CreateParams;
        //        cp.ExStyle |= 0x00000020;       // 实现透明样式
        //        return cp;
        //    }
        //}

        protected virtual void OnPaint(DuiPaintEventArgs e)
        {
            var g = e.Graphics;
            if (null != this.Parent?.BackColor)
                g.Clear(this.Parent.BackColor);
            OnPaintBackground(e);
            OnPaintForeground(e);
        }

        protected virtual void OnPaintBackground(DuiPaintEventArgs e)
        {
            var g = e.Graphics;
            var borderRect = GetBorderRect();
            using (var backgroundBrush = new DuiSolidBrush(BackgroundColor()))
            {
                g.FillRectangle(backgroundBrush, borderRect);
            }
        }

        protected virtual void OnPaintForeground(DuiPaintEventArgs e)
        {
            var g = e.Graphics;
            var rectImage = RectangleF.Empty;
            if (!string.IsNullOrWhiteSpace(Text))
            {
                var rectText = GetTextRect(e.ClipRectangle, rectImage, this.TextAlign);
                using (var txtBrush = new DuiSolidBrush(TextColor()))
                {
                    g.DrawString(Text, new DuiFont(TextFont(), this.TextAlign), txtBrush, rectText);
                }
            }
        }

        #endregion

        #region override

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            _paintManager.WndProcHandler(this, m.Msg, OnPaint);
        }

        #endregion


        #region 辅助方法 - 颜色

        /// <summary>
        /// 获取背景颜色
        /// </summary>
        /// <returns></returns>
        protected virtual Color BackgroundColor()
        {
            if (_transparency)
                return this.Parent == null ? this.BackColor : this.Parent.BackColor;
            return UseSkin ? SkinManager.Scheme.ColorScheme.GetColor(ColorType.Primary) : this.BackColor;
        }

        protected virtual Color TextColor()
        {
            if (!_useSkin)
                return this.ForeColor;
            return _transparency ? SkinManager.Scheme.FontScheme.GetColor(FontColorType.Transparency) : SkinManager.Scheme.FontScheme.GetColor(FontColorType.Primary);
        }

        protected virtual Font TextFont()
        {
            return UseSkin ? SkinManager.Scheme.FontScheme.Font : this.Font;
        }

        #endregion

        #region 辅助方法 - Bound

        /// <summary>
        /// 获取控件边框区域
        /// </summary>
        /// <returns></returns>
        protected virtual Rectangle GetBorderRect()
        {
            return new Rectangle(
                    this.DisplayRectangle.X + 1,
                    this.DisplayRectangle.Y + 1,
                    this.Width - 2,
                    this.Height - 2);
        }

        /// <summary>
        /// 获取文本
        /// </summary>
        /// <returns></returns>
        protected virtual RectangleF GetTextRect(RectangleF clipRectangle, RectangleF imageRect,ContentAlignment textAlign)
        {
            RectangleF txtRect = RectangleF.Empty;
            float offsizeX = 5;
            float offsizeY = 0;
            switch (textAlign)
            {
                case ContentAlignment.TopLeft:
                case ContentAlignment.MiddleLeft:
                case ContentAlignment.BottomLeft:
                    return new RectangleF()
                    {
                        X = clipRectangle.X + imageRect.X + +imageRect.Width + offsizeX,
                        Y = 0,
                        Width = clipRectangle.Width - imageRect.Width - offsizeX,
                        Height = clipRectangle.Height
                    };
                case ContentAlignment.TopCenter:
                    return new RectangleF()
                    {
                        X = clipRectangle.X + offsizeX,
                        Y = offsizeY + imageRect.Height,
                        Width = clipRectangle.Width - offsizeX,
                        Height = clipRectangle.Height - offsizeY - imageRect.Height
                    };
                case ContentAlignment.BottomCenter:
                    return new RectangleF()
                    {
                        X = clipRectangle.X + offsizeX,
                        Y = offsizeY,
                        Width = clipRectangle.Width - offsizeX,
                        Height = clipRectangle.Height - offsizeY - imageRect.Height
                    };
                case ContentAlignment.TopRight:
                case ContentAlignment.MiddleRight:
                case ContentAlignment.BottomRight:
                    return new RectangleF()
                    {
                        X = clipRectangle.X + offsizeX,
                        Y = 0,
                        Width = clipRectangle.Width - imageRect.Width - offsizeX,
                        Height = clipRectangle.Height
                    };
                default:
                case ContentAlignment.MiddleCenter:
                    return clipRectangle;
            }
        }

        #endregion
    }
}
