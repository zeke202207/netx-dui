﻿using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Netx.Dui
{
    public class DuiGraphics : IDisposable
    {
        IDuiGraphics iDUIGraphics = null;

        private DuiGraphics(IntPtr handle)
        {
            //this.iDUIGraphics = new DUIGraphics_GDIP(handle);
            this.iDUIGraphics = new DuiGraphics_D2D(handle);
            //switch (DUIInfo.Mode)
            //{
            //    case DUIMode.Direct2D:
            //    default:
            //        this.iDUIGraphics = new DUIGraphics_D2D(handle);
            //        break;
            //    case DUIMode.GDIP:
            //        this.iDUIGraphics = new DUIGraphics_GDIP(handle);
            //        break;
            //}
        }

        private DuiGraphics(DuiBitmap dUIBitmap)
        {
            this.iDUIGraphics = new DuiGraphics_D2D(dUIBitmap);
        }

        private DuiGraphics(Graphics graphics)
        {
            //this.iDUIGraphics = new DUIGraphics_GDIP(handle);
            this.iDUIGraphics = new DuiGraphics_GDIP(graphics);
            //switch (DUIInfo.Mode)
            //{
            //    case DUIMode.Direct2D:
            //    default:
            //        this.iDUIGraphics = new DUIGraphics_D2D(handle);
            //        break;
            //    case DUIMode.GDIP:
            //        this.iDUIGraphics = new DUIGraphics_GDIP(handle);
            //        break;
            //}
        }

        #region 

        public static DuiGraphics FromControl(Control control)
        {
            return new DuiGraphics(control.Handle);
        }

        public static DuiGraphics FromImage(DuiBitmap image)
        {
            return new DuiGraphics(image);
        }

        #endregion

        #region 属性

        /// <summary> 锁定Transform使其失效
        /// </summary>
        public bool LockTransform { get; set; }
        public DuiSmoothingMode SmoothingMode
        {
            get
            {
                return this.iDUIGraphics.SmoothingMode;
            }
            set
            {
                this.iDUIGraphics.SmoothingMode = value;
            }
        }

        public DuiTextRenderingHint TextRenderingHint
        {
            get
            {
                return this.iDUIGraphics.TextRenderingHint;
            }
            set
            {
                this.iDUIGraphics.TextRenderingHint = value;
            }
        }

        public DuiMatrix Transform
        {
            get
            {
                return this.iDUIGraphics.Transform;
            }
            set
            {
                if (!this.LockTransform)
                {
                    this.iDUIGraphics.Transform = value;
                }
            }
        }
        public float DpiX
        {
            get
            {
                return this.iDUIGraphics.DpiX;
            }
        }
        public float DpiY
        {
            get
            {
                return this.iDUIGraphics.DpiX;
            }
        }
        public RectangleF ClipBounds
        {
            get { return this.iDUIGraphics.ClipBounds; }
        }

        #endregion

        #region 函数

        public DuiGraphicsState Save()
        {
            return this.iDUIGraphics.Save();
        }

        public void Restore(DuiGraphicsState graphicsState)
        {
            this.iDUIGraphics.Restore(graphicsState);
        }

        public void BeginDraw(Region r = null)
        {
            this.iDUIGraphics.BeginDraw(r);
        }

        public void Clear(Color color)
        {
            this.iDUIGraphics.Clear(color);
        }

        public void EndDraw()
        {
            this.iDUIGraphics.EndDraw();
        }

        public void ResetTransform()
        {
            this.iDUIGraphics.ResetTransform();
        }

        public void Resize(float width, float height)
        {
            this.Resize(new SizeF(width, height));
        }

        public void Resize(SizeF size)
        {
            this.iDUIGraphics.Resize(size);
        }

        #endregion

        #region RoundedRectangle

        public void DrawRoundedRectangle(DuiPen pen, int x, int y, int width, int height, float radius)
        {
            this.DrawRoundedRectangle(pen, (float)x, (float)y, (float)width, (float)height, radius);
        }
        public void DrawRoundedRectangle(DuiPen pen, Rectangle rect, float radius)
        {
            this.DrawRoundedRectangle(pen, rect.X, rect.Y, rect.Width, rect.Height, radius);
        }
        public void DrawRoundedRectangle(DuiPen pen, float x, float y, float width, float height, float radius)
        {
            if (pen.Width == 0 || width == 0 || height == 0) { return; }
            this.iDUIGraphics.DrawRoundedRectangle(pen, x, y, width, height, radius);
        }
        public void DrawRoundedRectangle(DuiPen pen, RectangleF rect, float radius)
        {
            this.DrawRoundedRectangle(pen, rect.X, rect.Y, rect.Width, rect.Height, radius);
        }
        public void FillRoundedRectangle(DuiBrush brush, int x, int y, int width, int height, float radius)
        {
            this.FillRoundedRectangle(brush, (float)x, (float)y, (float)width, (float)height, radius);
        }
        public void FillRoundedRectangle(DuiBrush brush, Rectangle rect, float radius)
        {
            this.FillRoundedRectangle(brush, rect.X, rect.Y, rect.Width, rect.Height, radius);
        }
        public void FillRoundedRectangle(DuiBrush brush, float x, float y, float width, float height, float radius)
        {
            if (width == 0 || height == 0) { return; }
            this.iDUIGraphics.FillRoundedRectangle(brush, x, y, width, height, radius);
        }
        public void FillRoundedRectangle(DuiBrush brush, RectangleF rect, float radius)
        {
            this.FillRoundedRectangle(brush, rect.X, rect.Y, rect.Width, rect.Height, radius);
        }

        #endregion

        #region Rectangle

        public void DrawRectangle(DuiPen pen, int x, int y, int width, int height)
        {
            this.DrawRectangle(pen, (float)x, (float)y, (float)width, (float)height);
        }
        public void DrawRectangle(DuiPen pen, Rectangle rect)
        {
            this.DrawRectangle(pen, rect.X, rect.Y, rect.Width, rect.Height);
        }
        public void DrawRectangles(DuiPen pen, Rectangle[] rects)
        {
            foreach (Rectangle rect in rects)
            {
                DrawRectangle(pen, rect);
            }
        }
        public void DrawRectangle(DuiPen pen, float x, float y, float width, float height)
        {
            if (pen.Width == 0 || width == 0 || height == 0) { return; }
            this.iDUIGraphics.DrawRectangle(pen, x, y, width, height);
        }
        public void DrawRectangle(DuiPen pen, RectangleF rect)
        {
            this.DrawRectangle(pen, rect.X, rect.Y, rect.Width, rect.Height);
        }
        public void DrawRectangles(DuiPen pen, RectangleF[] rects)
        {
            foreach (RectangleF rect in rects)
            {
                DrawRectangle(pen, rect);
            }
        }
        public void FillRectangle(DuiBrush brush, int x, int y, int width, int height)
        {
            this.FillRectangle(brush, (float)x, (float)y, (float)width, (float)height);
        }
        public void FillRectangle(DuiBrush brush, Rectangle rect)
        {
            this.FillRectangle(brush, rect.X, rect.Y, rect.Width, rect.Height);
        }
        public void FillRectangles(DuiBrush brush, Rectangle[] rects)
        {
            foreach (Rectangle rect in rects)
            {
                FillRectangle(brush, rect);
            }
        }
        public void FillRectangle(DuiBrush brush, float x, float y, float width, float height)
        {
            if (width == 0 || height == 0) { return; }
            this.iDUIGraphics.FillRectangle(brush, x, y, width, height);
        }
        public void FillRectangle(DuiBrush brush, RectangleF rect)
        {
            this.FillRectangle(brush, rect.X, rect.Y, rect.Width, rect.Height);
        }
        public void FillRectangles(DuiBrush brush, RectangleF[] rects)
        {
            foreach (RectangleF rect in rects)
            {
                FillRectangle(brush, rect);
            }
        }

        #endregion

        #region Ellipse

        public void DrawEllipse(DuiPen pen, int x, int y, int width, int height)
        {
            this.DrawEllipse(pen, (float)x, (float)y, (float)width, (float)height);
        }
        public void DrawEllipse(DuiPen pen, Rectangle rect)
        {
            this.DrawEllipse(pen, rect.X, rect.Y, rect.Width, rect.Height);
        }
        public void DrawEllipse(DuiPen pen, float x, float y, float width, float height)
        {
            if (pen.Width == 0 || width == 0 || height == 0) { return; }
            this.iDUIGraphics.DrawEllipse(pen, x, y, width, height);
        }
        public void DrawEllipses(DuiPen pen, RectangleF[] rects)
        {
            foreach (RectangleF rect in rects)
            {
                DrawEllipse(pen, rect);
            }
        }
        public void DrawEllipse(DuiPen pen, RectangleF rect)
        {
            this.DrawEllipse(pen, rect.X, rect.Y, rect.Width, rect.Height);
        }
        public void FillEllipse(DuiBrush brush, int x, int y, int width, int height)
        {
            this.FillEllipse(brush, (float)x, (float)y, (float)width, (float)height);
        }
        public void FillEllipses(DuiBrush brush, RectangleF[] rects)
        {
            foreach (RectangleF rect in rects)
            {
                FillEllipse(brush, rect);
            }
        }
        public void FillEllipse(DuiBrush brush, Rectangle rect)
        {
            this.FillEllipse(brush, rect.X, rect.Y, rect.Width, rect.Height);
        }
        public void FillEllipse(DuiBrush brush, float x, float y, float width, float height)
        {
            if (width == 0 || height == 0) { return; }
            this.iDUIGraphics.FillEllipse(brush, x, y, width, height);
        }
        public void FillEllipse(DuiBrush brush, RectangleF rect)
        {
            this.FillEllipse(brush, rect.X, rect.Y, rect.Width, rect.Height);
        }

        #endregion

        #region Polygon

        public void DrawPolygon(DuiPen pen, Point[] points)
        {
            this.DrawPolygon(pen, points.Select(p => (PointF)p).ToArray());
        }
        public void DrawPolygon(DuiPen pen, PointF[] points)
        {
            if (pen.Width == 0) { return; }
            if (points == null) { return; }
            if (points.Length < 3) { return; }
            this.iDUIGraphics.DrawPolygon(pen, points);
        }
        public void FillPolygon(DuiBrush brush, Point[] points)
        {
            this.FillPolygon(brush, points.Select(p => (PointF)p).ToArray());
        }
        public void FillPolygon(DuiBrush brush, PointF[] points)
        {
            if (points == null) { return; }
            if (points.Length < 3) { return; }
            this.iDUIGraphics.FillPolygon(brush, points);
        }

        #endregion

        #region Region

        public void FillRegion(DuiBrush brush, DuiRegion region)
        {
            this.iDUIGraphics.FillRegion(brush, region);
        }

        #endregion

        #region Line

        public void DrawLines(DuiPen pen, PointF[] points)
        {
            if (points.Length < 2)
            {
                return;
            }
            for (int i = 1; i < points.Length; i++)
            {
                PointF pt1 = points[i - 1];
                PointF pt2 = points[i];
                this.DrawLine(pen, pt1, pt2);
            }
        }
        public void DrawLines(DuiPen pen, Point[] points)
        {
            this.DrawLines(pen, points.Select(p => new PointF(p.X, p.Y)).ToArray());
        }
        public void DrawLine(DuiPen pen, int x1, int y1, int x2, int y2)
        {
            this.DrawLine(pen, (float)x1, (float)y1, (float)x2, (float)y2);
        }
        public void DrawLine(DuiPen pen, Point pt1, Point pt2)
        {
            this.DrawLine(pen, pt1.X, pt1.Y, pt2.X, pt2.Y);
        }
        public void DrawLine(DuiPen pen, float x1, float y1, float x2, float y2)
        {
            if (pen.Width == 0) { return; }
            if (x1 == x2 && y1 == y2) { return; }
            this.iDUIGraphics.DrawLine(pen, x1, y1, x2, y2);
        }
        public void DrawLine(DuiPen pen, PointF pt1, PointF pt2)
        {
            this.DrawLine(pen, pt1.X, pt1.Y, pt2.X, pt2.Y);
        }

        #endregion

        #region Bezier

        public void DrawBezier(DuiPen pen, int x1, int y1, int x2, int y2, int x3, int y3, int x4, int y4)
        {
            this.DrawBezier(pen, (float)x1, (float)y1, (float)x2, (float)y2, (float)x3, (float)y3, (float)x4, (float)y4);
        }
        public void DrawBezier(DuiPen pen, Point p1, Point p2, Point p3, Point p4)
        {
            this.DrawBezier(pen, p1.X, p1.Y, p2.X, p2.Y, p3.X, p3.Y, p4.X, p4.Y);
        }
        public void DrawBezier(DuiPen pen, float x1, float y1, float x2, float y2, float x3, float y3, float x4, float y4)
        {
            if (pen.Width == 0) { return; }
            this.iDUIGraphics.DrawBezier(pen, x1,  y1,  x2,  y2,  x3,  y3,  x4,  y4);
        }
        public void DrawBezier(DuiPen pen, PointF p1, PointF p2, PointF p3, PointF p4)
        {
            this.DrawBezier(pen, p1.X, p1.Y, p2.X, p2.Y, p3.X, p3.Y, p4.X, p4.Y);
        }

        #endregion

        #region String

        public SizeF MeasureString(string text, DuiFont font)
        {
            return this.MeasureString(text, font, float.MaxValue, 0);
        }

        public SizeF MeasureString(string text, DuiFont font, SizeF size)
        {
            return this.MeasureString(text, font, size.Width, size.Height);
        }

        public SizeF MeasureString(string text, DuiFont font, float width, float height)
        {
            if (string.IsNullOrWhiteSpace(text)) { return SizeF.Empty; }
            return this.iDUIGraphics.MeasureString(text, font, width, height);
        }

        public void DrawString(string s, DuiFont font, DuiBrush brush, PointF p)
        {
            DrawString(s, font, brush, p.X, p.Y);
        }

        public void DrawString(string s, DuiFont font, DuiBrush brush, float x, float y)
        {
            DrawString(s, font, brush, new RectangleF(new PointF(x, y), MeasureString(s, font)), StringFormat.GenericDefault);
        }

        public void DrawString(string s, DuiFont font, DuiBrush brush, RectangleF layoutRectangle)
        {
            DrawString(s, font, brush, layoutRectangle, StringFormat.GenericDefault);
        }

        public void DrawString(string s, DuiFont font, DuiBrush brush, RectangleF layoutRectangle, StringFormat format)
        {
            if (string.IsNullOrWhiteSpace(s)) { return; }
            this.iDUIGraphics.DrawString(s, font, brush, layoutRectangle, format);
        }

        #endregion

        #region Image

        public void DrawImage(DuiImage image, int x, int y)
        {
            this.DrawImage(image, (float)x, (float)y);
        }
        public void DrawImage(DuiImage image, int x, int y, float opacity)
        {
            this.DrawImage(image, (float)x, (float)y, opacity);
        }
        public void DrawImage(DuiImage image, float x, float y)
        {
            this.DrawImage(image, x, y, 1);
        }
        public void DrawImage(DuiImage image, float x, float y, float opacity)
        {
            this.DrawImage(image, new RectangleF(x, y, image.Width, image.Height), new RectangleF(0, 0, image.Width, image.Height), GraphicsUnit.Pixel, opacity);
        }
        public void DrawImage(DuiImage image, PointF point)
        {
            this.DrawImage(image, point.X, point.Y);
        }
        public void DrawImage(DuiImage image, PointF point, float opacity)
        {
            this.DrawImage(image, point.X, point.Y, opacity);
        }
        public void DrawImage(DuiImage image, int x, int y, int width, int height)
        {
            this.DrawImage(image, (float)x, (float)y, (float)width, (float)height);
        }
        public void DrawImage(DuiImage image, int x, int y, int width, int height, float opacity)
        {
            this.DrawImage(image, (float)x, (float)y, (float)width, (float)height, opacity);
        }
        public void DrawImage(DuiImage image, float x, float y, float width, float height)
        {
            this.DrawImage(image, new RectangleF(x, y, width, height), new RectangleF(0, 0, image.Width, image.Height), GraphicsUnit.Pixel, 1);
        }
        public void DrawImage(DuiImage image, float x, float y, float width, float height, float opacity)
        {
            this.DrawImage(image, new RectangleF(x, y, width, height), new RectangleF(0, 0, image.Width, image.Height), GraphicsUnit.Pixel, opacity);
        }
        public void DrawImage(DuiImage image, Rectangle rect)
        {
            this.DrawImage(image, rect.X, rect.Y, rect.Width, rect.Height);
        }
        public void DrawImage(DuiImage image, Rectangle rect, float opacity)
        {
            this.DrawImage(image, rect.X, rect.Y, rect.Width, rect.Height, opacity);
        }
        public void DrawImage(DuiImage image, RectangleF rect)
        {
            this.DrawImage(image, rect.X, rect.Y, rect.Width, rect.Height);
        }
        public void DrawImage(DuiImage image, RectangleF rect, float opacity)
        {
            this.DrawImage(image, rect.X, rect.Y, rect.Width, rect.Height, opacity);
        }
        public void DrawImage(DuiImage image, Rectangle destRect, Rectangle srcRect, GraphicsUnit srcUnit)
        {
            this.DrawImage(image, (RectangleF)destRect, (RectangleF)srcRect, srcUnit);
        }
        public void DrawImage(DuiImage image, RectangleF destRect, RectangleF srcRect, GraphicsUnit srcUnit)
        {
            this.DrawImage(image, destRect, srcRect, srcUnit, 1);
        }
        public void DrawImage(DuiImage image, Rectangle destRect, Rectangle srcRect, GraphicsUnit srcUnit, float opacity)
        {
            this.DrawImage(image, (RectangleF)destRect, (RectangleF)srcRect, srcUnit, opacity);
        }
        public void DrawImage(DuiImage image, RectangleF destRect, RectangleF srcRect, GraphicsUnit srcUnit, float opacity)
        {
            if (image == null || destRect.Width == 0 || destRect.Height == 0 || srcRect.Width == 0 || srcRect.Height == 0) { return; }
            this.iDUIGraphics.DrawImage(image, destRect, srcRect, srcUnit, opacity);
        }
        public void DrawImage(DuiImage image, Point[] destTriangle, Point[] srcTriangle)
        {
            this.DrawImage(image, destTriangle, srcTriangle, GraphicsUnit.Pixel, 1);
        }
        public void DrawImage(DuiImage image, Point[] destTriangle, Point[] srcTriangle, GraphicsUnit srcUnit, float opacity)
        {
            this.DrawImage(image, destTriangle.Select(p => (PointF)p).ToArray(), srcTriangle.Select(p => (PointF)p).ToArray(), srcUnit, opacity);
        }
        public void DrawImage(DuiImage image, PointF[] destTriangle, PointF[] srcTriangle)
        {
            this.DrawImage(image, destTriangle, srcTriangle, GraphicsUnit.Pixel, 1);
        }
        public void DrawImage(DuiImage image, PointF[] destTriangle, PointF[] srcTriangle, GraphicsUnit srcUnit, float opacity)
        {
            if (image == null || destTriangle.Length != 3 || srcTriangle.Length != 3) { return; }
            this.iDUIGraphics.DrawImage(image, destTriangle, srcTriangle, srcUnit, opacity);
        }
        public void DrawImage(DuiImage image, PointF[] polygon)
        {
            this.DrawImage(image, polygon, GraphicsUnit.Pixel, 1);
        }
        public void DrawImage(DuiImage image, Point[] polygon)
        {
            this.DrawImage(image, polygon, GraphicsUnit.Pixel, 1);
        }
        public void DrawImage(DuiImage image, PointF[] polygon, float opacity)
        {
            this.DrawImage(image, polygon, GraphicsUnit.Pixel, opacity);
        }
        public void DrawImage(DuiImage image, Point[] polygon, float opacity)
        {
            this.DrawImage(image, polygon, GraphicsUnit.Pixel, opacity);
        }
        public void DrawImage(DuiImage image, Point[] polygon, GraphicsUnit srcUnit, float opacity)
        {
            this.DrawImage(image, polygon.Select(p => (PointF)p).ToArray(), srcUnit, opacity);
        }
        public void DrawImage(DuiImage image, PointF[] polygon, GraphicsUnit srcUnit, float opacity)
        {
            if (image == null || polygon.Length < 3) { return; }
            this.iDUIGraphics.DrawImage(image, polygon, srcUnit, opacity);
        }
        //  public void DrawBitmapMesh(DuiImage image, int meshWidth, int meshHeight, PointF[] points)
        //{
        //    if (image == null) { return; }
        //    image.RenderTarget = this.target.RenderTarget;
        //    float w = (float)image.Width / meshWidth;
        //    float h = (float)image.Height / meshHeight;
        //    PointF[,] pts = new PointF[meshWidth + 1, meshHeight + 1];
        //    for (int y = 0; y <= meshHeight; y++)
        //    {
        //        for (int x = 0; x <= meshWidth; x++)
        //        {
        //            pts[x, y] = points[(meshWidth + 1) * y + x];
        //        }
        //    }
        //    for (int y = 0; y < meshHeight; y++)
        //    {
        //        for (int x = 0; x < meshWidth; x++)
        //        {
        //            float offset = 0.5F;
        //            PointF ptLT = pts[x, y];
        //            PointF ptRT = pts[x + 1, y];
        //            PointF ptLB = pts[x, y + 1];
        //            PointF ptRB = pts[x + 1, y + 1];
        //            ptRT = new PointF(ptRT.X + offset, ptRT.Y);
        //            ptLB = new PointF(ptLB.X, ptLB.Y + offset);
        //            ptRB = new PointF(ptRB.X + offset, ptRB.Y + offset);
        //            DuiMatrix4x4 matrix4x4_1 = new DuiMatrix4x4(
        //                1F / w, 0, 0, 0,
        //                0, 1F / h, 0, 0,
        //                0, 0, 1, 0,
        //                0, 0, 0, 1);
        //            DuiMatrix4x4 matrix4x4_2 = new DuiMatrix4x4(
        //                ptRT.X - ptLT.X, ptRT.Y - ptLT.Y, 0, 0,
        //                ptLB.X - ptLT.X, ptLB.Y - ptLT.Y, 0, 0,
        //                0, 0, 1, 0,
        //                ptLT.X, ptLT.Y, 0, 1);
        //            float den = matrix4x4_2.M11 * matrix4x4_2.M22 - matrix4x4_2.M12 * matrix4x4_2.M21;
        //            float a = (matrix4x4_2.M22 * ptRB.X - matrix4x4_2.M21 * ptRB.Y +
        //                matrix4x4_2.M21 * matrix4x4_2.M42 - matrix4x4_2.M22 * matrix4x4_2.M41) / den;
        //            float b = (matrix4x4_2.M11 * ptRB.Y - matrix4x4_2.M12 * ptRB.X +
        //                matrix4x4_2.M12 * matrix4x4_2.M41 - matrix4x4_2.M11 * matrix4x4_2.M42) / den;
        //            DuiMatrix4x4 matrix4x4_3 = new DuiMatrix4x4(
        //                a / (a + b - 1), 0, 0, a / (a + b - 1) - 1,
        //                0, b / (a + b - 1), 0, b / (a + b - 1) - 1,
        //                0, 0, 1, 0,
        //                0, 0, 0, 1);
        //            DuiMatrix4x4 matrix4x4 = matrix4x4_1 * matrix4x4_3 * matrix4x4_2;
        //            //((SharpDX.Direct2D1.DeviceContext)this.target.RenderTarget).DrawBitmap(image, DxConvert.ToRectF(new RectangleF(0, 0, w, h)), 1, SharpDX.Direct2D1.InterpolationMode.NearestNeighbor, DxConvert.ToRectF(new RectangleF(x * w, y * h, w, h)), matrix4x4);
        //        }
        //    }

        #endregion

        #region Transform

        public void TranslateTransform(PointF offset)
        {
            this.iDUIGraphics.TranslateTransform(offset.X, offset.Y);
        }
        public void TranslateTransform(float offsetX, float offsetY)
        {
            this.iDUIGraphics.TranslateTransform(offsetX, offsetY);
        }
        public void ScaleTransform(PointF scale)
        {
            this.iDUIGraphics.ScaleTransform(scale.X, scale.Y);
        }
        public void ScaleTransform(float scaleX, float scaleY)
        {
            this.iDUIGraphics.ScaleTransform(scaleX, scaleY);
        }
        public void ScaleTransform(PointF scale, float centerX, float centerY)
        {
            this.ScaleTransform(scale.X, scale.Y, centerX, centerY);
        }
        public void ScaleTransform(float scaleX, float scaleY, PointF center)
        {
            this.ScaleTransform(scaleX, scaleY, center.X, center.Y);
        }
        public void ScaleTransform(PointF scale, PointF center)
        {
            this.ScaleTransform(scale.X, scale.Y, center.X, center.Y);
        }
        public void ScaleTransform(float scaleX, float scaleY, float centerX, float centerY)
        {
            this.TranslateTransform(centerX, centerY);
            this.ScaleTransform(scaleX, scaleY);
            this.TranslateTransform(-centerX, -centerY);
        }
        public void RotateTransform(float rotate)
        {
            this.iDUIGraphics.RotateTransform(rotate);
        }
        public void RotateTransform(float rotate, PointF center)
        {
            this.RotateTransform(rotate, center.X, center.Y);
        }
        public void RotateTransform(float rotate, float centerX, float centerY)
        {
            this.TranslateTransform(centerX, centerY);
            this.RotateTransform(rotate);
            this.TranslateTransform(-centerX, -centerY);
        }
        public void SkewTransform(PointF skew)
        {
            this.iDUIGraphics.SkewTransform(skew.X, skew.Y);
        }
        public void SkewTransform(float skewX, float skewY)
        {
            this.iDUIGraphics.SkewTransform(skewX, skewY);
        }
        public void SkewTransform(PointF skew, float centerX, float centerY)
        {
            this.SkewTransform(skew.X, skew.Y, centerX, centerY);
        }
        public void SkewTransform(float skewX, float skewY, PointF center)
        {
            this.SkewTransform(skewX, skewY, center.X, center.Y);
        }
        public void SkewTransform(PointF skew, PointF center)
        {
            this.SkewTransform(skew.X, skew.Y, center.X, center.Y);
        }
        public void SkewTransform(float skewX, float skewY, float centerX, float centerY)
        {
            this.TranslateTransform(centerX, centerY);
            this.SkewTransform(skewX, skewY);
            this.TranslateTransform(-centerX, -centerY);
        }

        #endregion

        #region Layer

        public void PushLayer(RectangleF bounds)
        {
            PushLayer(bounds.X, bounds.Y, bounds.Width, bounds.Height);
        }
        public void PushLayer(SizeF size)
        {
            PushLayer(0, 0, size.Width, size.Height);
        }
        public void PushLayer(float width, float height)
        {
            PushLayer(0, 0, width, height);
        }
        public void PushLayer(float x, float y, float width, float height)
        {
            iDUIGraphics.PushLayer(x, y, width, height);
        }
        public void PopLayer()
        {
            iDUIGraphics.PopLayer();
        }

        #endregion

        #region IDisposable

        public void Dispose()
        {
            iDUIGraphics.Dispose();
        }

        #endregion

        /// <summary>
        /// usage
        /// DuiGraphics test = e.Graphics;
        /// </summary>
        /// <param name="graphics"></param>
        public static implicit operator DuiGraphics(Graphics graphics)
        {
            return new DuiGraphics(graphics);
        }

        public override bool Equals(object obj)
        {
            DuiGraphics dUIGraphics = obj as DuiGraphics;
            if (dUIGraphics == null)
            {
                return false;
            }
            else
            {
                return this.iDUIGraphics.Equals(dUIGraphics.iDUIGraphics);
            }
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
