using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Netx.Dui.DxAnimation.Algorithm
{
    /// <summary>
    /// 弹性运动效果
    /// </summary>
    internal class ElasticEffect : IMotionEffect
    {
        public double Calculate(double from, double to, double totalTime, double elapsedTime, AnimationAlgorithmDirection direction)
        {
            switch (direction)
            {
                case AnimationAlgorithmDirection.In:
                    ElasticIn(from, to, elapsedTime, to, 3, 3);
                    return 0;
                case AnimationAlgorithmDirection.Out:
                    ElasticOut(from, to, elapsedTime, to, 3, 3);
                    return 0;
                case AnimationAlgorithmDirection.Both:
                    ElasticBoth(from, to, elapsedTime, to, 3, 3);
                    return 0;
                default:
                    throw new NotSupportedException("不支持的算法");
            }
        }

        #region Elastic （弹性）

        /// <summary>
        /// Elastic
        /// </summary>
        /// <param name="origin">要变换的起始值</param>
        /// <param name="transform">要变换的总值</param>
        /// <param name="usedTime">已进行动画时间</param>
        /// <param name="allTime">总动画时间</param>
        /// <param name="oscillations">目标来回滑过动画目标的次数。此值必须大于或等于0 (默认值为3)</param>
        /// <param name="springiness">弹簧铡度。 越小的 Springiness 值为，严格 spring，通过每个振动的强度减小的速度越快弹性。一个正数(默认值为3)</param>
        /// <returns></returns>
        private double ElasticIn(double origin, double transform, double usedTime, double allTime, int oscillations, double springiness)
        {
            return origin + transform * ElasticInCore((usedTime / allTime), oscillations, springiness);
        }

        /// <summary>
        /// Elastic
        /// </summary>
        /// <param name="origin">要变换的起始值</param>
        /// <param name="transform">要变换的总值</param>
        /// <param name="usedTime">已进行动画时间</param>
        /// <param name="allTime">总动画时间</param>
        /// <param name="oscillations">目标来回滑过动画目标的次数。此值必须大于或等于0 (默认值为3)</param>
        /// <param name="springiness">弹簧铡度。 越小的 Springiness 值为，严格 spring，通过每个振动的强度减小的速度越快弹性。一个正数(默认值为3)</param>
        /// <returns></returns>
        private double ElasticOut(double origin, double transform, double usedTime, double allTime, int oscillations, double springiness)
        {
            return origin + transform * ElasticOutCore((usedTime / allTime), oscillations, springiness);
        }

        /// <summary>
        /// Elastic
        /// </summary>
        /// <param name="origin">要变换的起始值</param>
        /// <param name="transform">要变换的总值</param>
        /// <param name="usedTime">已进行动画时间</param>
        /// <param name="allTime">总动画时间</param>
        /// <param name="oscillations">目标来回滑过动画目标的次数。此值必须大于或等于0 (默认值为3)</param>
        /// <param name="springiness">弹簧铡度。 越小的 Springiness 值为，严格 spring，通过每个振动的强度减小的速度越快弹性。一个正数(默认值为3)</param>
        /// <returns></returns>
        private double ElasticBoth(double origin, double transform, double usedTime, double allTime, int oscillations, double springiness)
        {
            return origin + transform * ElasticBothCore(usedTime / allTime, oscillations, springiness);
        }

        /// <summary>
        /// Elastic
        /// </summary>
        /// <param name="progressTime">已进行动画时间/总动画时间</param>
        /// <param name="oscillations">目标来回滑过动画目标的次数。此值必须大于或等于0 (默认值为3)</param>
        /// <param name="springiness">弹簧铡度。 越小的 Springiness 值为，严格 spring，通过每个振动的强度减小的速度越快弹性。一个正数(默认值为3)</param>
        /// <returns></returns>
        private double ElasticInCore(double progressTime, int oscillations, double springiness)
        {
            oscillations = Math.Max(0, oscillations);
            springiness = Math.Max(0.0, springiness);
            return (!(Math.Abs(springiness) < 2.22044604925031E-15) ? (Math.Exp(springiness * progressTime) - 1.0) / (Math.Exp(springiness) - 1.0) : progressTime) * Math.Sin((2.0 * Math.PI * oscillations + Math.PI / 2.0) * progressTime);
        }

        /// <summary>
        /// Elastic
        /// </summary>
        /// <param name="progressTime">已进行动画时间/总动画时间</param>
        /// <param name="oscillations">目标来回滑过动画目标的次数。此值必须大于或等于0 (默认值为3)</param>
        /// <param name="springiness">弹簧铡度。 越小的 Springiness 值为，严格 spring，通过每个振动的强度减小的速度越快弹性。一个正数(默认值为3)</param>
        /// <returns></returns>
        private double ElasticOutCore(double progressTime, int oscillations, double springiness)
        {
            return 1.0 - ElasticInCore(1.0 - progressTime, oscillations, springiness);
        }

        /// <summary>
        /// Elastic
        /// </summary>
        /// <param name="progressTime">已进行动画时间/总动画时间</param>
        /// <param name="oscillations">目标来回滑过动画目标的次数。此值必须大于或等于0 (默认值为3)</param>
        /// <param name="springiness">弹簧铡度。 越小的 Springiness 值为，严格 spring，通过每个振动的强度减小的速度越快弹性。一个正数(默认值为3)</param>
        /// <returns></returns>
        private double ElasticBothCore(double progressTime, int oscillations, double springiness)
        {
            if (progressTime >= 0.5)
                return (1.0 - ElasticInCore((1.0 - progressTime) * 2.0, oscillations, springiness)) * 0.5 + 0.5;
            return ElasticInCore(progressTime * 2.0, oscillations, springiness) * 0.5;
        }

        #endregion
    }
}
