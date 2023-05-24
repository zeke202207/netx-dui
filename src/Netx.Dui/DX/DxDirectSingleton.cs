using SharpDX.Direct3D;
using SharpDX.Direct3D11;
using SharpDX.DirectWrite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using D3D11Device = SharpDX.Direct3D11.Device;

namespace Netx.Dui
{
    internal class DxDirectSingleton
    {
        private static Lazy<DxDirectSingleton> _instance = new Lazy<DxDirectSingleton>(() => new DxDirectSingleton());

        private Factory _directWrite;
        public D3D11Device _d3DDevice;

        private DxDirectSingleton()
        {
            _directWrite = new Factory();
            _d3DDevice = new D3D11Device(DriverType.Hardware, DeviceCreationFlags.BgraSupport);
        }

        public static DxDirectSingleton Instance => _instance.Value;

        public Factory DwFactory => _directWrite;

        public D3D11Device D3DDevice => _d3DDevice;
    }
}
