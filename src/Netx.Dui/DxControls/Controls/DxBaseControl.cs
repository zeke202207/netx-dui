using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using Netx.Dui.Common;
using System.Runtime.Remoting.Contexts;
using System.IO;
using Netx.Dui.Win32.Struct;

namespace Netx.Dui.DxControls
{
    public abstract class DxBaseControl : DxControl
    {
        protected MouseStatus _mouseStatus = MouseStatus.Default;
        protected Color _backGroundColor = ColorTranslator.FromHtml("#409EFF");
        protected Color _backGroundHoverColor = ColorTranslator.FromHtml("#A0CFFF");
        protected Color _backGroundPressColor = ColorTranslator.FromHtml("#337ECC");
        protected Color _backGroundDisabledColor = ColorTranslator.FromHtml("#C6E2FF");
        protected Color _fontColor = ColorTranslator.FromHtml("#FFFFFF");
        protected Font _font;
        protected int _borderWidth = 2;
        protected WeightStyle _weightStyle = WeightStyle.Regular;
        protected ItalicStyle _italicStyle = ItalicStyle.Normal;
        protected string _text;
        protected ContentAlignment _textAlgin = ContentAlignment.MiddleCenter;
        protected ContentAlignment _imageAlgin = ContentAlignment.MiddleCenter;
        protected System.Drawing.Bitmap _image;

        #region Public Properties

        [Description("背景颜色"), Category("Dui")]
        public Color BackGroundColor
        {
            get
            {
                return _backGroundColor;
            }
            set
            {
                _backGroundColor = value;
                this.Invalidate();
            }
        }

        [Description("鼠标划过背景颜色"), Category("Dui")]
        public Color BackGroundHoverColor
        {
            get
            {
                return _backGroundHoverColor;
            }
            set
            {
                _backGroundHoverColor = value;
                this.Invalidate();
            }
        }

        [Description("鼠标按下背景颜色"), Category("Dui")]
        public Color BackGroundPressColor
        {
            get
            {
                return _backGroundPressColor;
            }
            set
            {
                _backGroundPressColor = value;
                this.Invalidate();
            }
        }

        [Description("控件禁用背景颜色"), Category("Dui")]
        public Color BackGroundDisabledColor
        {
            get
            {
                return _backGroundDisabledColor;
            }
            set
            {
                _backGroundDisabledColor = value;
                this.Invalidate();
            }
        }

        [Description("文字颜色"), Category("Dui")]
        public Color FontColor
        {
            get
            {
                return _fontColor;
            }
            set
            {
                _fontColor = value;
                this.Invalidate();
            }
        }

        [DefaultValue("Dui")]
        [Description("文本内容"), Category("Dui")]
        public override string Text
        {
            get
            {
                return _text;
            }
            set
            {
                _text = value;
                this.Invalidate();
            }
        }

        [Description("字体"), Category("Dui")]
        public override Font Font
        {
            get 
            {
                if (null == _font)
                    _font = SkinManager.Scheme.fontSchemeColor.Font;
                return _font;
            }
            set
            {
                _font = value;
                _weightStyle = _font.Bold ? WeightStyle.Bold : WeightStyle.Regular;
                _italicStyle = _font.Italic ? ItalicStyle.Italic : ItalicStyle.Normal;
                this.Invalidate();
            }
        }

        [DefaultValue(2)]
        [Description("边框宽度"), Category("Dui")]
        public int BorderWidth
        {
            get
            {
                return _borderWidth;
            }
            set
            {
                _borderWidth = value;
                this.Invalidate();
            }
        }

        [Description("文字对齐方式"), Category("Dui")]
        [DefaultValue(typeof(ContentAlignment), "MiddleCenter")]
        public ContentAlignment TextAlign
        {
            get
            {
                return _textAlgin;
            }
            set
            {
                _textAlgin = value;
                this.Invalidate();
            }
        }

        [Description("图片对齐方式"), Category("Dui")]
        [DefaultValue(typeof(ContentAlignment), "MiddleCenter")]
        public ContentAlignment ImageAlign
        {
            get
            {
                return _imageAlgin;
            }
            set
            {
                _imageAlgin = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// 图标
        /// </summary>
        [Description("文字与图片位置关系"), Category("Dui")]
        public System.Drawing.Bitmap Image
        {
            get
            {
                return _image;
            }
            set
            {
                _image = value;
                this.Invalidate();
            }
        }

        #endregion

        public DxBaseControl()
        {
            //this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            //UpdateStyles();
            //BackColor = Color.Transparent;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        protected override void OnDuiPaint(DuiPaintEventArgs e)
        {
            DuiGraphicsState backupGraphicsState = e.Graphics.Save();
            //TODO:
            //e.Graphics.TranslateTransform(this.X, this.Y); //偏移一下坐标系将控件的坐标定义为坐标系原点
            //PointF center = new PointF(this.BorderWidth + this.CenterX, this.BorderWidth + this.CenterY);
            //e.Graphics.RotateTransform(this.Rotate, center);
            //e.Graphics.SkewTransform(this.Skew, center);
            //e.Graphics.ScaleTransform(this.Scale, center);
            e.Graphics.PushLayer(this.Width, this.Height); //背景图层

            #region OnPaintBackground

            DuiGraphicsState backupOnPaintBackgroundGraphicsState = e.Graphics.Save();
            PaintBackground(new DuiPaintEventArgs(e.Graphics, new RectangleF(0, 0, this.Width, this.Height))); //绘制背景
            e.Graphics.Restore(backupOnPaintBackgroundGraphicsState);

            #endregion

            if (this.BorderWidth != 0)
            {
                e.Graphics.PopLayer();
                e.Graphics.TranslateTransform(this.BorderWidth, this.BorderWidth); //偏移一个边框的坐标系
                e.Graphics.PushLayer(this.ClientSize.Width, this.ClientSize.Height); //背景图层
            }

            #region OnPaint

            DuiGraphicsState backupOnPaintGraphicsState = e.Graphics.Save();
            OnControlPaint(new DuiPaintEventArgs(e.Graphics, new RectangleF(0, 0, ClientSize.Width, this.ClientSize.Height)));
            e.Graphics.Restore(backupOnPaintGraphicsState);

            #endregion

            e.Graphics.TranslateTransform(-this.BorderWidth, -this.BorderWidth);
            e.Graphics.PopLayer();

            #region OnPaintIcon

            DuiGraphicsState backupOnPaintIconGraphicsState = e.Graphics.Save();
            OnPaintIcon(new DuiPaintEventArgs(e.Graphics, new RectangleF(0, 0, this.Width, this.Height)));
            e.Graphics.Restore(backupOnPaintIconGraphicsState);

            #endregion

            #region OnPaintForeground

            DuiGraphicsState backupOnPaintForegroundGraphicsState = e.Graphics.Save();
            OnPaintForeground(new DuiPaintEventArgs(e.Graphics, new RectangleF(0, 0, this.Width, this.Height)));
            e.Graphics.Restore(backupOnPaintForegroundGraphicsState);

            #endregion

            e.Graphics.Restore(backupGraphicsState);
        }

        /// <summary>
        /// 控件独立渲染器
        /// </summary>
        /// <param name="context"></param>
        protected abstract void OnControlPaint(DuiPaintEventArgs e);

        /// <summary>
        /// 背景绘制
        /// </summary>
        /// <param name="context"></param>
        protected virtual void PaintBackground(DuiPaintEventArgs e)
        {
            var g = e.Graphics;
            if (null != this.Parent?.BackColor)
                g.Clear(this.Parent.BackColor);
            var borderRect = GetBorderRect();
            using (var pen = new DuiPen(_backGroundColor))
            {
                g.DrawRectangle(pen, borderRect);
                using (var backgroundBrush = new DuiSolidBrush(BackgroundColor()))
                {
                    g.FillRectangle(backgroundBrush, borderRect);
                }
            }
            //using (var bgBrush = DefaultBrush(context.RenderTarget, BackgroundDColor()))
            //{
            //    if (null != this.Parent?.BackColor)
            //        context.RenderTarget.Clear(this.Parent.BackColor);
            //    var borderRect = GetBorderRect();
            //    context.RenderTarget.DrawRectangle(borderRect, bgBrush, _borderWidth);
            //    var fillRect = borderRect.Inflate(-2, -2, -1);
            //    context.RenderTarget.FillRectangle(fillRect, bgBrush);
            //}
        }

        /// <summary>
        /// 图标绘制
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnPaintIcon(DuiPaintEventArgs e)
        {
            var g = e.Graphics;
            var rectImage = RectangleF.Empty;
            if (null != _image)
            {
                rectImage = GetImageRect(e.ClipRectangle, _imageAlgin, new Size(_image.Width, _image.Height));
                g.DrawImage(DuiImage.FromImage(_image), rectImage);
            }
        }

        /// <summary>
        /// 文本绘制
        /// </summary>
        /// <param name="context"></param>
        protected virtual void OnPaintForeground(DuiPaintEventArgs e)
        {
            var g = e.Graphics;
            var rectImage = RectangleF.Empty;
            if (null != _image)
                rectImage = GetImageRect(e.ClipRectangle, _imageAlgin, new Size(_image.Width, _image.Height));
            if (!string.IsNullOrWhiteSpace(_text))
            {
                var rectText = GetTextRect(e.ClipRectangle, rectImage, _imageAlgin, _textAlgin);
                using (var txtBrush = new DuiSolidBrush(TextColor()))
                {
                    g.DrawString(_text, new DuiFont(this.Font,_textAlgin), txtBrush, rectText);
                }
            }
        }

        /// <summary>
        /// 获取背景颜色
        /// </summary>
        /// <returns></returns>
        protected virtual Color BackgroundColor()
        {
            if (!this.Enabled)
                return UseSkin ? SkinManager.Scheme.bgSchemeColor.DisabledColor : _backGroundDisabledColor;
            switch (_mouseStatus)
            {
                default:
                case MouseStatus.Default:
                    return UseSkin ? SkinManager.Scheme.bgSchemeColor.Primary : _backGroundColor;
                case MouseStatus.Hover:
                    return UseSkin ? SkinManager.Scheme.bgSchemeColor.HoverColor : _backGroundHoverColor;
                case MouseStatus.Pressed:
                    return UseSkin ? SkinManager.Scheme.bgSchemeColor.PressedColor : _backGroundPressColor;
            }
        }

        /// <summary>
        /// 文本颜色
        /// </summary>
        /// <returns></returns>
        protected virtual Color TextColor()
        {
            return UseSkin ? SkinManager.Scheme.fontSchemeColor.Primary : _fontColor;
        }

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
        /// 获取图像region
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        protected virtual RectangleF GetImageRect(RectangleF clipRectangle, ContentAlignment imageAlign , Size imageSize)
        {
            //TODO: 这里可以优化，目前没有适配所有的align
            float offsizeX = 5;
            float offsizeY = 5;
            SizeF sizeF = new Size(0, 0);
            if (_image != null)
                sizeF = new SizeF(Math.Min(clipRectangle.Width, imageSize.Width), Math.Min(clipRectangle.Height, imageSize.Height));
            float imageX = 0;
            float imageY = 0;
            switch (imageAlign)
            {
                case ContentAlignment.TopLeft:
                    imageX = base.Padding.Left + offsizeX;
                    imageY = base.Padding.Top;
                    break;
                case ContentAlignment.TopCenter:
                    imageX = (clipRectangle.Width - sizeF.Width) / 2f;
                    imageY = base.Padding.Top;
                    break;
                case ContentAlignment.TopRight:
                    imageX = (clipRectangle.Width - base.Padding.Right) - offsizeX - sizeF.Width;
                    imageY = base.Padding.Top;
                    break;
                case ContentAlignment.MiddleLeft:
                    imageX = base.Padding.Left + offsizeX;
                    imageY = (clipRectangle.Height - sizeF.Height) / 2;
                    break;
                case ContentAlignment.MiddleCenter:
                    imageX = (clipRectangle.Width - sizeF.Width) / 2;
                    imageY = (clipRectangle.Height - sizeF.Height) / 2;
                    break;
                case ContentAlignment.MiddleRight:
                    imageX = (clipRectangle.Width - base.Padding.Right) - offsizeX - sizeF.Width;
                    imageY = (clipRectangle.Height - sizeF.Height) / 2;
                    break;
                case ContentAlignment.BottomLeft:
                    imageX = base.Padding.Left + offsizeX;
                    imageY = (base.Height - base.Padding.Bottom) - offsizeY - sizeF.Height;
                    break;
                case ContentAlignment.BottomCenter:
                    imageX = (clipRectangle.Width - sizeF.Width) / 2;
                    imageY = (clipRectangle.Height - base.Padding.Bottom) - offsizeY - sizeF.Height;
                    break;
                case ContentAlignment.BottomRight:
                    imageX = (clipRectangle.Width - base.Padding.Right) - offsizeX - sizeF.Width;
                    imageY = (clipRectangle.Height - base.Padding.Bottom) - offsizeY - sizeF.Height;
                    break;
            }
            return new RectangleF(
                    imageX,
                    imageY,
                    sizeF.Width, 
                    sizeF.Height);
        }

        /// <summary>
        /// 获取文本
        /// </summary>
        /// <returns></returns>
        protected virtual RectangleF GetTextRect(RectangleF clipRectangle, RectangleF imageRect, ContentAlignment imageAlign, ContentAlignment textAlign)
        {
            RectangleF txtRect = RectangleF.Empty;
            float offsizeX = 5;
            float offsizeY = 5;
            switch (imageAlign)
            {
                case ContentAlignment.TopLeft:
                case ContentAlignment.MiddleLeft:
                case ContentAlignment.BottomLeft:
                    return new RectangleF()
                    {
                        X = clipRectangle.X + imageRect.X + + imageRect.Width + offsizeX,
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

            ////TODO: 这里可以优化，目前没有适配所有的align
            //float offsizeX = 5;
            //float offsizeY = 5;
            //float imageW = null == image ? 0 : image.Width;
            //float imageH = null == image ? 0 : image.Height;
            //SizeF sizeF = new Size(0, 0);
            //if (_image != null)
            //    sizeF = new SizeF(Math.Min(clipRectangle.Width, imageW), Math.Min(clipRectangle.Height, imageH));
            //float imageX = 0;
            //float imageY = 0;
            //switch (_imageAlgin)
            //{
            //    case ContentAlignment.TopLeft:
            //        imageX = base.Padding.Left;
            //        imageY = base.Padding.Top;
            //        break;
            //    case ContentAlignment.TopCenter:
            //        imageX = (Width - sizeF.Width) / 2f;
            //        imageY = base.Padding.Top;
            //        break;
            //    case ContentAlignment.TopRight:
            //        imageX = (base.Width - base.Padding.Right) - offsizeX - sizeF.Width;
            //        imageY = base.Padding.Top;
            //        break;
            //    case ContentAlignment.MiddleLeft:
            //        imageX = base.Padding.Left;
            //        imageY = (base.Height - sizeF.Height) / 2;
            //        break;
            //    case ContentAlignment.MiddleCenter:
            //        imageX = (base.Width - sizeF.Width) / 2;
            //        imageY = (base.Height - sizeF.Height) / 2;
            //        break;
            //    case ContentAlignment.MiddleRight:
            //        imageX = (base.Width - base.Padding.Right) - offsizeX - sizeF.Width;
            //        imageY = (base.Height - sizeF.Height) / 2;
            //        break;
            //    case ContentAlignment.BottomLeft:
            //        imageX = base.Padding.Left;
            //        imageY = (base.Height - base.Padding.Bottom) - offsizeY - sizeF.Height;
            //        break;
            //    case ContentAlignment.BottomCenter:
            //        imageX = (base.Width - sizeF.Width) / 2;
            //        imageY = (base.Height - base.Padding.Bottom) - offsizeY - sizeF.Height;
            //        break;
            //    case ContentAlignment.BottomRight:
            //        imageX = (base.Width - base.Padding.Right) - offsizeX - sizeF.Width;
            //        imageY = (base.Height - base.Padding.Bottom) - offsizeY - sizeF.Height;
            //        break;
            //}
            //var imgTextOffsize = sizeF.Width > 0 ? offsizeX * 2 : offsizeX;
            //return (
            //    textRect: new RectangleF(
            //        this.DisplayRectangle.X + sizeF.Width + imgTextOffsize,
            //        this.DisplayRectangle.Y + offsizeY,
            //        this.Width - sizeF.Width - imgTextOffsize,
            //        this.Height - offsizeY),
            //    imageRect: new RectangleF(
            //        imageX,
            //        imageY,
            //        imageX + sizeF.Width, imageY + sizeF.Height));
        }

        ///// <summary>
        ///// 默认笔刷
        ///// </summary>
        ///// <param name="target"></param>
        ///// <param name="color"></param>
        ///// <returns></returns>
        //protected Brush DefaultBrush(RenderTarget target, DColor color)
        //{
        //    return new SolidColorBrush(target, color);
        //}

        ///// <summary>
        ///// 获取背景颜色
        ///// </summary>
        ///// <returns></returns>
        //protected virtual DColor BackgroundDColor()
        //{
        //    if (!this.Enabled)
        //        return UseSkin ? SkinManager.Scheme.bgSchemeColor.DisabledColor : _backGroundDisabledColor;
        //    switch (_mouseStatus)
        //    {
        //        default:
        //        case MouseStatus.Default:
        //            return UseSkin ? SkinManager.Scheme.bgSchemeColor.Primary : _backGroundColor;
        //        case MouseStatus.Hover:
        //            return UseSkin ? SkinManager.Scheme.bgSchemeColor.HoverColor : _backGroundHoverColor;
        //        case MouseStatus.Pressed:
        //            return UseSkin ? SkinManager.Scheme.bgSchemeColor.PressedColor : _backGroundPressColor;
        //    }
        //}

        ///// <summary>
        ///// 文本颜色
        ///// </summary>
        ///// <returns></returns>
        //protected virtual DColor TextDColor()
        //{
        //    return UseSkin ? SkinManager.Scheme.fontSchemeColor.Primary : _fontColor;
        //}

        ///// <summary>
        ///// 获取字体
        ///// </summary>
        ///// <returns></returns>
        //protected virtual Font TextDFont()
        //{
        //    return UseSkin ? SkinManager.Scheme.fontSchemeColor.Font : this._font;
        //}

        ///// <summary>
        ///// 获取圆角矩形Path
        ///// this.Region = new Region(GetRoundedRectPath(rect));
        ///// </summary>
        ///// <param name="roundRect"></param>
        ///// <returns></returns>
        //protected GraphicsPath GetRoundedRectPath(RoundedRectangle roundRect)
        //{
        //    float diameter = roundRect.RadiusX;
        //    System.Drawing.RectangleF arcRect = new System.Drawing.RectangleF(roundRect.Rect.Left, roundRect.Rect.Top, diameter, diameter);
        //    GraphicsPath path = new GraphicsPath();
        //    path.AddArc(arcRect, 180, 90);
        //    arcRect.X = roundRect.Rect.Right - diameter;
        //    path.AddArc(arcRect, 270, 90);
        //    arcRect.Y = roundRect.Rect.Bottom - diameter;
        //    path.AddArc(arcRect, 0, 90);
        //    arcRect.X = roundRect.Rect.Left;
        //    path.AddArc(arcRect, 90, 90);
        //    path.CloseFigure();
        //    return path;
        //}

        protected override void ReRegion()
        {
            base.ReRegion();
        }

    }
}
