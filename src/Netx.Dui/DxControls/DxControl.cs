using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;
using Netx.Dui.Common;
using System.Drawing;

namespace Netx.Dui.DxControls
{
    
    public abstract class DxControl : Control, ISkinManager
    {
        private bool _useSkin = true;
        protected DuiGraphics duiGraphics = null;

        /// <summary>
        /// 皮肤管理
        /// </summary>
        public DxSkinManager SkinManager => DxSkinManager.Instance;

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

        /// <summary>
        /// 
        /// </summary>
        public DxControl()
        {
            //使用gdi方式打开此设置
            //this.SetStyle(ControlStyles.DoubleBuffer, true);// 双缓冲
            //指定控件的样式和行为
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);// 控件透明
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.UserPaint, true); //用户自行重绘
            this.SetStyle(ControlStyles.Opaque, false);
            UpdateStyles();
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            InitD2D();
        }

        /// <summary> 初始化D2D
        /// </summary>
        protected virtual void InitD2D()
        {
            try
            {
                this.duiGraphics?.Dispose();
                this.duiGraphics = null;
                this.duiGraphics = DuiGraphics.FromControl(this);
                this.duiGraphics.SmoothingMode = DuiSmoothingMode.AntiAlias;
                this.duiGraphics.TextRenderingHint = DuiTextRenderingHint.AntiAlias;
            }
            catch (Exception ex)
            {
                InitD2D();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            //Default drawing is d2d, if you want use gdi+ style,please override OnPaint and call <code>duiGraphis = e.Graphics</code> like below:
            //duiGraphics = e.Graphics;
            duiGraphics.BeginDraw();
            OnDuiPaint(new DuiPaintEventArgs(duiGraphics, new RectangleF(0, 0, this.Width, this.Height)));
            duiGraphics.EndDraw();
        }

        /// <summary>
        /// 开始绘制
        /// </summary>
        /// <param name="d2dContext"></param>
        /// <param name="s"></param>
        protected virtual void OnDuiPaint(DuiPaintEventArgs e)
        {
            
        }

        /// <summary>
        /// 是否在设计期
        /// </summary>
        protected bool IsDesignMode
        {
            get
            {
                if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
                    return true;
                if (System.Diagnostics.Process.GetCurrentProcess().ProcessName == "devenv")
                    return true;
                return false;
            }
        }
    }
}
