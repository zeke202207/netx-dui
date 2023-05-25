using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Netx.Dui.DxAnimation.Algorithm
{
    /// <summary>
    /// 变速运动效果
    /// </summary>
    internal class EaseEffect : IMotionEffect
    {
        public double Calculate(double from, double to, double totalTime, double elapsedTime, AnimationAlgorithmDirection direction)
        {
            switch (direction)
            {
                case AnimationAlgorithmDirection.In:
                    EaseIn(from, to, elapsedTime, to, 2);
                    return 0;
                case AnimationAlgorithmDirection.Out:
                    EaseOut(from, to, elapsedTime, to, 2);
                    return 0;
                case AnimationAlgorithmDirection.Both:
                    EaseBoth(from, to, elapsedTime, to, 2);
                    return 0;
                default:
                    throw new NotSupportedException("不支持的算法");
            }
        }

        #region Ease （变速）

        /// <summary>
        /// 变速
        /// </summary>
        /// <param name="origin">要变换的起始值</param>
        /// <param name="transform">要变换的总值</param>
        /// <param name="usedTime">已进行动画时间</param>
        /// <param name="allTime">总动画时间</param>
        /// <param name="power">动画曲线幂(默认值2)</param>
        /// <returns></returns>
        private double EaseIn(double origin, double transform, double usedTime, double allTime, double power)
        {
            return origin + transform * EaseInCore(usedTime / allTime, power);
        }

        /// <summary>
        /// 变速
        /// </summary>
        /// <param name="origin">要变换的起始值</param>
        /// <param name="transform">要变换的总值</param>
        /// <param name="usedTime">已进行动画时间</param>
        /// <param name="allTime">总动画时间</param>
        /// <param name="power">动画曲线幂(默认值2)</param>
        /// <returns></returns>
        private double EaseOut(double origin, double transform, double usedTime, double allTime, double power)
        {
            return origin + transform * (EaseOutCore(usedTime / allTime, power));
        }

        /// <summary>
        /// 变速
        /// </summary>
        /// <param name="origin">要变换的起始值</param>
        /// <param name="transform">要变换的总值</param>
        /// <param name="usedTime">已进行动画时间</param>
        /// <param name="allTime">总动画时间</param>
        /// <param name="power">动画曲线幂(默认值2)</param>
        /// <returns></returns>
        private double EaseBoth(double origin, double transform, double usedTime, double allTime, double power)
        {
            return origin + transform * EaseBothCore(usedTime / allTime, power);
        }

        /// <summary>
        /// 变速
        /// </summary>
        /// <param name="progressTime">已进行动画时间/总动画时间</param>
        /// <param name="power">动画曲线幂(默认值2)</param>
        /// <returns></returns>
        private double EaseInCore(double progressTime, double power)
        {
            power = Math.Max(0.0, power);
            return Math.Pow(progressTime, power);
        }

        /// <summary>
        /// 变速
        /// </summary>
        /// <param name="progressTime">已进行动画时间/总动画时间</param>
        /// <param name="power">动画曲线幂(默认值2)</param>
        /// <returns></returns>    
        private double EaseOutCore(double progressTime, double power)
        {
            return 1.0 - EaseInCore(1.0 - progressTime, power);
        }

        /// <summary>
        /// 变速
        /// </summary>
        /// <param name="progressTime">已进行动画时间/总动画时间</param>
        /// <param name="power">动画曲线幂(默认值2)</param>
        /// <returns></returns>
        private double EaseBothCore(double progressTime, double power)
        {
            if (progressTime >= 0.5)
                return (1.0 - EaseInCore((1.0 - progressTime) * 2.0, power)) * 0.5 + 0.5;
            return EaseInCore(progressTime * 2.0, power) * 0.5;
        }

        #endregion
    }
}
