﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace Netx.Dui
{
    public class DuiGraphics_GDIP : IDuiGraphics
    {
        #region 变量

        /// <summary> 图层堆栈
        /// </summary>
        private Stack<Layer> layerStacks = new Stack<Layer>();
        private Graphics graphics = null;
        private Region clip = new Region(); //直接对graphics.Clip赋值很影响效率
        //private SizeF maxSize = SizeF.Empty;

        #endregion

        #region 属性

        public DuiSmoothingMode SmoothingMode
        {
            get
            {
                switch (this.graphics.SmoothingMode)
                {
                    case System.Drawing.Drawing2D.SmoothingMode.Default:
                        return DuiSmoothingMode.Default;
                    case System.Drawing.Drawing2D.SmoothingMode.AntiAlias | System.Drawing.Drawing2D.SmoothingMode.HighQuality:
                        return DuiSmoothingMode.AntiAlias;
                }
                return DuiSmoothingMode.Default;
            }
            set
            {
                switch (value)
                {
                    case DuiSmoothingMode.Default:
                        this.graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.Default;
                        break;
                    case DuiSmoothingMode.AntiAlias:
                        this.graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                        break;
                }
            }
        }
        public DuiTextRenderingHint TextRenderingHint
        {
            get
            {
                switch (this.graphics.TextRenderingHint)
                {
                    case System.Drawing.Text.TextRenderingHint.SystemDefault:
                        return DuiTextRenderingHint.Default;
                    case System.Drawing.Text.TextRenderingHint.AntiAlias:
                        return DuiTextRenderingHint.AntiAlias;
                }
                return DuiTextRenderingHint.Default;
            }
            set
            {
                switch (value)
                {
                    case DuiTextRenderingHint.Default:
                        this.graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
                        break;
                    case DuiTextRenderingHint.AntiAlias:
                        this.graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
                        break;
                }
            }
        }
        public DuiMatrix Transform
        {
            get
            {
                return this.graphics.Transform;
            }
            set
            {
                this.graphics.Transform = value;
            }
        }
        public float DpiX { get { return this.graphics.DpiX; } }
        public float DpiY { get { return this.graphics.DpiY; } }
        public Region Clip
        {
            get { return this.clip; }
            set { this.clip = value; }
        }
        public RectangleF ClipBounds
        {
            get { return this.clip == null ? RectangleF.Empty: this.clip.GetBounds(this.graphics); }
        }
        #endregion
        #region 构造函数
        public DuiGraphics_GDIP(IntPtr handle)
        {
            this.graphics = Graphics.FromHwnd(handle);
            //this.maxSize = Control.FromHandle(handle).Size;
        }
        public DuiGraphics_GDIP(Graphics graphics)
        {
            this.graphics = graphics;
            //this.maxSize = Control.FromHandle(handle).Size;
        }
        #endregion
        #region 函数
        public DuiGraphicsState Save()
        {
            return DxConvert.ToDUIGraphicsState(this.graphics.Save());
        }
        public void Restore(DuiGraphicsState graphicsState)
        {
            this.graphics.Restore(graphicsState);
        }
        public void BeginDraw(Region r)
        {
            this.Clip = r;
            RectangleF clipBounds = this.ClipBounds;
            this.PushLayer(clipBounds.X, clipBounds.Y, clipBounds.Width, clipBounds.Height);
        }
        public void Clear(Color color)
        {
            this.graphics.Clear(color);
        }
        public void EndDraw()
        {
            this.PopLayer(false);
            this.ResetTransform();
        }
        public void ResetTransform()
        {
            this.graphics.ResetTransform();
        }
        public void Resize(SizeF size)
        {

        }
        #endregion
        #region RoundedRectangle
        public void DrawRoundedRectangle(DuiPen pen, float x, float y, float width, float height, float radius)
        {
            if (width <= 0 || height <= 0) { return; }
            this.graphics.DrawPath(pen, GdiTools.GetRoundRectangleF(new RectangleF(x, y, width, height), radius));
        }
        public void FillRoundedRectangle(DuiBrush brush, float x, float y, float width, float height, float radius)
        {
            if (width <= 0 || height <= 0) { return; }
            this.graphics.FillPath(brush, GdiTools.GetRoundRectangleF(new RectangleF(x, y, width, height), radius));
        }
        #endregion
        #region Rectangle
        public void DrawRectangle(DuiPen pen, float x, float y, float width, float height)
        {
            this.graphics.DrawRectangle(pen, x, y, width, height);
        }
        public void FillRectangle(DuiBrush brush, float x, float y, float width, float height)
        {
            this.graphics.FillRectangle(brush, x, y, width, height);
        }
        #endregion
        #region Ellipse
        public void DrawEllipse(DuiPen pen, float x, float y, float width, float height)
        {
            this.graphics.DrawEllipse(pen, x, y, width, height);
        }
        public void FillEllipse(DuiBrush brush, float x, float y, float width, float height)
        {
            this.graphics.FillEllipse(brush, x, y, width, height);
        }
        #endregion
        #region Polygon
        public void DrawPolygon(DuiPen pen, PointF[] points)
        {
            this.graphics.DrawPolygon(pen, points);
        }
        public void FillPolygon(DuiBrush brush, PointF[] points)
        {
            this.graphics.FillPolygon(brush, points);
        }
        #endregion
        #region Region
        public void FillRegion(DuiBrush brush, DuiRegion region)
        {
            this.graphics.FillRegion(brush, region);
        }
        #endregion
        #region Line
        public void DrawLine(DuiPen pen, float x1, float y1, float x2, float y2)
        {
            this.graphics.DrawLine(pen, x1, y1, x2, y2);
        }
        #endregion
        #region Bezier
        public void DrawBezier(DuiPen pen, float x1, float y1, float x2, float y2, float x3, float y3, float x4, float y4)
        {
            this.graphics.DrawBezier(pen, x1, y1, x2, y2, x3, y3, x4, y4);
        }
        #endregion
        #region String
        public SizeF MeasureString(string text, DuiFont font, float width, float height)
        {
            return this.graphics.MeasureString(text, font, new SizeF(width, height));
        }
        public void DrawString(string s, DuiFont font, DuiBrush brush, RectangleF layoutRectangle, StringFormat format)
        {
            this.graphics.DrawString(s, font, brush, layoutRectangle, format);
        }
        #endregion
        #region Image
        public void DrawImage(DuiImage image, RectangleF destRect, RectangleF srcRect, GraphicsUnit srcUnit, float opacity)
        {
            ColorMatrix clrMatrix = new ColorMatrix(new float[][] { new float[] { 1, 0, 0, 0, 0 }, new float[] { 0, 1, 0, 0, 0 }, new float[] { 0, 0, 1, 0, 0 }, new float[] { 0, 0, 0, (float)opacity, 0 }, new float[] { 0, 0, 0, 0, 1 } });
            ImageAttributes imgAttributes = new ImageAttributes();
            imgAttributes.SetColorMatrix(clrMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);//设置图像的颜色属性
            this.graphics.DrawImage(image, Rectangle.Ceiling(destRect), srcRect.X, srcRect.Y, srcRect.Width, srcRect.Height, GraphicsUnit.Pixel, imgAttributes);
            //this.graphics.DrawImage(image, destRect, srcRect, GraphicsUnit.Pixel);
        }
        public void DrawImage(DuiImage image, PointF[] destTriangle, PointF[] srcTriangle, GraphicsUnit srcUnit, float opacity)
        {
            ColorMatrix clrMatrix = new ColorMatrix(new float[][] { new float[] { 1, 0, 0, 0, 0 }, new float[] { 0, 1, 0, 0, 0 }, new float[] { 0, 0, 1, 0, 0 }, new float[] { 0, 0, 0, (float)opacity, 0 }, new float[] { 0, 0, 0, 0, 1 } });
            ImageAttributes imgAttributes = new ImageAttributes();
            imgAttributes.SetColorMatrix(clrMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);//设置图像的颜色属性
            using (TextureBrush tb = new TextureBrush(image, new Rectangle(0, 0, image.Width, image.Height), imgAttributes))
            {
                tb.WrapMode = WrapMode.Clamp;
                tb.Transform = MatrixTools.ThreePointsAffine(srcTriangle, destTriangle);
                this.graphics.FillPolygon(tb, destTriangle);
            }
        }
        public void DrawImage(DuiImage image, PointF[] polygon, GraphicsUnit srcUnit, float opacity)
        {
            ColorMatrix clrMatrix = new ColorMatrix(new float[][] { new float[] { 1, 0, 0, 0, 0 }, new float[] { 0, 1, 0, 0, 0 }, new float[] { 0, 0, 1, 0, 0 }, new float[] { 0, 0, 0, (float)opacity, 0 }, new float[] { 0, 0, 0, 0, 1 } });
            ImageAttributes imgAttributes = new ImageAttributes();
            imgAttributes.SetColorMatrix(clrMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);//设置图像的颜色属性
            using (TextureBrush tb = new TextureBrush(image, new Rectangle(0, 0, image.Width, image.Height), imgAttributes))
            {
                tb.WrapMode = WrapMode.Clamp;
                this.graphics.FillPolygon(tb, polygon);
            }
        }
        #endregion
        #region Transform
        public void TranslateTransform(float dx, float dy)
        {
            this.graphics.TranslateTransform(dx, dy);
        }
        public void ScaleTransform(float sx, float sy)
        {
            this.graphics.ScaleTransform(sx, sy);
        }
        public void RotateTransform(float angle)
        {
            this.graphics.RotateTransform(angle);
        }
        public void SkewTransform(float sx, float sy)
        {
            float shearX = (float)(1 / Math.Tan(Math.PI / 180 * (90 - sy / Math.PI * 180)));
            float shearY = (float)(1 / Math.Tan(Math.PI / 180 * (90 - sx / Math.PI * 180)));
            Matrix m = this.graphics.Transform;
            m.Shear(shearX, shearY);
            this.graphics.Transform = m;
        }
        #endregion
        #region Layer
        RectangleF lastLayerBounds = RectangleF.Empty;
        public void PushLayer(float x, float y, float width, float height)
        {
            if (width == 0 || height == 0) { this.layerStacks.Push(null); return; }
            RectangleF r = new RectangleF(x, y, width, height);
            r.Intersect(this.ClipBounds);
            Layer layer = null;
            //if (r == lastLayerBounds)
            //{
            //    layer = this.layerStacks.Pop();
            //    this.layerStacks.Push(layer);
            //}
            //else
            {
                layer = new Layer(r, this.graphics);
            }
            //Layer layer = new Layer(r, this.graphics);
            this.layerStacks.Push(layer);
            this.graphics = layer.Graphics;
            lastLayerBounds = r;
        }

        public void PopLayer()
        {
            PopLayer(true);
        }
        private void PopLayer(bool isGdip)
        {
            Layer layer = this.layerStacks.Pop();
            if (layer == null) { return; }
            this.graphics = layer.BaseGraphics;
            if (isGdip)
            {
                layer.DrawGDIP();
            }
            else
            {
                layer.DrawGDI();
            }
            layer.Dispose();
        }
        /// <summary> GDI+图层对象
        /// </summary>
        private class Layer : IDisposable
        {
            private Bitmap bitmap = null;
            private Graphics graphics = null;
            private Graphics baseGraphics = null;
            private RectangleF bounds = RectangleF.Empty;
            /// <summary> 图层区域
            /// </summary>
            public RectangleF Bounds
            {
                get { return bounds; }
            }
            public Graphics BaseGraphics
            {
                get { return baseGraphics; }
            }
            public Graphics Graphics
            {
                get { return graphics; }
            }
            public Layer(float width, float height, Graphics g)
                : this(new RectangleF(0, 0, width, height), g)
            {

            }
            public Layer(float x, float y, float width, float height, Graphics g)
                : this(new RectangleF(x, y, width, height), g)
            {

            }
            public Layer(RectangleF rect, Graphics g)
            {
                this.bounds = rect;
                Size size = Size.Ceiling(rect.Size);
                bitmap = new Bitmap(size.Width, size.Height);
                graphics = Graphics.FromImage(bitmap);
                graphics.TranslateTransform(-this.Bounds.X, -this.Bounds.Y);
                baseGraphics = g;
            }
            public void DrawGDIP()
            {
                baseGraphics.DrawImage(bitmap, this.bounds, new RectangleF(0, 0, this.bounds.Width, this.bounds.Height), GraphicsUnit.Pixel);
            }
            public void DrawGDI()
            {
                IntPtr hdcDst = baseGraphics.GetHdc();
                Rectangle bounds = Rectangle.Ceiling(this.bounds);
                using (ImageDc imageDc = new ImageDc(bounds.Width, bounds.Height))
                using (Graphics gDc = Graphics.FromHdc(imageDc.Hdc))
                {
                    gDc.DrawImage(bitmap, new RectangleF(0, 0, bounds.Width, bounds.Height));
                    Win32.Struct.BLENDFUNCTION bf = new Win32.Struct.BLENDFUNCTION(Win32.AC.AC_SRC_OVER, 0x0, 255, Win32.AC.AC_SRC_OVER);
                    Win32.NativeMethods.AlphaBlend(hdcDst, bounds.X, bounds.Y, bounds.Width, bounds.Height, imageDc.Hdc, 0, 0, bounds.Width, bounds.Height, bf);
                    baseGraphics.ReleaseHdc(hdcDst);
                }
            }
            public void Dispose()
            {
                if (bitmap != null)
                {
                    bitmap.Dispose();
                }
                if (graphics != null)
                {
                    graphics.Dispose();
                }
            }
        }
        #endregion
        #region IDisposable
        public void Dispose()
        {
            this.graphics.Dispose();
        }
        #endregion
        public override bool Equals(object obj)
        {
            DuiGraphics_GDIP dUIGraphics_GDIP = obj as DuiGraphics_GDIP;
            if (dUIGraphics_GDIP == null)
            {
                return false;
            }
            else
            {
                return this.graphics.Equals(dUIGraphics_GDIP.graphics);
            }
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
