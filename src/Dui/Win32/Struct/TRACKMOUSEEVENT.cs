using System;
using System.Runtime.InteropServices;

namespace Netx.Dui.Win32.Struct
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct TRACKMOUSEEVENT
    {
        internal uint cbSize;
        internal uint dwFlags;
        internal IntPtr hwndTrack;
        internal uint dwHoverTime;
    }
}
