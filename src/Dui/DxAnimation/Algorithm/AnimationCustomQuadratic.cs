using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netx.Dui
{
    /// <summary>
    /// Defines the <see cref="AnimationCustomQuadratic" />
    /// </summary>
    public static class AnimationCustomQuadratic
    {
        /// <summary>
        /// The CalculateProgress
        /// </summary>
        /// <param name="progress">The progress<see cref="double"/></param>
        /// <returns>The <see cref="double"/></returns>
        public static double CalculateProgress(double progress)
        {
            var kickoff = 0.6;
            return 1 - Math.Cos((Math.Max(progress, kickoff) - kickoff) * Math.PI / (2 - (2 * kickoff)));
        }
    }
}
