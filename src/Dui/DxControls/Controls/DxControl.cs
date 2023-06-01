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
        internal IPaintManager _paintManager = new PaintManager();

        /// <summary>
        /// 皮肤管理
        /// </summary>
        [Browsable(false)]
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
            SetStyle(ControlStyles.AllPaintingInWmPaint
               | ControlStyles.SupportsTransparentBackColor
               | ControlStyles.ResizeRedraw,
               true);
            SetStyle(ControlStyles.UserPaint
                | ControlStyles.Opaque,
                false);
            UpdateStyles();
        }

        #region override

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            _paintManager.WndProcHandler(this, m.Msg, OnPaint);
        }

        #endregion

        protected void OnPaint(DuiPaintEventArgs e)
        {
            OnDuiPaint(new DuiPaintEventArgs(e.Graphics, e.ClipRectangle));
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
