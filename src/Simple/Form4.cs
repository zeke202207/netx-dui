using Netx.Dui;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Simple
{
    public partial class Form4 : Form
    {
        int i = 0;

        public Form4()
        {
            InitializeComponent();
        }

        private void dxButton1_Click(object sender, EventArgs e)
        {
            if (i++ % 2 == 0)
                DxSkinManager.Instance.Apply(new MyScheme());
            else
                DxSkinManager.Instance.Apply(new DefaultScheme());
        }

        private void dxButton2_Click(object sender, EventArgs e)
        {

            var rectf = new RectangleF(0, 0, 40, 40);
            var g = this.panel1.CreateGraphics();

            g.DrawRectangle(Pens.Red, new Rectangle((int)rectf.X, (int)rectf.Y, (int)rectf.Width, (int)rectf.Height));
            

            PointF[] zeke;
            Rect2Pointfs(new Rectangle(0, 0, 40, 40), 25, out zeke);
            int i = 0;
            foreach(var p in zeke)
            {
                //g.DrawEllipse(Pens.Black, p.X, p.Y, 2, 2);
                g.DrawString(i++.ToString(), this.Font, Brushes.Black, p);
            }
            g.DrawLines(Pens.GreenYellow, zeke);

            Rectangle bound;
            MinBoundRect(zeke, out bound);
            g.DrawRectangle(Pens.Blue, bound);
        }

        private Point PointRotate(Point center, Point p1, double angle)
        {
            Point tmp = new Point();
            double angleHude = angle * Math.PI / 180;/*角度变成弧度*/
            double x1 = (p1.X - center.X) * Math.Cos(angleHude) + (p1.Y - center.Y) * Math.Sin(angleHude) + center.X;
            double y1 = -(p1.X - center.X) * Math.Sin(angleHude) + (p1.Y - center.Y) * Math.Cos(angleHude) + center.Y;
            tmp.X = (int)x1;
            tmp.Y = (int)y1;
            return tmp;
        }

        private RectangleF RotateRectEx(RectangleF rect, float angle)
        {
            if (angle == 0) return rect;
            Matrix matrix = new Matrix();
            PointF center = new PointF(rect.X + rect.Width / 2, rect.Y + rect.Height / 2);
            matrix.RotateAt(angle, center);
            PointF[] pts = new PointF[]
            {
                rect.Location,
                new PointF(rect.Right,rect.Y),
                new PointF(rect.Right,rect.Bottom),
                new PointF(rect.X,rect.Bottom)
            };
            matrix.TransformPoints(pts);
            float x, y, r, b;
            x = r = pts[0].X;
            y = b = pts[0].Y;
            foreach (var cur in pts.Skip(1))
            {
                if (cur.X < x) x = cur.X;
                if (cur.X > r) r = cur.X;
                if (cur.Y < y) y = cur.Y;
                if (cur.Y > b) b = cur.Y;
            }
            return new RectangleF(x, y, r - x, b - y);
        }

        private RectangleF RotateRect(RectangleF rect, float angle)
        {
            if (angle == 0) return rect;
            GraphicsPath path = new GraphicsPath();
            path.AddRectangle(rect);
            Matrix matrix = new Matrix();
            PointF center = new PointF(rect.X + rect.Width / 2, rect.Y + rect.Height / 2);
            matrix.RotateAt(angle, center);
            path.Transform(matrix);
            RectangleF res = path.GetBounds();
            path.Dispose();
            return res;
        }

        


        
        private void Rect2Pointfs(Rectangle rect, float angle, out PointF[] lpfs)
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
                lpfs = graph.PathPoints;
            }
        }

        private void MinBoundRect(PointF[] lines, out Rectangle Mbr)
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
            Mbr = new Rectangle((int)x, (int)y, (int)(xw - x), (int)(yh - y));
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            this.dxLabel2.Text = e.Location.ToString();
        }

        private void zeke1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
