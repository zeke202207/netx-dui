using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netx.Dui
{
    /// <summary>
    /// Defines the <see cref="AnimationEaseInOut" />
    /// </summary>
    internal static class AnimationEaseInOut
    {
        /// <summary>
        /// Defines the PI
        /// </summary>
        public static double PI = Math.PI;

        /// <summary>
        /// Defines the PI_HALF
        /// </summary>
        public static double PI_HALF = Math.PI / 2;

        /// <summary>
        /// The CalculateProgress
        /// </summary>
        /// <param name="progress">The progress<see cref="double"/></param>
        /// <returns>The <see cref="double"/></returns>
        public static double CalculateProgress(double progress)
        {
            return EaseInOut(progress);
        }

        /// <summary>
        /// The EaseInOut
        /// </summary>
        /// <param name="s">The s<see cref="double"/></param>
        /// <returns>The <see cref="double"/></returns>
        private static double EaseInOut(double s)
        {
            return s - Math.Sin(s * 2 * PI) / (2 * PI);
        }
    }
}
