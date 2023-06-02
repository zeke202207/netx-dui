using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.IO;
using Netx.Dui.Win32.Struct;

namespace Netx.Dui.DxControls
{
    public abstract class DxBaseInteraction : DxBasePannel
    {
        #region 私有变量

        protected MouseStatus _mouseStatus = MouseStatus.Default;
        protected Color _backGroundHoverColor = ColorTranslator.FromHtml("#A0CFFF");
        protected Color _backGroundPressColor = ColorTranslator.FromHtml("#337ECC");
        protected Color _backGroundDisabledColor = ColorTranslator.FromHtml("#C6E2FF");
        protected Color _fontColor = ColorTranslator.FromHtml("#FFFFFF");
        protected Font _font;
        protected WeightStyle _weightStyle = WeightStyle.Regular;
        protected ItalicStyle _italicStyle = ItalicStyle.Normal;
        protected string _text;
        protected ContentAlignment _textAlgin = ContentAlignment.MiddleCenter;
        protected ContentAlignment _imageAlgin = ContentAlignment.MiddleCenter;
        protected System.Drawing.Bitmap _image;

        #region 动画特效

        private readonly AnimationManager _animationManager = null;

        #endregion

        #endregion

        #region 设计器属性

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
        public Font DFont
        {
            get
            {
                if (null == _font)
                    _font = SkinManager.Scheme.FontScheme.Font;
                return _font;
            }
            set
            {
                if (null == value)
                    _font = SkinManager.Scheme.FontScheme.Font;
                _font = value;
                _weightStyle = _font.Bold ? WeightStyle.Bold : WeightStyle.Regular;
                _italicStyle = _font.Italic ? ItalicStyle.Italic : ItalicStyle.Normal;
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

        #region 停用属性

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Description("字体"), Category("Dui")]
        public override Font Font
        {
            get
            {
                if (null == _font)
                    _font = SkinManager.Scheme.FontScheme.Font;
                return _font;
            }
            set
            {
                if (null == value)
                    _font = SkinManager.Scheme.FontScheme.Font;
                _font = value;
                _weightStyle = _font.Bold ? WeightStyle.Bold : WeightStyle.Regular;
                _italicStyle = _font.Italic ? ItalicStyle.Italic : ItalicStyle.Normal;
                this.Invalidate();
            }
        }

        #endregion

        #region 构造函数

        /// <summary>
        /// dx控件实例对象
        /// </summary>
        public DxBaseInteraction()
        {
            _animationManager = new AnimationManager(false)
            {
                Increment = 0.03,
                AnimationType = AnimationType.EaseOut
            };
            _animationManager.OnAnimationProgress += sender => Invalidate();
        }

        #endregion

        #region 控件绘制

        /// <summary>
        /// 02_控件独立渲染器
        /// </summary>
        /// <param name="context"></param>
        protected override void OnControlPaint(DuiPaintEventArgs e)
        {

        }

        /// <summary>
        /// 03_图标绘制
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaintIcon(DuiPaintEventArgs e)
        {
            var g = e.Graphics;
            var rectImage = RectangleF.Empty;
            if (null != _image)
            {
                rectImage = GetIconRect(e.ClipRectangle, _imageAlgin, new Size(_image.Width, _image.Height));
                g.DrawImage(DuiImage.FromImage(_image), rectImage);
            }
        }

        /// <summary>
        /// 04_文本绘制
        /// </summary>
        /// <param name="context"></param>
        protected override void OnPaintForeground(DuiPaintEventArgs e)
        {
            var g = e.Graphics;
            var rectImage = RectangleF.Empty;
            if (null != _image)
                rectImage = GetIconRect(e.ClipRectangle, _imageAlgin, new Size(_image.Width, _image.Height));
            if (!string.IsNullOrWhiteSpace(_text))
            {
                var rectText = GetTextRect(e.ClipRectangle, rectImage, _textAlgin);
                using (var txtBrush = new DuiSolidBrush(TextColor()))
                {
                    g.DrawString(_text, new DuiFont(TextFont(), _textAlgin), txtBrush, rectText);
                }
            }
        }

        /// <summary>
        /// 05_动画蒙版
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaintAnimationLayer(DuiPaintEventArgs e)
        {
            var g = e.Graphics;
            if (_animationManager.IsAnimating())
            {
                for (var i = 0; i < _animationManager.GetAnimationCount(); i++)
                {
                    var animationValue = _animationManager.GetProgress(i);
                    var animationSource = _animationManager.GetSource(i);
                    using (var rippleBrush = new DuiSolidBrush(
                        Color.FromArgb((int)(100 - (animationValue * 100)),
                        SkinManager.Scheme.ColorScheme.GetColor(ColorType.Animation))))
                    {
                        var rippleSize = (int)(animationValue * Width * 2);
                        g.FillEllipse(rippleBrush, 
                            new Rectangle(animationSource.X - rippleSize / 2, animationSource.Y - rippleSize / 2, rippleSize, rippleSize));
                    }
                }
            }
        }

        #endregion

        #region 辅助方法 - 颜色

        /// <summary>
        /// 文本颜色
        /// </summary>
        /// <returns></returns>
        protected virtual Color TextColor()
        {
            if (!UseSkin)
                return _fontColor;
            return _transparency ? 
                SkinManager.Scheme.FontScheme.GetColor(FontColorType.Transparency) : 
                SkinManager.Scheme.FontScheme.GetColor(FontColorType.Primary);
        }

        /// <summary>
        /// 获取字体
        /// </summary>
        /// <returns></returns>
        protected virtual Font TextFont()
        {
            return UseSkin ? SkinManager.Scheme.FontScheme.Font : _font;
        }

        #endregion

        #region 辅助方法 - Bound

        /// <summary>
        /// 获取图像region
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        protected virtual RectangleF GetIconRect(RectangleF clipRectangle, ContentAlignment imageAlign , Size imageSize)
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
        protected virtual RectangleF GetTextRect(RectangleF clipRectangle, RectangleF imageRect, ContentAlignment textAlign)
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

        #endregion

        #region 鼠标事件

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            _mouseStatus = MouseStatus.Hover;
            this.Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            _mouseStatus = MouseStatus.Default;
            this.Invalidate();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            _mouseStatus = MouseStatus.Pressed; 
            _animationManager.StartNewAnimation(AnimationDirection.In, e.Location);
            this.Invalidate();
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            _mouseStatus = MouseStatus.Default;
            this.Invalidate();
        }

        #endregion
    }
}
