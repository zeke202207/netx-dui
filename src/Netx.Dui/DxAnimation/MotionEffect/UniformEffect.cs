using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Netx.Dui.DxAnimation.Algorithm
{
    /// <summary>
    /// 匀速运动效果
    /// </summary>
    internal class UniformEffect : IMotionEffect
    {
        public double Calculate(double from, double to, double totalTime, double elapsedTime, AnimationAlgorithmDirection direction)
        {
            return UniformMotion(from, to, elapsedTime, totalTime);
        }

        #region UniformMotion （匀速）

        /// <summary>
        ///  匀速
        /// </summary>
        /// <param name="origin">要变换的起始值</param>
        /// <param name="transform">要变换的总值</param>
        /// <param name="usedTime">已进行动画时间</param>
        /// <param name="allTime">总动画时间</param>
        /// <returns></returns>
        private double UniformMotion(double origin, double transform, double usedTime, double allTime)
        {
            return origin + transform * UniformMotionCore(usedTime, allTime);
        }

        /// <summary>
        /// 匀速
        /// </summary>
        /// <param name="usedTime">已进行动画时间</param>
        /// <param name="allTime">总动画时间</param>
        /// <returns></returns>
        private double UniformMotionCore(double usedTime, double allTime)
        {
            return usedTime / allTime;
        }

        #endregion
    }
}
