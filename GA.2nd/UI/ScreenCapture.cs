using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Windows;
using System.IO;

namespace UI
{
    public static class ScreenCapture
    {
        public static BitmapFrame SaveToBmp(FrameworkElement visual)
        {
            var encoder = new BmpBitmapEncoder();
            return SaveUsingEncoder(visual, encoder);
        }

        public static BitmapFrame SaveToPng(FrameworkElement visual)
        {
            var encoder = new PngBitmapEncoder();
            return SaveUsingEncoder(visual, encoder);
        }

        public static BitmapFrame SaveToJpeg(FrameworkElement visual)
        {
            var encoder = new JpegBitmapEncoder();
             return SaveUsingEncoder(visual, encoder);
        }

        private static BitmapFrame SaveUsingEncoder(FrameworkElement visual, BitmapEncoder encoder)
        {
            RenderTargetBitmap bitmap = new RenderTargetBitmap((int)visual.ActualWidth, (int)visual.ActualHeight, 96, 96, PixelFormats.Pbgra32);
            Size visualSize = new Size(visual.ActualWidth, visual.ActualHeight);
            visual.Measure(visualSize);
            visual.Arrange(new Rect(visualSize));
            bitmap.Render(visual);
            BitmapFrame frame = BitmapFrame.Create(bitmap);
            encoder.Frames.Add(frame);

            return frame;
        }
    }
}
