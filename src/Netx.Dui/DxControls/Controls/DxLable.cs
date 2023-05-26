using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Netx.Dui.DxControls.Controls
{
    [ToolboxItem(true)]
    public class DxLable : DxRotatableControl
    {
        public DxLable()
        {
        }

        protected override void OnControlPaint(DuiPaintEventArgs e)
        {
            
        }

        protected override void PaintBackground(DuiPaintEventArgs e)
        {
            //base.PaintBackground(e);
            e.Graphics.Clear(this.Parent.BackColor);
        }

        protected override void OnPaintForeground(DuiPaintEventArgs e)
        {
            e.Graphics.Transform = base._matrix;
            base.OnPaintForeground(e);
            _matrix.Reset();
        }
    }
}
