using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Netx.Dui.DxControls
{
    [ToolboxItem(false)]
    public class TextBoxItem : TextBox
    {
        internal IPaintManager _paintManager = new PaintManager();

        public TextBoxItem()
        {
            BorderStyle = BorderStyle.FixedSingle;
            this.TextAlign = HorizontalAlignment.Left;
            this.AutoSize = false;
            this.Text = String.Empty;
            this.BorderStyle = BorderStyle.None;
        }


        #region override

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            //_paintManager.WndProcHandler(this, m.Msg, OnPaint);
        }

        #endregion
    }
}
