using Netx.Dui.Common;
using Netx.Dui.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Netx.Dui.DxControls.Controls
{
    [ToolboxItem(true)]
    public class DxLabel : Label , ISkinManager
    {
        public DxSkinManager SkinManager => DxSkinManager.Instance;
        internal IPaintManager _paintManager = new PaintManager();

        public DxLabel()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint 
                | ControlStyles.SupportsTransparentBackColor 
                | ControlStyles.ResizeRedraw, 
                true);
            SetStyle(ControlStyles.UserPaint 
                | ControlStyles.Opaque, 
                false);
            UpdateStyles();
        }

        #region 私有方法

        //protected override CreateParams CreateParams
        //{
        //    get
        //    {
        //        CreateParams cp = base.CreateParams;
        //        cp.ExStyle |= 0x00000020;       // 实现透明样式
        //        return cp;
        //    }
        //}

        protected virtual void OnPaint(DuiPaintEventArgs e)
        {            
            var g = e.Graphics;
            g.Clear(this.BackColor);
            using (var brush = new DuiSolidBrush(Color.FromArgb(50, Color.Red)))
            {
                g.FillRectangle(brush, ClientRectangle.X, ClientRectangle.Y, 30, 30);
            }
        }

        #endregion

        #region override

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            _paintManager.WndProcHandler(this, m.Msg, OnPaint);
        }

        #endregion
    }
}
