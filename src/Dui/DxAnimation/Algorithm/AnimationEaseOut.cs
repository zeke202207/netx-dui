using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netx.Dui
{

    /// <summary>
    /// Defines the <see cref="AnimationEaseOut" />
    /// </summary>
    public static class AnimationEaseOut
    {
        /// <summary>
        /// The CalculateProgress
        /// </summary>
        /// <param name="progress">The progress<see cref="double"/></param>
        /// <returns>The <see cref="double"/></returns>
        public static double CalculateProgress(double progress)
        {
            return -1 * progress * (progress - 2);
        }
    }
}
