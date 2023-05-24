using SharpDX.Direct2D1;
using SharpDX.DXGI;
using AlphaMode = SharpDX.Direct2D1.AlphaMode;
using Factory = SharpDX.Direct2D1.Factory;
using SharpDX;
using SharpDX.Direct3D11;
using SharpDX.Direct3D;
using System.Security.Cryptography;
using System;

namespace Simple
{
    internal class DXHelper
    {
        private static System.Lazy<DXHelper> _lazy = new System.Lazy<DXHelper>(()=> new DXHelper());
        protected Texture2D _backBuffer;
        protected SharpDX.Direct3D11.Device _device;
        protected SwapChain _swapChain;

        private DXHelper() 
        {
            
        }

        public void Init(IntPtr DisplayHandle,int width,int height)
        {
            SharpDX.Direct2D1.PixelFormat D2PixelFormat =
            new SharpDX.Direct2D1.PixelFormat(Format.B8G8R8A8_UNorm, SharpDX.Direct2D1.AlphaMode.Premultiplied);
            // 创建 Direct2D 单线程工厂。
            SharpDX.Direct2D1.Factory factory = new SharpDX.Direct2D1.Factory(FactoryType.SingleThreaded);
            // 渲染参数。
            RenderTargetProperties renderProps = new RenderTargetProperties
            {
                PixelFormat = D2PixelFormat,
                Usage = RenderTargetUsage.None,
                Type = RenderTargetType.Default
            };
            // 渲染目标属性。
            HwndRenderTargetProperties hwndProps = new HwndRenderTargetProperties()
            {
                // 承载控件的句柄。
                Hwnd = DisplayHandle,
                // 控件的尺寸。
                PixelSize = new Size2(width, height),
                PresentOptions = PresentOptions.None
            };
            // 渲染目标。
            RenderTarget2D = new WindowRenderTarget(factory, renderProps, hwndProps)
            {
                AntialiasMode = AntialiasMode.PerPrimitive
            };
            RenderTarget2D.AntialiasMode = AntialiasMode.PerPrimitive;
            // 初始化画刷资源。
            SceneColorBrush = new SolidColorBrush(RenderTarget2D, Color.Black);
        }

        public static DXHelper Instance
        {
            get { return   _lazy.Value;}
        }

        public Factory Factory2D { get; private set; }
        public RenderTarget RenderTarget2D { get; private set; }
        public SolidColorBrush SceneColorBrush { get; private set; }

        private Surface _surface;

        public SolidColorBrush Test => new SolidColorBrush(RenderTarget2D, Color.Blue);
    }
}
