using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Netx.Dui
{
    public abstract class DuiRenderTarget : IDisposable
    {
        public abstract SharpDX.Direct2D1.RenderTarget RenderTarget { get; }

        public IntPtr NativePointer => this.RenderTarget.NativePointer;

        public virtual float DpiX { get { return 96; } }

        public virtual float DpiY { get { return 96; } }

        public virtual void BeginDraw()
        {
            if (null != RenderTarget)
                RenderTarget.BeginDraw();
        }

        public virtual void Resize(Size size)
        {
        }

        public virtual void EndDraw()
        {
            if (null != RenderTarget)
                RenderTarget?.EndDraw();
        }

        public virtual void Dispose()
        {
            
        }

        public static implicit operator SharpDX.Direct2D1.RenderTarget(DuiRenderTarget dUIRenderTarget)
        {
            return dUIRenderTarget.RenderTarget;
        }
    }
}
