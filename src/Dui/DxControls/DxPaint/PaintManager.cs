using Netx.Dui.Common;
using Netx.Dui.DxControls;
using Netx.Dui.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Netx.Dui
{
    internal sealed class PaintManager : IPaintManager , IDisposable
    {
        private DuiGraphics _dGraphics;
        private bool disposedValue;

        public DuiGraphics DGraphics => _dGraphics;

        public void WndProcHandler(Control control, int msg, Action<DuiPaintEventArgs> OnPaint)
        {
            switch (msg)
            {
                case WM.WM_PAINT:
                case WM.WM_SIZE:
                    _dGraphics.BeginDraw();
                    OnPaint(new DuiPaintEventArgs(_dGraphics, control.ClientRectangle));
                    _dGraphics.EndDraw();
                    break;
                case WM.WM_CREATE:
                    if (!InitD2D(control))
                        InitD2D(control.CreateGraphics());
                    break;
            }
        }

        private bool InitD2D(Control control, Action<DuiGraphics> option = null)
        {
            try
            {
                _dGraphics = DuiGraphics.FromControl(control);
                OptionGraphics(_dGraphics, option);
                return true;
            }
            catch (Exception ex)
            {
                _dGraphics = null;
                return false;
            }
        }

        private void InitD2D(Graphics graphics, Action<DuiGraphics> option = null)
        {
            _dGraphics = graphics;
            OptionGraphics(_dGraphics, option);
        }

        private void OptionGraphics(DuiGraphics dGraphics,Action<DuiGraphics> option = null)
        {
            dGraphics.SmoothingMode = DuiSmoothingMode.AntiAlias;
            dGraphics.TextRenderingHint = DuiTextRenderingHint.AntiAlias;
            option?.Invoke(dGraphics);
        }

        private void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: 释放托管状态(托管对象)
                    _dGraphics?.Dispose();
                    _dGraphics = null;
                }

                // TODO: 释放未托管的资源(未托管的对象)并重写终结器
                // TODO: 将大型字段设置为 null
                disposedValue = true;
            }
        }

        // // TODO: 仅当“Dispose(bool disposing)”拥有用于释放未托管资源的代码时才替代终结器
        // ~PaintManager()
        // {
        //     // 不要更改此代码。请将清理代码放入“Dispose(bool disposing)”方法中
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // 不要更改此代码。请将清理代码放入“Dispose(bool disposing)”方法中
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
