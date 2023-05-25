using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Netx.Dui.DxAnimation.Algorithm
{
    /// <summary>
    /// 弹球减振 加速运动效果
    /// </summary>
    internal class BounceEffect : IMotionEffect
    {
        public double Calculate(double from, double to, double totalTime, double elapsedTime, AnimationAlgorithmDirection direction)
        {
            switch (direction)
            {
                case AnimationAlgorithmDirection.In:
                    BounceIn(from, to, elapsedTime, totalTime, 3, 2);
                    return 0;
                case AnimationAlgorithmDirection.Out:
                    BounceOut(from, to, elapsedTime, totalTime, 3, 2);
                    return 0;
                case AnimationAlgorithmDirection.Both:
                    BounceBoth(from, to, elapsedTime, totalTime, 3, 2);
                    return 0;
                default:
                    throw new NotSupportedException("不支持的算法");
            }
        }

        #region Bounce （弹球减振 加速）

        /// <summary>
        /// 弹球减振 加速
        /// </summary>
        /// <param name="origin">要变换的起始值</param>
        /// <param name="transform">要变换的总值</param>
        /// <param name="usedTime">已进行动画时间</param>
        /// <param name="allTime">总动画时间</param>
        /// <param name="bounces">反弹次数。值必须大于或等于零(默认值为3)</param>
        /// <param name="bounciness">指定反弹动画的弹性大小。虽然较高的值都会导致反弹 （弹性较小），此属性中的结果很少或者反弹低值会丢失反弹 （弹性较大） 之间的高度。此值必须是正数(默认值为 2)</param>
        /// <returns></returns>
        private double BounceIn(double origin, double transform, double usedTime, double allTime, int bounces, double bounciness)
        {
            return origin + transform * BounceInCore((usedTime / allTime), bounces, bounciness);
        }

        /// <summary>
        /// 加速 弹球减振
        /// </summary>
        /// <param name="origin">要变换的起始值</param>
        /// <param name="transform">要变换的总值</param>
        /// <param name="usedTime">已进行动画时间</param>
        /// <param name="allTime">总动画时间</param>
        /// <param name="bounces">反弹次数。值必须大于或等于零(默认值为3)</param>
        /// <param name="bounciness">指定反弹动画的弹性大小。虽然较高的值都会导致反弹 （弹性较小），此属性中的结果很少或者反弹低值会丢失反弹 （弹性较大） 之间的高度。此值必须是正数(默认值为 2)</param>
        /// <returns></returns>
        private double BounceOut(double origin, double transform, double usedTime, double allTime, int bounces, double bounciness)
        {
            return origin + transform * BounceOutCore((usedTime / allTime), bounces, bounciness);
        }

        /// <summary>
        /// 弹球减振 加速 弹球减振
        /// </summary>
        /// <param name="origin">要变换的起始值</param>
        /// <param name="transform">要变换的总值</param>
        /// <param name="usedTime">已进行动画时间</param>
        /// <param name="allTime">总动画时间</param>
        /// <param name="bounces">反弹次数。值必须大于或等于零(默认值为3)</param>
        /// <param name="bounciness">指定反弹动画的弹性大小。虽然较高的值都会导致反弹 （弹性较小），此属性中的结果很少或者反弹低值会丢失反弹 （弹性较大） 之间的高度。此值必须是正数(默认值为 2)</param>
        /// <returns></returns>
        private double BounceBoth(double origin, double transform, double usedTime, double allTime, int bounces, double bounciness)
        {
            return origin + transform * BounceBothCore(usedTime / allTime, bounces, bounciness);
        }

        /// <summary>
        /// 弹球减振 加速
        /// </summary>
        /// <param name="progressTime">已进行动画时间/总动画时间</param>
        /// <param name="bounces">反弹次数。值必须大于或等于零(默认值为3)</param>
        /// <param name="bounciness">指定反弹动画的弹性大小。虽然较高的值都会导致反弹 （弹性较小），此属性中的结果很少或者反弹低值会丢失反弹 （弹性较大） 之间的高度。此值必须是正数(默认值为 2)</param>
        /// <returns></returns>
        private double BounceInCore(double progressTime, int bounces, double bounciness)
        {
            double y1 = Math.Max(0.0, (double)bounces);
            double num1 = bounciness;
            if (num1 < 1.0 || Math.Abs(num1 - 1.0) < 2.22044604925031E-15)
                num1 = 1001.0 / 1000.0;
            double num2 = Math.Pow(num1, y1);
            double num3 = 1.0 - num1;
            double num4 = (1.0 - num2) / num3 + num2 * 0.5;
            double y2 = Math.Floor(Math.Log(-(progressTime * num4) * (1.0 - num1) + 1.0, num1));
            double y3 = y2 + 1.0;
            double num5 = (1.0 - Math.Pow(num1, y2)) / (num3 * num4);
            double num6 = (1.0 - Math.Pow(num1, y3)) / (num3 * num4);
            double num7 = (num5 + num6) * 0.5;
            double num8 = progressTime - num7;
            double num9 = num7 - num5;
            return -Math.Pow(1.0 / num1, y1 - y2) / (num9 * num9) * (num8 - num9) * (num8 + num9);
        }

        /// <summary>
        /// 加速 弹球减振
        /// </summary>
        /// <param name="progressTime">已进行动画时间/总动画时间</param>
        /// <param name="bounces">反弹次数。值必须大于或等于零(默认值为3)</param>
        /// <param name="bounciness">指定反弹动画的弹性大小。虽然较高的值都会导致反弹 （弹性较小），此属性中的结果很少或者反弹低值会丢失反弹 （弹性较大） 之间的高度。此值必须是正数(默认值为 2)</param>
        /// <returns></returns>
        private double BounceOutCore(double progressTime, int bounces, double bounciness)
        {
            return 1.0 - BounceInCore(1.0 - progressTime, bounces, bounciness);
        }

        /// <summary>
        /// 弹球减振 加速 弹球减振
        /// </summary>
        /// <param name="progressTime">已进行动画时间/总动画时间</param>
        /// <param name="bounces">反弹次数。值必须大于或等于零(默认值为3)</param>
        /// <param name="bounciness">指定反弹动画的弹性大小。虽然较高的值都会导致反弹 （弹性较小），此属性中的结果很少或者反弹低值会丢失反弹 （弹性较大） 之间的高度。此值必须是正数(默认值为 2)</param>
        /// <returns></returns>
        private double BounceBothCore(double progressTime, int bounces, double bounciness)
        {
            if (progressTime >= 0.5)
                return (1.0 - BounceInCore((1.0 - progressTime) * 2.0, bounces, bounciness)) * 0.5 + 0.5;
            return BounceInCore(progressTime * 2.0, bounces, bounciness) * 0.5;
        }

        #endregion
    }
}
