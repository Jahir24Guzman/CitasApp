using SkiaSharp;
using SkiaSharp.Views.Forms;
using System;
using System.IO;
using Xamarin.Forms;

namespace merindo.Helpers
{
    public class SvgIcon : SKCanvasView
    {
        public static readonly BindableProperty SvgPathProperty = BindableProperty.Create(
            nameof(SvgPath),
            typeof(string),
            typeof(SvgIcon),
            default(string),
            propertyChanged: RedrawCanvas);

        public string SvgPath
        {
            get => (string)GetValue(SvgPathProperty);
            set => SetValue(SvgPathProperty, value);
        }

        private static void RedrawCanvas(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (SvgIcon)bindable;
            control.InvalidateSurface();
        }

        protected override void OnPaintSurface(SKPaintSurfaceEventArgs e)
        {
            base.OnPaintSurface(e);

            var canvas = e.Surface.Canvas;
            canvas.Clear();

            if (string.IsNullOrEmpty(SvgPath))
                return;

            var assembly = GetType().Assembly;
            using (var stream = assembly.GetManifestResourceStream(SvgPath))
            {
                if (stream == null)
                    return;

                using (var reader = new StreamReader(stream))
                {
                    var svg = new SkiaSharp.Extended.Svg.SKSvg();
                    svg.Load(reader.BaseStream);

                    var canvasSize = e.Info.Size;
                    var svgBounds = svg.ViewBox;

                    var xRatio = canvasSize.Width / svgBounds.Width;
                    var yRatio = canvasSize.Height / svgBounds.Height;
                    var ratio = Math.Min(xRatio, yRatio);

                    var matrix = SKMatrix.CreateScale(ratio, ratio);
                    canvas.DrawPicture(svg.Picture, ref matrix);
                }
            }
        }
    }
}