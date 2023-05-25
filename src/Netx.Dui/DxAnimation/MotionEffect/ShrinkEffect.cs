using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Netx.Dui.DxAnimation.Algorithm
{
    /// <summary>
    /// 收缩运动效果
    /// </summary>
    internal class ShrinkEffect : IMotionEffect
    {
        public double Calculate(double from, double to, double totalTime, double elapsedTime, AnimationAlgorithmDirection direction)
        {
            switch (direction)
            {
                case AnimationAlgorithmDirection.In:
                    BackIn(from, to, elapsedTime, totalTime, 3, 1);
                    return 0;
                case AnimationAlgorithmDirection.Out:
                    BackOut(from, to, elapsedTime, totalTime, 3, 1);
                    return 0;
                case AnimationAlgorithmDirection.Both:
                    BackBoth(from, to, elapsedTime, totalTime, 3, 1);
                    return 0;
                default:
                    throw new NotSupportedException("不支持的算法");
            }
        }

        #region Back （收缩）

        /// <summary>
        /// 收缩
        /// </summary>
        /// <param name="origin">要变换的起始值</param>
        /// <param name="transform">要变换的总值</param>
        /// <param name="usedTime">已进行动画时间</param>
        /// <param name="allTime">总动画时间</param>
        /// <param name="power">动画曲线幂(默认值3)</param>
        /// <param name="amplitude">收缩与相关联的幅度动画。此值必须大于或等于 0。 默认值为 1。</param>
        /// <returns></returns>
        private double BackIn(double origin, double transform, double usedTime, double allTime, double power, double amplitude)
        {
            return origin + transform * BackInCore((usedTime / allTime), power, amplitude);
        }

        /// <summary>
        /// 收缩
        /// </summary>
        /// <param name="origin">要变换的起始值</param>
        /// <param name="transform">要变换的总值</param>
        /// <param name="usedTime">已进行动画时间</param>
        /// <param name="allTime">总动画时间</param>
        /// <param name="power">动画曲线幂(默认值3)</param>
        /// <param name="amplitude">收缩与相关联的幅度动画。此值必须大于或等于 0。 默认值为 1。</param>
        /// <returns></returns>
        private double BackOut(double origin, double transform, double usedTime, double allTime, double power, double amplitude)
        {
            return origin + transform * BackOutCore((usedTime / allTime), power, amplitude);
        }

        /// <summary>
        /// 收缩
        /// </summary>
        /// <param name="origin">要变换的起始值</param>
        /// <param name="transform">要变换的总值</param>
        /// <param name="usedTime">已进行动画时间</param>
        /// <param name="allTime">总动画时间</param>
        /// <param name="power">动画曲线幂(默认值3)</param>
        /// <param name="amplitude">收缩与相关联的幅度动画。此值必须大于或等于 0。 默认值为 1。</param>
        /// <returns></returns>
        private double BackBoth(double origin, double transform, double usedTime, double allTime, double power, double amplitude)
        {
            return origin + transform * BackBothCore(usedTime / allTime, power, amplitude);
        }

        /// <summary>
        /// 收缩
        /// </summary>
        /// <param name="progressTime">已进行动画时间/总动画时间</param>
        /// <param name="power">动画曲线幂(默认值3)</param>
        /// <param name="amplitude">收缩与相关联的幅度动画。此值必须大于或等于 0。 默认值为 1。</param>
        /// <returns></returns>
        private double BackInCore(double progressTime, double power, double amplitude)
        {
            amplitude = Math.Max(0.0, amplitude);
            return Math.Pow(progressTime, power) - progressTime * amplitude * Math.Sin(Math.PI * progressTime);
        }

        /// <summary>
        /// 收缩
        /// </summary>
        /// <param name="progressTime">已进行动画时间/总动画时间</param>
        /// <param name="power">动画曲线幂(默认值3)</param>
        /// <param name="amplitude">收缩与相关联的幅度动画。此值必须大于或等于 0。 默认值为 1。</param>
        /// <returns></returns>
        private double BackOutCore(double progressTime, double power, double amplitude)
        {
            return 1.0 - BackInCore(1.0 - progressTime, power, amplitude);
        }

        /// <summary>
        /// 收缩
        /// </summary>
        /// <param name="progressTime">已进行动画时间/总动画时间</param>
        /// <param name="power">动画曲线幂(默认值3)</param>
        /// <param name="amplitude">收缩与相关联的幅度动画。此值必须大于或等于 0。 默认值为 1。</param>
        /// <returns></returns>
        private double BackBothCore(double progressTime, double power, double amplitude)
        {
            if (progressTime >= 0.5)
                return (1.0 - BackInCore((1.0 - progressTime) * 2.0, power, amplitude)) * 0.5 + 0.5;
            return BackInCore(progressTime * 2.0, power, amplitude) * 0.5;
        }

        #endregion
    }
}
