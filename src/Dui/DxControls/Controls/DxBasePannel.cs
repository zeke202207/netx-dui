using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Netx.Dui.DxControls
{
    public abstract class DxBasePannel : DxControl
    {
        #region 私有变量

        protected Color _backGroundColor = ColorTranslator.FromHtml("#409EFF");
        protected int _borderWidth = 2;
        protected float _radius = 0.0f;
        protected bool _transparency = false;

        #endregion

        #region 设计器属性

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
                BackGroundColorChanged();
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

        [Description("边框圆角半径)"), Category("Dui")]
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

        [DefaultValue(false)]
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

        #region 构造函数

        /// <summary>
        /// dx控件实例对象
        /// </summary>
        public DxBasePannel()
        {
           
        }

        #endregion

        #region 控件绘制

        /// <summary>
        /// 00_开始绘制
        /// </summary>
        /// <param name="context"></param>
        protected override void OnDuiPaint(DuiPaintEventArgs e)
        {
            e.Graphics.Clear(this.Parent.BackColor);
            DuiGraphicsState backupGraphicsState = e.Graphics.Save();
            //TODO:
            //e.Graphics.TranslateTransform(this.X, this.Y); //偏移一下坐标系将控件的坐标定义为坐标系原点
            //PointF center = new PointF(this.BorderWidth + this.CenterX, this.BorderWidth + this.CenterY);
            //e.Graphics.RotateTransform(this.Rotate, center);
            //e.Graphics.SkewTransform(this.Skew, center);
            //e.Graphics.ScaleTransform(this.Scale, center);

            //e.Graphics.TranslateTransform(this.Location.X, this.Location.Y); //偏移一下坐标系将控件的坐标定义为坐标系原点
            //PointF center = new PointF(this.BorderWidth + this.Width / 2, this.BorderWidth + this.Height / 2);
            //e.Graphics.RotateTransform(35, center);
            //e.Graphics.SkewTransform(this.Skew, center);
            //e.Graphics.ScaleTransform(this.Scale, center);


            e.Graphics.PushLayer(this.Width, this.Height); //背景图层

            #region 01_OnPaintBackground

            DuiGraphicsState backupOnPaintBackgroundGraphicsState = e.Graphics.Save();
            OnPaintBackground(new DuiPaintEventArgs(e.Graphics, new RectangleF(0, 0, this.Width, this.Height))); //绘制背景
            e.Graphics.Restore(backupOnPaintBackgroundGraphicsState);

            #endregion

            if (this.BorderWidth != 0)
            {
                e.Graphics.PopLayer();
                e.Graphics.TranslateTransform(this.BorderWidth, this.BorderWidth); //偏移一个边框的坐标系
                e.Graphics.PushLayer(this.ClientSize.Width, this.ClientSize.Height); //背景图层
            }

            #region 02_OnPaint

            DuiGraphicsState backupOnPaintGraphicsState = e.Graphics.Save();
            OnControlPaint(new DuiPaintEventArgs(e.Graphics, new RectangleF(0, 0, ClientSize.Width, this.ClientSize.Height)));
            e.Graphics.Restore(backupOnPaintGraphicsState);

            #endregion

            e.Graphics.TranslateTransform(-this.BorderWidth, -this.BorderWidth);
            e.Graphics.PopLayer();

            #region 03_OnPaintIcon

            DuiGraphicsState backupOnPaintIconGraphicsState = e.Graphics.Save();
            OnPaintIcon(new DuiPaintEventArgs(e.Graphics, new RectangleF(0, 0, this.Width, this.Height)));
            e.Graphics.Restore(backupOnPaintIconGraphicsState);

            #endregion

            #region 04_OnPaintForeground

            DuiGraphicsState backupOnPaintForegroundGraphicsState = e.Graphics.Save();
            OnPaintForeground(new DuiPaintEventArgs(e.Graphics, new RectangleF(0, 0, this.Width, this.Height)));
            e.Graphics.Restore(backupOnPaintForegroundGraphicsState);

            #endregion

            #region 05_OnPaintAnimationLayer

            DuiGraphicsState animationLayerOnPaintForegroundGraphicsState = e.Graphics.Save();
            OnPaintAnimationLayer(new DuiPaintEventArgs(e.Graphics, new RectangleF(0, 0, this.Width, this.Height)));
            e.Graphics.Restore(animationLayerOnPaintForegroundGraphicsState);

            #endregion

            e.Graphics.Restore(backupGraphicsState);
        }

        /// <summary>
        /// 01_背景绘制
        /// </summary>
        /// <param name="context"></param>
        protected virtual void OnPaintBackground(DuiPaintEventArgs e)
        {
            if (_radius == 0.0f)
                PaintRectBackground(e);
            else
                PaintRoundrectBackground(e);
        }

        /// <summary>
        /// 02_控件独立渲染器
        /// </summary>
        /// <param name="context"></param>
        protected abstract void OnControlPaint(DuiPaintEventArgs e);

        /// <summary>
        /// 03_图标绘制
        /// </summary>
        /// <param name="e"></param>
        protected abstract void OnPaintIcon(DuiPaintEventArgs e);

        /// <summary>
        /// 04_文本绘制
        /// </summary>
        /// <param name="context"></param>
        protected abstract void OnPaintForeground(DuiPaintEventArgs e);

        /// <summary>
        /// 05_动画蒙版
        /// </summary>
        /// <param name="e"></param>
        protected abstract void OnPaintAnimationLayer(DuiPaintEventArgs e);

        /// <summary>
        /// 绘制矩形背景背景
        /// </summary>
        /// <param name="e"></param>
        private void PaintRectBackground(DuiPaintEventArgs e)
        {
            var g = e.Graphics;
            if (null != this.Parent?.BackColor)
                g.Clear(this.Parent.BackColor);
            var borderRect = GetBorderRect();
            using (var pen = new DuiPen(BorderColor()))
            {
                pen.Width = this.BorderWidth;
                g.DrawRectangle(pen, borderRect);
                using (var backgroundBrush = new DuiSolidBrush(BackgroundColor()))
                {
                    var fillRect = new Rectangle(2, 2, borderRect.Width - 2, borderRect.Height - 2);
                    fillRect.Inflate(-1, -1);
                    g.FillRectangle(backgroundBrush, fillRect);
                }
            }
        }

        /// <summary>
        /// 绘制圆角背景
        /// </summary>
        /// <param name="e"></param>
        private void PaintRoundrectBackground(DuiPaintEventArgs e)
        {
            var g = e.Graphics;
            DuiGraphicsState backupOnPaintBackgroundGraphicsState = g.Save();
            if (null != this.Parent?.BackColor)
                g.Clear(this.Parent.BackColor);
            using (var pen = new DuiPen(BorderColor()))
            {
                pen.Width = _borderWidth;
                var borderRect = GetBorderRect();
                g.DrawRoundedRectangle(pen, borderRect, _radius);
                using (var backgroundBrush = new DuiSolidBrush(BackgroundColor()))
                {
                    g.FillRoundedRectangle(backgroundBrush, borderRect, _radius);
                }
            }
            e.Graphics.Restore(backupOnPaintBackgroundGraphicsState);
        }

        #endregion

        #region 辅助方法 - 颜色

        /// <summary>
        /// 获取边框颜色
        /// </summary>
        /// <returns></returns>
        protected virtual Color BorderColor()
        {
            return UseSkin ? SkinManager.Scheme.ColorScheme.GetColor(ColorType.Border) : Color.DarkGray;
        }

        /// <summary>
        /// 获取背景颜色
        /// </summary>
        /// <returns></returns>
        protected virtual Color BackgroundColor()
        {
            if (_transparency)
                return this.Parent == null ? this.BackColor : this.Parent.BackColor;
            return UseSkin ? SkinManager.Scheme.ColorScheme.GetColor(ColorType.Primary) : _backGroundColor;
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

        #endregion

        #region 辅助方法 - 属性修改

        protected virtual void BackGroundColorChanged()
        {

        }

        #endregion
    }
}
