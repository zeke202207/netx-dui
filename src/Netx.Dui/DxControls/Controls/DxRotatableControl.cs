using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;

namespace Netx.Dui.DxControls
{
    /// <summary>
    /// 可旋转控件基类
    /// </summary>
    public abstract class DxRotatableControl : DxBaseControl
    {
        protected Matrix _matrix = new Matrix();

        public DxRotatableControl() 
        {
           
        }

        /// <summary>
        /// 旋转角度
        /// </summary>
        private float _rotate = 0;
        /// <summary>
        /// 旋转中心点坐标
        /// </summary>
        private PointF _center = Point.Empty;

        /// <summary> 
        /// 旋转中心点
        /// </summary>
        public PointF Center
        {
            get { return _center; }
            set { _center = value; }
        }

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
                _rotate = value;
                _matrix.Translate(Width /2, Height / 2);
                _matrix.RotateAt(_rotate, _center);
                base.Invalidate();
            }
        }
    }
}
