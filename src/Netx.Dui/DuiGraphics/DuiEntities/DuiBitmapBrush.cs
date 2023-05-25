﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Netx.Dui
{
    public class DuiBitmapBrush : DuiBrush
    {
        private DuiImage image = null;
        private DuiImage lastImage = null;
        private DuiExtendMode lastDUIExtendMode = DuiExtendMode.Wrap;
        private DuiExtendMode dUIExtendMode = DuiExtendMode.Wrap;
        private float lastOpacity = 1F;
        private float opacity = 1F;
        private DuiMatrix matrix = new DuiMatrix();
        public DuiBitmapBrush(DuiImage image, DuiExtendMode dUIExtendMode = DuiExtendMode.Wrap, float opacity = 1F)
        {
            this.image = image;
            this.dUIExtendMode = dUIExtendMode;
            this.opacity = opacity;
        }
        public DuiBitmapBrush(Image image, DuiExtendMode dUIExtendMode = DuiExtendMode.Wrap, float opacity = 1F)
            : this(DuiImage.FromImage(image), dUIExtendMode, opacity)
        {
        }
        protected override SharpDX.Direct2D1.Brush DxBrush
        {
            get
            {
                if (dxBrush == null || isNewRenderTarget
                    || this.lastImage != this.image
                    || this.lastDUIExtendMode != this.dUIExtendMode
                    || this.lastOpacity != this.opacity)
                {
                    if (this.RenderTarget != null)
                    {
                        this.lastImage = this.image;
                        this.lastDUIExtendMode = this.dUIExtendMode;
                        this.lastOpacity = this.opacity;
                        if (dxBrush != null)
                        {
                            dxBrush.Dispose();
                            dxBrush = null;
                        }
                        dxBrush = DxConvert.ToBitmapBrush(this.RenderTarget, this);
                        isNewRenderTarget = false;
                    }
                }
                return dxBrush;
            }
        }
        public DuiMatrix Transform
        {
            get
            {
                return this.matrix.Clone();
            }
            set
            {
                this.matrix = value;
                this.DxBrush.Transform = this.matrix;
            }
        }
        public DuiImage Image
        {
            get { return this.image; }
            set { this.image = value; }
        }
        public DuiExtendMode ExtendMode
        {
            get { return dUIExtendMode; }
            set { dUIExtendMode = value; }
        }
        public float Opacity
        {
            get { return opacity; }
            set { opacity = value; }
        }
    }
}
