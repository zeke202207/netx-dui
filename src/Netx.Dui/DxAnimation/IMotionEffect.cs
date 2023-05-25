using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Netx.Dui.DxAnimation
{
    [Description("线性动画函数(算法基本由Silverlight提取出来)")]
    public interface IMotionEffect
    {
        /// <summary>
        /// 算法计算
        /// </summary>
        /// <param name="from">起始位置</param>
        /// <param name="to">目标位置</param>
        /// <param name="totalTime">总时长</param>
        /// <param name="elapsedTime">经过时长</param>
        /// <param name="direction">方向</param>
        /// <returns></returns>
        double Calculate(double from, double to, double totalTime, double elapsedTime, AnimationAlgorithmDirection direction);
    }
}
