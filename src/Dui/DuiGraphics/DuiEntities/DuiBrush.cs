using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Netx.Dui
{
    public class DuiBrush : DuiDependentOnRenderTarget
    {
        protected SharpDX.Direct2D1.Brush dxBrush = null;
        protected System.Drawing.Brush brush = null;
        protected virtual SharpDX.Direct2D1.Brush DxBrush
        {
            get
            {
                if (dxBrush == null || isNewRenderTarget)
                {
                    if (this.RenderTarget != null)
                    {
                        if (dxBrush != null)
                        {
                            dxBrush.Dispose();
                            dxBrush = null;
                        }
                        dxBrush = DxConvert.ToBrush(this.RenderTarget, this.brush);
                        isNewRenderTarget = false;
                    }
                }
                return dxBrush;
            }
        }
        public static implicit operator Brush(DuiBrush dUIBrush)
        {
            return dUIBrush.brush;
        }

        public static implicit operator SharpDX.Direct2D1.Brush(DuiBrush dUIBrush)
        {
            return dUIBrush.DxBrush;
        }

        public override void Dispose()
        {
            if (this.dxBrush != null)
            {
                this.dxBrush.Dispose();
            }
            if (this.brush != null)
            {
                this.brush.Dispose();
            }
            base.Dispose();
        }

        public override void DisposeDx()
        {
            if (this.dxBrush != null)
            {
                this.dxBrush.Dispose();
            }
        }
    }
}
