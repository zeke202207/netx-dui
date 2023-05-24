using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Simple
{
    public partial class UCTest : UserControl
    {
        public UCTest()
        {
            //InitializeComponent(); 
            SetStyle(ControlStyles.UserPaint | ControlStyles.Opaque | ControlStyles.AllPaintingInWmPaint, value: true);
            UpdateStyles();
        }

        private Font fontForDesignMode;

        //
        // 摘要:
        //     Paints the background of the control.
        //
        // 参数:
        //   e:
        //     A System.Windows.Forms.PaintEventArgs that contains the event data.
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            if (base.DesignMode)
            {
                base.OnPaintBackground(e);
            }
        }

        //
        // 摘要:
        //     Raises the System.Windows.Forms.Control.Paint event.
        //
        // 参数:
        //   e:
        //     A System.Windows.Forms.PaintEventArgs that contains the event data.
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (base.DesignMode)
            {
                if (fontForDesignMode == null)
                {
                    fontForDesignMode = new Font("Calibri", 24f, FontStyle.Regular);
                }

                e.Graphics.Clear(System.Drawing.Color.WhiteSmoke);
                string text = "SharpDX RenderControl";
                SizeF sizeF = e.Graphics.MeasureString(text, fontForDesignMode);
                e.Graphics.DrawString(text, fontForDesignMode, new SolidBrush(System.Drawing.Color.Black), ((float)base.Width - sizeF.Width) / 2f, ((float)base.Height - sizeF.Height) / 2f);
            }
        }
    }
}
