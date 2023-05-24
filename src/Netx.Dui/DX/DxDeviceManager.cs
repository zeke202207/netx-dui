using SharpDX.Direct2D1;
using SharpDX.DXGI;
using SharpDX.Direct3D;
using SharpDX.Direct3D11;
using DXGIDevice = SharpDX.DXGI.Device;
using DXGIFactory = SharpDX.DXGI.Factory;
using D2D1Device = SharpDX.Direct2D1.Device;
using DeviceContext = SharpDX.Direct2D1.DeviceContext;
using Factory = SharpDX.Direct2D1.Factory;
using D3D11Device = SharpDX.Direct3D11.Device;
using D3D11Device1 = SharpDX.Direct3D11.Device;
using System;
using SharpDX;
using System.Windows.Forms;
using Netx.Dui.DxControls;

namespace Netx.Dui
{

    /// <summary>
    /// 设备上下文工厂
    /// 每个控件生成一个设备上下文
    /// </summary>
    public sealed class DxDeviceManager
    {
        /// <summary>
		/// Direct2D 设备上下文。
		/// </summary>
		private DeviceContext d2DContext;

        /// <summary>
		/// DXGI SwapChain。
		/// </summary>
		private SwapChain swapChain;

        /// <summary>
        /// SwapChain 缓冲区。
        /// </summary>
        private Surface backBuffer;

        /// <summary>
        /// 渲染的目标位图。
        /// </summary>
        private Bitmap1 targetBitmap;

        /// <summary>
        /// 设置数据格式
        /// </summary>
        private Format format = Format.B8G8R8A8_UNorm;

        /// <summary>
        /// 渲染目标
        /// </summary>
        private RenderTarget renderTarget;

        private Control _control;

        #region Properties

        /// <summary>
        /// D2D设备上下文
        /// </summary>
        internal DeviceContext D2DContext => d2DContext;

        /// <summary>
        /// 数据交换区
        /// </summary>
        internal SwapChain SwapChain=> swapChain;

        /// <summary>
        /// 是否支持d3d
        /// </summary>
        internal bool SupportD3D
        {
            get
            {
                return this.d2DContext != null;
            }
        }

        /// <summary>
        /// 绘制目标
        /// </summary>
        internal RenderTarget RenderTarget => this.renderTarget;

        /// <summary>
        /// 渲染目标位图
        /// </summary>
        internal Bitmap1 Bitmap1 => this.targetBitmap;

        #endregion

        /// <summary>
        /// 初始化 DeviceContext。
        /// </summary>
        internal DxDeviceManager(Control control)
        {
            _control = control;
            // 创建 Dierect3D 设备。
            D3D11Device d3DDevice = DxDirectSingleton.Instance.D3DDevice;
            DXGIDevice dxgiDevice = d3DDevice.QueryInterface<D3D11Device1>().QueryInterface<DXGIDevice>();
            // 创建 Direct2D 设备和工厂。
            D2D1Device d2DDevice = new D2D1Device(dxgiDevice);
            this.d2DContext = new DeviceContext(d2DDevice, DeviceContextOptions.None);
            if (SupportD3D)
            {
                // 创建 DXGI SwapChain。
                SwapChainDescription swapChainDesc = new SwapChainDescription()
                {
                    BufferCount = 1,
                    Usage = Usage.RenderTargetOutput,
                    OutputHandle = _control.Handle,
                    IsWindowed = true,
                    // 这里宽度和高度都是 0，表示自动获取。
                    ModeDescription = new ModeDescription(0, 0, new Rational(60, 1), format),
                    SampleDescription = new SampleDescription(1, 0),
                    SwapEffect = SwapEffect.Discard
                };
                this.swapChain = new SwapChain(dxgiDevice.GetParent<Adapter>().GetParent<DXGIFactory>(),
                    d3DDevice, swapChainDesc);
                // 创建 BackBuffer。
                this.backBuffer = Surface.FromSwapChain(this.swapChain, 0);
                // 从 BackBuffer 创建 DeviceContext 可用的目标。
                this.targetBitmap = new Bitmap1(this.d2DContext, backBuffer);
                this.d2DContext.Target = targetBitmap;
                this.renderTarget = d2DContext;
            }
            else
            {
                SharpDX.Direct2D1.PixelFormat D2PixelFormat = new SharpDX.Direct2D1.PixelFormat(format, SharpDX.Direct2D1.AlphaMode.Premultiplied);
                RenderTargetProperties renderTargetProperties = new RenderTargetProperties
                {
                    PixelFormat = D2PixelFormat,
                    Usage = RenderTargetUsage.None,
                    Type = RenderTargetType.Default
                };
                HwndRenderTargetProperties hwndProperties = new HwndRenderTargetProperties
                {
                    Hwnd = _control.Handle,
                    PixelSize = new Size2(_control.ClientSize.Width, _control.ClientSize.Height),
                    PresentOptions = PresentOptions.None
                };
                this.renderTarget = new WindowRenderTarget(d2DContext.Factory, renderTargetProperties, hwndProperties)
                {
                    AntialiasMode = AntialiasMode.PerPrimitive,
                    TextAntialiasMode = TextAntialiasMode.Aliased
                };
            }
        }

        /// <summary>
        /// 重新分配资源
        /// </summary>
        internal void ReAssignResources()
        {
            if (SupportD3D)
            {
                this.d2DContext.Target = null;
                this.backBuffer.Dispose();
                this.targetBitmap.Dispose();
                this.swapChain.ResizeBuffers(1, 0, 0, format, SwapChainFlags.None);
                this.backBuffer = Surface.FromSwapChain(this.swapChain, 0);
                this.targetBitmap = new Bitmap1(this.d2DContext, backBuffer);
                this.d2DContext.Target = targetBitmap;
            }
            else
            {
                ((WindowRenderTarget)this.renderTarget).Resize(new Size2(_control.ClientSize.Width, _control.ClientSize.Height));
            }
        }

        /// <summary>
        /// 资源释放
        /// </summary>
        internal void Dispose()
        {
            if (null != targetBitmap)
                targetBitmap.Dispose();
            if (null != backBuffer)
                backBuffer.Dispose();
            if (null != swapChain)
                swapChain.Dispose();
            if(null != d2DContext) 
                d2DContext.Dispose();
        }
    }
}
