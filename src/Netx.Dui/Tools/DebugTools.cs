using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Netx.Dui.Tools
{
    internal class DebugTools
    {
        private static Lazy<DebugTools> _lazy = new Lazy<DebugTools>(() => new DebugTools());

        private DebugTools() { }

        public static DebugTools Instance=>_lazy.Value;

        private Stopwatch sw;

        public void StopwatchStart()
        {
            sw = Stopwatch.StartNew();
        }

        public void StopwatchStop()
        {
            sw.Stop();
            Console.WriteLine($"{sw.Elapsed.TotalMilliseconds}");
            sw.Reset();
        }
    }
}
