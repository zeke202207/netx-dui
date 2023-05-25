using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Netx.Dui
{
    public enum DuiExtendMode
    {
        /// <summary> 包围
        /// </summary>
        Clamp = 0,
        /// <summary> 缠绕
        /// </summary>
        Wrap = 1,
        /// <summary> 镜像
        /// </summary>
        Mirror = 2,
    }

    public enum DuiSmoothingMode
    {
        /// <summary> 指定不抗锯齿
        /// </summary>
        Default = 0,
        /// <summary> 指定抗锯齿的呈现
        /// </summary>
        AntiAlias = 1,
    }

    public enum DuiTextRenderingHint
    {
        /// <summary> 指定不抗锯齿
        /// </summary>
        Default = 0,
        /// <summary> 指定抗锯齿的呈现
        /// </summary>
        AntiAlias = 1,
    }

    public enum WeightStyle
    {
        Regular,
        Bold
    }

    public enum ItalicStyle
    {
        Normal,
        Italic
    }

    public enum MouseStatus
    {
        Default,
        Pressed,
        Hover,  
    }

    public enum AnimationAlgorithmDirection
    {
        In,
        Out,
        Both
    }
}
