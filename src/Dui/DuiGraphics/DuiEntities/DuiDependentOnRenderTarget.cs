using SharpDX.IO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;

namespace Netx.Dui
{
    /// <summary> 依赖RenderTarget的对象,例如DUIImage,DUIBitmap等
    /// </summary>
    public abstract class DuiDependentOnRenderTarget : IDisposable
    {
        protected bool isNewRenderTarget = false;
        private DuiRenderTarget renderTarget = null;
        internal protected DuiRenderTarget RenderTarget
        {
            get { return renderTarget; }
            set
            {
                renderTarget = value;
            }
        }

        public virtual void Dispose()
        {
            
        }
        public abstract void DisposeDx();
    }
}
