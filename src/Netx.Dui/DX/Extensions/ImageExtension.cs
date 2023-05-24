using SharpDX.Direct2D1;
using SharpDX;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using DBitmap = SharpDX.Direct2D1.Bitmap;
using DPixelFormat = SharpDX.Direct2D1.PixelFormat;
using DFormat = SharpDX.DXGI.Format;
using Bitmap = System.Drawing.Bitmap;

namespace Netx.Dui
{
    public static class ImageExtension
    {
        /// <summary>
        /// ms位图转换未dx的bitmap
        /// </summary>
        /// <param name="bitmap"></param>
        /// <param name="renderTarget"></param>
        /// <returns></returns>
        public static DBitmap MSBitmapToDxBitmap(this Bitmap bitmap, RenderTarget renderTarget)
        {
            if (null == bitmap)
                return null;
            var sourceArea = new System.Drawing.Rectangle(0, 0, bitmap.Width, bitmap.Height);
            var bitmapProperties = new BitmapProperties(new DPixelFormat(DFormat.R8G8B8A8_UNorm, AlphaMode.Premultiplied));
            var size = new Size2(bitmap.Width, bitmap.Height);
            // Transform pixels from BGRA to RGBA
            int stride = bitmap.Width * sizeof(int);
            using (var tempStream = new DataStream(bitmap.Height * stride, true, true))
            {
                // Lock System.Drawing.Bitmap
                var bitmapData = bitmap.LockBits(sourceArea, ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
                // Convert all pixels 
                for (int y = 0; y < bitmap.Height; y++)
                {
                    int offset = bitmapData.Stride * y;
                    for (int x = 0; x < bitmap.Width; x++)
                    {
                        // Not optimized 
                        byte B = Marshal.ReadByte(bitmapData.Scan0, offset++);
                        byte G = Marshal.ReadByte(bitmapData.Scan0, offset++);
                        byte R = Marshal.ReadByte(bitmapData.Scan0, offset++);
                        byte A = Marshal.ReadByte(bitmapData.Scan0, offset++);
                        int rgba = R | (G << 8) | (B << 16) | (A << 24);
                        tempStream.Write(rgba);
                    }
                }
                bitmap.UnlockBits(bitmapData);
                tempStream.Position = 0;
                return new DBitmap(renderTarget, size, tempStream, stride, bitmapProperties);
            }

        }
    }
}
