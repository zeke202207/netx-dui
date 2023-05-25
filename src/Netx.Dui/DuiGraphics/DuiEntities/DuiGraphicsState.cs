using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;

namespace Netx.Dui
{
    public class DuiGraphicsState
    {
        private GraphicsState graphicsState = null;
        private DuiMatrix dUIMatrix = null;
        private DuiSmoothingMode dUISmoothingMode = DuiSmoothingMode.Default;
        private DuiTextRenderingHint dUITextRenderingHint = DuiTextRenderingHint.Default;
        public DuiGraphicsState(DuiMatrix dUIMatrix, DuiSmoothingMode dUISmoothingMode, DuiTextRenderingHint dUITextRenderingHint)
        {
            this.dUIMatrix = dUIMatrix;
            this.dUISmoothingMode = dUISmoothingMode;
            this.dUITextRenderingHint = dUITextRenderingHint;
        }
        public DuiGraphicsState(GraphicsState graphicsState)
        {
            this.graphicsState = graphicsState;
        }
        public static implicit operator DuiGraphicsState(GraphicsState graphicsState)
        {
            return new DuiGraphicsState(graphicsState);
        }
        public static implicit operator GraphicsState(DuiGraphicsState dUIGraphicsState)
        {
            return dUIGraphicsState.graphicsState;
        }
        public static implicit operator DuiSmoothingMode(DuiGraphicsState dUIGraphicsState)
        {
            return dUIGraphicsState.dUISmoothingMode;
        }
        public static implicit operator DuiTextRenderingHint(DuiGraphicsState dUIGraphicsState)
        {
            return dUIGraphicsState.dUITextRenderingHint;
        }
        public static implicit operator DuiMatrix(DuiGraphicsState dUIGraphicsState)
        {
            return dUIGraphicsState.dUIMatrix;
        }
    }
}
