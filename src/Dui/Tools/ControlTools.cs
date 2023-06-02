using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Netx.Dui.Tools
{
    internal class ControlTools
    {
        /// <summary>
        /// 一个矩形在其中心点旋转angle角度后矩形4个点的坐标
        ///   1   2
        ///   0   3
        /// </summary>
        /// <param name="rect">旋转前矩形</param>
        /// <param name="angle">旋转角度 -> 正数：顺时针旋转</param>
        public static PointF[] Rect2Pointfs(Rectangle rect, float angle)
        {
            using (var graph = new GraphicsPath())
            {
                Point Center = new Point(rect.X + rect.Width / 2, rect.Y + rect.Height / 2);
                graph.AddRectangle(rect);
                var a = -angle * (Math.PI / 180);
                var n1 = (float)Math.Cos(a);
                var n2 = (float)Math.Sin(a);
                var n3 = -(float)Math.Sin(a);
                var n4 = (float)Math.Cos(a);
                var n5 = (float)(Center.X * (1 - Math.Cos(a)) + Center.Y * Math.Sin(a));
                var n6 = (float)(Center.Y * (1 - Math.Cos(a)) - Center.X * Math.Sin(a));
                graph.Transform(new Matrix(n1, n2, n3, n4, n5, n6));
                return graph.PathPoints;
            }
        }

        /// <summary>
        /// 获取一组点最小外接矩形
        /// </summary>
        /// <param name="lines"></param>
        public static Rectangle MinBoundRect(PointF[] lines)
        {
            float x, y, xw, yh;
            x = xw = lines[0].X;
            y = yh = lines[0].Y;
            foreach (var item in lines)
            {
                if (item.X < x)
                    x = item.X;
                if (item.X > xw)
                    xw = item.X;
                if (item.Y < y)
                    y = item.Y;
                if (item.Y > yh)
                    yh = item.Y;
            }
            return new Rectangle((int)x, (int)y, (int)(xw - x), (int)(yh - y));
        }
    }
}
