using SharpDX.Direct2D1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DColor = SharpDX.Color;
using DBrush = SharpDX.Direct2D1.Brush;
using DBitmap = SharpDX.Direct2D1.Bitmap;
using Color = System.Drawing.Color;
using Font = System.Drawing.Font;
using SharpDX.Mathematics.Interop;
using System.Drawing.Drawing2D;
using SharpDX;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace Netx.Dui.DxControls
{
    public abstract class DxBaseControl : DxControl
    {
        protected MouseStatus _mouseStatus = MouseStatus.Default;
        protected DColor _backGroundColor = ColorTranslator.FromHtml("#409EFF").ToDColor();
        protected DColor _backGroundHoverColor = ColorTranslator.FromHtml("#A0CFFF").ToDColor();
        protected DColor _backGroundPressColor = ColorTranslator.FromHtml("#337ECC").ToDColor();
        protected DColor _backGroundDisabledColor = ColorTranslator.FromHtml("#C6E2FF").ToDColor();
        protected DColor _fontColor = ColorTranslator.FromHtml("#FFFFFF").ToDColor();
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
                return _backGroundColor.ToColor();
            }
            set
            {
                _backGroundColor = value.ToDColor();
                this.Invalidate();
            }
        }

        [Description("鼠标划过背景颜色"), Category("Dui")]
        public Color BackGroundHoverColor
        {
            get
            {
                return _backGroundHoverColor.ToColor();
            }
            set
            {
                _backGroundHoverColor = value.ToDColor();
                this.Invalidate();
            }
        }

        [Description("鼠标按下背景颜色"), Category("Dui")]
        public Color BackGroundPressColor
        {
            get
            {
                return _backGroundPressColor.ToColor();
            }
            set
            {
                _backGroundPressColor = value.ToDColor();
                this.Invalidate();
            }
        }

        [Description("控件禁用背景颜色"), Category("Dui")]
        public Color BackGroundDisabledColor
        {
            get
            {
                return _backGroundDisabledColor.ToColor();
            }
            set
            {
                _backGroundDisabledColor = value.ToDColor();
                this.Invalidate();
            }
        }

        [Description("文字颜色"), Category("Dui")]
        public Color FontColor
        {
            get
            {
                return _fontColor.ToColor();
            }
            set
            {
                _fontColor = value.ToDColor();
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
        protected override void OnDxPaint(DxDeviceManager context)
        {
            PaintBackground(context);
            PainTextContent(context);
            PaintRender(context);
        }

        /// <summary>
        /// 控件独立渲染器
        /// </summary>
        /// <param name="context"></param>
        protected abstract void PaintRender(DxDeviceManager context);

        /// <summary>
        /// 背景绘制
        /// </summary>
        /// <param name="context"></param>
        protected virtual void PaintBackground(DxDeviceManager context)
        {
            using (var bgBrush = DefaultBrush(context.RenderTarget, BackgroundDColor()))
            {
                if (null != this.Parent?.BackColor)
                    context.RenderTarget.Clear(this.Parent.BackColor.ToDColor());
                var borderRect = GetBorderRect();
                context.RenderTarget.DrawRectangle(borderRect, bgBrush, _borderWidth);
                var fillRect = borderRect.Inflate(-2, -2, -1);
                context.RenderTarget.FillRectangle(fillRect, bgBrush);
            }
        }

        /// <summary>
        /// 文本绘制
        /// </summary>
        /// <param name="context"></param>
        protected virtual void PainTextContent(DxDeviceManager context)
        {
            var rect = GetTextImageRect();
            if (!string.IsNullOrWhiteSpace(_text))
            {
                using (var brush = DefaultBrush(context.RenderTarget, TextDColor()))
                {
                    var font = TextDFont();
                    var textFormat = TextFormatHelper.ToDxTextFormat(font.Name, font.Size, _weightStyle, _italicStyle, _textAlgin);
                    context.RenderTarget.DrawText(
                        _text,
                        textFormat,
                        rect.textRect,
                        brush
                        );
                }
            }
            if (rect.imageRect.Right > 0)
            {
                DBitmap bmp = Image.MSBitmapToDxBitmap(context.RenderTarget);
                if (null != bmp)
                    context.RenderTarget.DrawBitmap(bmp, rect.imageRect, 1, BitmapInterpolationMode.NearestNeighbor);
            }
        }

        /// <summary>
        /// 获取控件边框区域
        /// </summary>
        /// <returns></returns>
        protected virtual RawRectangleF GetBorderRect()
        {
            return new RawRectangleF(
                    this.DisplayRectangle.X + 1,
                    this.DisplayRectangle.Y + 1,
                    this.Width - 2,
                    this.Height - 2);
        }

        /// <summary>
        /// 获取文本(图标)区域
        /// </summary>
        /// <returns></returns>
        protected virtual (RawRectangleF textRect, RawRectangleF imageRect) GetTextImageRect()
        {
            //TODO: 这里可以优化，目前没有适配所有的align
            float offsizeX = 5;
            float offsizeY = 5;
            SizeF sizeF = new SizeF(0f, 0f);
            if (_image != null)
                sizeF = new SizeF(Math.Min(this.DisplayRectangle.Width, _image.Width), Math.Min(this.DisplayRectangle.Height, _image.Height));
            float imageX = 0.0f;
            float imageY = 0.0f;
            switch (_imageAlgin)
            {
                case ContentAlignment.TopLeft:
                    imageX = base.Padding.Left;
                    imageY = base.Padding.Top;
                    break;
                case ContentAlignment.TopCenter:
                    imageX = ((float)Width - sizeF.Width) / 2f;
                    imageY = base.Padding.Top;
                    break;
                case ContentAlignment.TopRight:
                    imageX = (float)(base.Width - base.Padding.Right) - offsizeX - sizeF.Width;
                    imageY = base.Padding.Top;
                    break;
                case ContentAlignment.MiddleLeft:
                    imageX = base.Padding.Left;
                    imageY = ((float)base.Height - sizeF.Height) / 2f;
                    break;
                case ContentAlignment.MiddleCenter:
                    imageX = ((float)base.Width - sizeF.Width) / 2f;
                    imageY = ((float)base.Height - sizeF.Height) / 2f;
                    break;
                case ContentAlignment.MiddleRight:
                    imageX = (float)(base.Width - base.Padding.Right) - offsizeX - sizeF.Width;
                    imageY = ((float)base.Height - sizeF.Height) / 2f;
                    break;
                case ContentAlignment.BottomLeft:
                    imageX = base.Padding.Left;
                    imageY = (float)(base.Height - base.Padding.Bottom) - offsizeY - sizeF.Height;
                    break;
                case ContentAlignment.BottomCenter:
                    imageX = ((float)base.Width - sizeF.Width) / 2f;
                    imageY = (float)(base.Height - base.Padding.Bottom) - offsizeY - sizeF.Height;
                    break;
                case ContentAlignment.BottomRight:
                    imageX = (float)(base.Width - base.Padding.Right) - offsizeX - sizeF.Width;
                    imageY = (float)(base.Height - base.Padding.Bottom) - offsizeY - sizeF.Height;
                    break;
            }
            var imgTextOffsize = sizeF.Width > 0 ? offsizeX * 2 : offsizeX;
            return (
                textRect: new RawRectangleF(
                    this.DisplayRectangle.X + sizeF.Width + imgTextOffsize,
                    this.DisplayRectangle.Y + offsizeY,
                    this.Width - sizeF.Width - imgTextOffsize,
                    this.Height - offsizeY),
                imageRect: new RawRectangleF(
                    imageX, 
                    imageY,
                    imageX  + sizeF.Width , imageY +  sizeF.Height ));
        }

        /// <summary>
        /// 默认笔刷
        /// </summary>
        /// <param name="target"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        protected DBrush DefaultBrush(RenderTarget target, DColor color)
        {
            return new SolidColorBrush(target, color);
        }

        /// <summary>
        /// 获取背景颜色
        /// </summary>
        /// <returns></returns>
        protected virtual DColor BackgroundDColor()
        {
            if (!this.Enabled)
                return UseSkin ? SkinManager.Scheme.bgSchemeColor.DisabledColor.ToDColor() : _backGroundDisabledColor;
            switch (_mouseStatus)
            {
                default:
                case MouseStatus.Default:
                    return UseSkin ? SkinManager.Scheme.bgSchemeColor.Primary.ToDColor() : _backGroundColor;
                case MouseStatus.Hover:
                    return UseSkin ? SkinManager.Scheme.bgSchemeColor.HoverColor.ToDColor() : _backGroundHoverColor;
                case MouseStatus.Pressed:
                    return UseSkin ? SkinManager.Scheme.bgSchemeColor.PressedColor.ToDColor() : _backGroundPressColor;
            }
        }

        /// <summary>
        /// 文本颜色
        /// </summary>
        /// <returns></returns>
        protected virtual DColor TextDColor()
        {
            return UseSkin ? SkinManager.Scheme.fontSchemeColor.Primary.ToDColor() : _fontColor;
        }

        /// <summary>
        /// 获取字体
        /// </summary>
        /// <returns></returns>
        protected virtual Font TextDFont()
        {
            return UseSkin ? SkinManager.Scheme.fontSchemeColor.Font : this._font;
        }

        /// <summary>
        /// 获取圆角矩形Path
        /// this.Region = new Region(GetRoundedRectPath(rect));
        /// </summary>
        /// <param name="roundRect"></param>
        /// <returns></returns>
        protected GraphicsPath GetRoundedRectPath(RoundedRectangle roundRect)
        {
            float diameter = roundRect.RadiusX;
            System.Drawing.RectangleF arcRect = new System.Drawing.RectangleF(roundRect.Rect.Left, roundRect.Rect.Top, diameter, diameter);
            GraphicsPath path = new GraphicsPath();
            path.AddArc(arcRect, 180, 90);
            arcRect.X = roundRect.Rect.Right - diameter;
            path.AddArc(arcRect, 270, 90);
            arcRect.Y = roundRect.Rect.Bottom - diameter;
            path.AddArc(arcRect, 0, 90);
            arcRect.X = roundRect.Rect.Left;
            path.AddArc(arcRect, 90, 90);
            path.CloseFigure();
            return path;
        }

        protected override void ReRegion()
        {
            base.ReRegion();
        }

    }
}
