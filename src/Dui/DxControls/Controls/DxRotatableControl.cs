using Netx.Dui.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Netx.Dui.DxControls
{
    /// <summary>
    /// 可旋转控件基类
    /// </summary>
    public abstract class DxRotatableControl : DxBaseInteraction
    {
        private Rectangle _minBoundRect = Rectangle.Empty;

        public DxRotatableControl()
        {
            _center = new PointF(Width / 2, Height / 2);
            this.SizeChanged += (s, e) =>
            {
                _center = new PointF(Width / 2, Height / 2);
                this.Invalidate();
            };
        }

        /// <summary>
        /// 旋转角度
        /// </summary>
        private float _rotate = 0;

        /// <summary>
        /// 旋转中心点坐标
        /// </summary>
        protected PointF _center = Point.Empty;

        /// <summary> 
        /// 旋转角度
        /// </summary>
        [Description("控件旋转角度"), Category("Dui")]
        [DefaultValue(0.0f)]
        public virtual float Rotate
        {
            get { return _rotate; }
            set
            {
                if(value >= 360)
                    value = 0;
                _rotate = value;
                SetBounds();
                base.Invalidate();
            }
        }

        protected virtual void SetBounds()
        {
            //if (this.ClientRectangle == Rectangle.Empty)
            //    return;
            //if (_minBoundRect == Rectangle.Empty)
            //    _minBoundRect = new Rectangle(0, 0, Width, Height);
            //var zeke = ControlTools.Rect2Pointfs(_minBoundRect, _rotate);
            //var rect = ControlTools.MinBoundRect(zeke);
            //if (rect.X < 0)
            //{
            //    var offsizeX = -rect.X;
            //    rect = new Rectangle(0, rect.Y, rect.Width + offsizeX, rect.Height);
            //}
            //if (rect.Y < 0)
            //{
            //    var offsizeY = -rect.Y;
            //    rect = new Rectangle(rect.X, 0, rect.Width, rect.Height + offsizeY);
            //}

            //this.Width = rect.Width;
            //this.Height = rect.Height;


            //this.Region = new Region(rect);
            ////using (GraphicsPath gp = new GraphicsPath())
            ////{
            ////    gp.AddLines(zeke);
            ////    gp.CloseAllFigures();
            ////    this.Region = new Region(gp);
            ////}
        }

        protected override void OnPaintBackground(DuiPaintEventArgs e)
        {
            ////e.Graphics.RotateTransform(Rotate, _center);
            //base.OnPaintBackground(e);

            //if (_minBoundRect == Rectangle.Empty)
            //    _minBoundRect = new Rectangle(0, 0, Width, Height);
            //var zeke = ControlTools.Rect2Pointfs(_minBoundRect, _rotate);
            //var rect = ControlTools.MinBoundRect(zeke);
            //if (rect.X < 0)
            //{
            //    var offsizeX = -rect.X;
            //    rect = new Rectangle(0, rect.Y, rect.Width + offsizeX, rect.Height);
            //}
            //if (rect.Y < 0)
            //{
            //    var offsizeY = -rect.Y;
            //    rect = new Rectangle(rect.X, 0, rect.Width, rect.Height + offsizeY);
            //}

            ////int i = 0;
            ////foreach (var p in zeke)
            ////{
            ////    //g.DrawEllipse(Pens.Black, p.X, p.Y, 2, 2);
            ////    e.Graphics.DrawString(i++.ToString(), new DuiFont(this.Font), DuiBrushes.Black, p);
            ////}
            //e.Graphics.DrawLines(DuiPens.Red, zeke);


            ////e.Graphics.RotateTransform(-Rotate, _center);
        }

        #region 私有方法


        #endregion
    }
}
