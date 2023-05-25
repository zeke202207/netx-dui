using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Netx.Dui
{
    internal interface IDuiGraphics : IDisposable
    {
        #region 属性

        DuiSmoothingMode SmoothingMode { get; set; }
        DuiTextRenderingHint TextRenderingHint { get; set; }
        DuiMatrix Transform { get; set; }
        float DpiX { get; }
        float DpiY { get; }
        RectangleF ClipBounds { get; }

        #endregion

        #region 函数

        DuiGraphicsState Save();
        void Restore(DuiGraphicsState graphicsState);
        void BeginDraw(Region r);
        void Clear(Color color);
        void EndDraw();
        void ResetTransform();
        void Resize(SizeF size);

        #endregion

        #region RoundedRectangle

        void DrawRoundedRectangle(DuiPen pen, float x, float y, float width, float height, float radius);
        void FillRoundedRectangle(DuiBrush brush, float x, float y, float width, float height, float radius);

        #endregion

        #region Rectangle

        void DrawRectangle(DuiPen pen, float x, float y, float width, float height);
        void FillRectangle(DuiBrush brush, float x, float y, float width, float height);

        #endregion

        #region Ellipse

        void DrawEllipse(DuiPen pen, float x, float y, float width, float height);
        void FillEllipse(DuiBrush brush, float x, float y, float width, float height);

        #endregion

        #region Polygon

        void DrawPolygon(DuiPen pen, PointF[] points);
        void FillPolygon(DuiBrush brush, PointF[] points);

        #endregion

        #region Region

        void FillRegion(DuiBrush brush, DuiRegion region);

        #endregion

        #region Line

        void DrawLine(DuiPen pen, float x1, float y1, float x2, float y2);

        #endregion

        #region Bezier

        void DrawBezier(DuiPen pen, float x1, float y1, float x2, float y2, float x3, float y3, float x4, float y4);

        #endregion

        #region String

        SizeF MeasureString(string text, DuiFont font, float width, float height);
        void DrawString(string s, DuiFont font, DuiBrush brush, RectangleF layoutRectangle, StringFormat format);

        #endregion

        #region Image

        void DrawImage(DuiImage image, RectangleF destRect, RectangleF srcRect, GraphicsUnit srcUnit, float opacity);
        void DrawImage(DuiImage image, PointF[] destTriangle, PointF[] srcTriangle, GraphicsUnit srcUnit, float opacity);
        void DrawImage(DuiImage image, PointF[] polygon, GraphicsUnit srcUnit, float opacity);

        #endregion

        #region Transform

        void TranslateTransform(float dx, float dy);
        void ScaleTransform(float sx, float sy);
        void RotateTransform(float angle);
        void SkewTransform(float sx, float sy);

        #endregion

        #region Layer

        void PushLayer(float x, float y, float width, float height);
        void PopLayer();

        #endregion
    }
}
