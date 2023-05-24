using SharpDX;
using SharpDX.Direct2D1;
using SharpDX.DXGI;
using SharpDX.WIC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Simple
{
    public partial class Form1 : Form
    {
        /// <summary>
		/// DXGI 格式。
		/// </summary>
		private static readonly Format Format = Format.B8G8R8A8_UNorm;
        /// <summary>
        /// Direct2D 的像素格式。
        /// </summary>
        public static readonly SharpDX.Direct2D1.PixelFormat D2PixelFormat =
            new SharpDX.Direct2D1.PixelFormat(Format, SharpDX.Direct2D1.AlphaMode.Premultiplied);

        public Form1()
        {
            InitializeComponent();
            DXHelper.Instance.Init(this.Handle,this.Width, this.Height);

            //InitHwndRenderTarget();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            ////base.OnPaint(e);
            //DXHelper.Instance.RenderTarget2D.Clear(null);
            //DXHelper.Instance.RenderTarget2D.DrawLine(
            //    new SharpDX.Mathematics.Interop.RawVector2(0, 0),
            //    new SharpDX.Mathematics.Interop.RawVector2(500, 500),
            //    DXHelper.Instance.SceneColorBrush);


            DXHelper.Instance.RenderTarget2D.BeginDraw();
            DXHelper.Instance.RenderTarget2D.Clear(Color.White);
            DXHelper.Instance.RenderTarget2D.FillRectangle(new RectangleF(10, 10, 200, 200), DXHelper.Instance.Test);
            DXHelper.Instance.RenderTarget2D.EndDraw();


            //hwndRenderTarget.BeginDraw();
            //hwndRenderTarget.Clear(Color.White);
            //hwndRenderTarget.DrawRectangle(new RectangleF(10, 10, 200, 200), hwndBrush);
            //hwndRenderTarget.EndDraw();

        }

        #region HwndRenderTarget

        /// <summary>
        /// Hwnd 渲染目标。
        /// </summary>
        private WindowRenderTarget hwndRenderTarget;
        /// <summary>
        /// Hwnd 画刷。
        /// </summary>
        private Brush hwndBrush;
        /// <summary>
        /// 初始化 HwndRenderTarget。
        /// </summary>
        private void InitHwndRenderTarget()
        {
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
                Hwnd = this.Handle,
                // 控件的尺寸。
                PixelSize = new Size2(this.ClientSize.Width, this.ClientSize.Height),
                PresentOptions = PresentOptions.None
            };
            // 渲染目标。
            hwndRenderTarget = new WindowRenderTarget(factory, renderProps, hwndProps)
            {
                AntialiasMode = AntialiasMode.PerPrimitive
            };
            // 初始化画刷资源。
            hwndBrush = new SolidColorBrush(hwndRenderTarget, Color.Black);
        }
        ///// <summary>
        ///// 绘制控件的事件。
        ///// </summary>
        //private void hwndRenderControl_Paint(object sender, PaintEventArgs e)
        //{
        //    hwndRenderTarget.BeginDraw();
        //    hwndRenderTarget.Clear(Color.White);
        //    hwndRenderTarget.DrawRectangle(new RectangleF(10, 10, 200, 200), hwndBrush);
        //    hwndRenderTarget.EndDraw();
        //}
        ///// <summary>
        ///// 控件大小被改变的事件。
        ///// </summary>
        //private void hwndRenderControl_SizeChanged(object sender, EventArgs e)
        //{
        //    // 在控件大小被改变的时候必须改变渲染目标的大小，
        //    // 否则会导致绘制结果被拉伸，引起失真。
        //    hwndRenderTarget.Resize(new Size2(hwndRenderControl.ClientSize.Width, hwndRenderControl.ClientSize.Height));
        //}

        #endregion // HwndRenderTarget
    }
}
