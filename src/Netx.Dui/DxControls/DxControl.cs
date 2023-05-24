using SharpDX.Direct2D1;
using SharpDX.DXGI;
using SharpDX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;
using System.Runtime.InteropServices;
using SharpDX.Direct2D1.Effects;

namespace Netx.Dui.DxControls
{
    
    public abstract class DxControl : Control, ISkinManager
    {
        private DxDeviceManager d2dManager;

        private bool _useSkin = true;

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

        //当alpha通道值为255时，表示完全不透明；当alpha通道值为0时，表示完全透明
        protected DxControl()
        {
            //禁用onpaint
            this.SetStyle(ControlStyles.UserPaint, false);
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            d2dManager = new DxDeviceManager(this);
        }

        private void OnDxPaint()
        {
            if (null == this.d2dManager || null == d2dManager.RenderTarget)
                return;
            this.d2dManager.RenderTarget.BeginDraw();
            OnDxPaint(this.d2dManager);
            this.d2dManager.RenderTarget.EndDraw();
            //SwapChain 呈现绘制结果。
            if (this.d2dManager.SupportD3D)
                this.d2dManager.SwapChain.Present(0, PresentFlags.None);
            //裁剪region后，导致性能下降
            //ReRegion();
        }

        /// <summary>
        /// 开始绘制
        /// </summary>
        /// <param name="d2dContext"></param>
        /// <param name="s"></param>
        protected virtual void OnDxPaint(DxDeviceManager context)
        {

        }

        /// <summary>
        /// 禁用系统绘制
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            //base.OnPaint(e);            
        }

        protected override void WndProc(ref Message m)
        {
            switch(m.Msg)
            {
                case WindowsMessage.WM_PAINT:
                case WindowsMessage.WM_NCPAINT:
                    OnDxPaint();
                    break;
                case WindowsMessage.WM_SIZE:
                    if (null != this.d2dManager)
                    {
                        this.d2dManager.ReAssignResources();
                        this.Invalidate();
                    }
                    break;
                case WindowsMessage.WM_DESTROY:
                    this.d2dManager.Dispose();
                    break;
                default:
                    break;
            }
            base.WndProc(ref m);
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

        /// <summary>
        /// 重新region控件形状
        /// </summary>
        protected virtual void ReRegion()
        {

        }
    }
}
