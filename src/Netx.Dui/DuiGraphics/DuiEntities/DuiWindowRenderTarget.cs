using SharpDX;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Netx.Dui
{
    public class DuiWindowRenderTarget : DuiRenderTarget
    {
        private SharpDX.Direct2D1.Factory direct2D1factory = null;

        /// <summary> 
        /// 渲染窗口
        /// </summary>
        internal SharpDX.Direct2D1.WindowRenderTarget windowRenderTarget;

        public IntPtr Handle => this.windowRenderTarget.Hwnd;

        public override SharpDX.Direct2D1.RenderTarget RenderTarget => this.windowRenderTarget;

        public DuiWindowRenderTarget(IntPtr handle)
        {
            Size size = System.Windows.Forms.Control.FromHandle(handle).Size;
            this.direct2D1factory = new SharpDX.Direct2D1.Factory(SharpDX.Direct2D1.FactoryType.SingleThreaded);
            SharpDX.Direct2D1.HwndRenderTargetProperties hwndRenderTargetProperties = new SharpDX.Direct2D1.HwndRenderTargetProperties()
            {
                Hwnd = handle,
                PixelSize = new SharpDX.Size2(size.Width, size.Height),
                PresentOptions = SharpDX.Direct2D1.PresentOptions.None
            };
            SharpDX.Direct2D1.PixelFormat pixelFormat = new SharpDX.Direct2D1.PixelFormat(
                SharpDX.DXGI.Format.Unknown,
                SharpDX.Direct2D1.AlphaMode.Premultiplied);
            //强制设置DPI为96，96（默认值），无意间发现有的人居然会去修改系统的dpi
            SharpDX.Direct2D1.RenderTargetProperties renderTargetProperties = new SharpDX.Direct2D1.RenderTargetProperties(
                SharpDX.Direct2D1.RenderTargetType.Default, 
                pixelFormat, 
                96, 
                96, 
                SharpDX.Direct2D1.RenderTargetUsage.None, 
                SharpDX.Direct2D1.FeatureLevel.Level_DEFAULT);
            //初始化，在_d2dFactory创建渲染缓冲区并与Target绑定
            //SharpDX.Direct2D1.PixelFormat pf = new SharpDX.Direct2D1.PixelFormat(SharpDX.DXGI.Format.Unknown, SharpDX.Direct2D1.AlphaMode.Premultiplied);
            this.windowRenderTarget = new SharpDX.Direct2D1.WindowRenderTarget(direct2D1factory, renderTargetProperties, hwndRenderTargetProperties)
            {
                AntialiasMode = SharpDX.Direct2D1.AntialiasMode.Aliased,
                TextAntialiasMode = SharpDX.Direct2D1.TextAntialiasMode.Aliased
            };
            // 在控件大小被改变的时候必须改变渲染目标的大小，
            // 否则会导致绘制结果被拉伸，引起失真。
            var handleControl = System.Windows.Forms.Control.FromHandle(handle);
            handleControl.SizeChanged += (s, e) =>
            {
                windowRenderTarget.Resize(new Size2(handleControl.ClientSize.Width, handleControl.ClientSize.Height));
            };
        }

        public override void Resize(Size size)
        {
            this.windowRenderTarget.Resize(new SharpDX.Size2(size.Width, size.Height));
        }

        public override void Dispose()
        {
            base.Dispose();
            this.direct2D1factory?.Dispose();
            this.direct2D1factory = null;
            this.windowRenderTarget?.Dispose();
            this.windowRenderTarget = null;
            GC.Collect();
        }
    }
}
