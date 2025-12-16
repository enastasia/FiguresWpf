using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace FiguresWpf.Figures
{
    public abstract class Figure
    {
        protected Figure(double centerX, double centerY)
        {
            CenterX = centerX;
            CenterY = centerY;
        }

        protected double CenterX;
        protected double CenterY;

        public double X => CenterX;
        public double Y => CenterY;

        public abstract void DrawBlack(Canvas canvas);
        public abstract void HideDrawingBackGround(Canvas canvas);

        /// <summary>
        /// Movement is implemented ONLY here (polymorphism works via DrawBlack/HideDrawingBackGround).
        /// </summary>
        public void MoveRight(Canvas canvas, int steps = 50, double dx = 2)
        {
            // Do not block the UI thread.
            _ = Task.Run(() =>
            {
                for (int i = 0; i < steps; i++)
                {
                    Application.Current.Dispatcher.Invoke(() => DrawBlack(canvas));
                    Thread.Sleep(100);
                    Application.Current.Dispatcher.Invoke(() => HideDrawingBackGround(canvas));

                    CenterX += dx;
                }

                // Final draw, so the figure remains visible at the last position.
                Application.Current.Dispatcher.Invoke(() => DrawBlack(canvas));
            });
        }

        protected static void EnsureOnCanvas(UIElement element, Canvas canvas)
        {
            if (element == null) return;
            if (!canvas.Children.Contains(element))
            {
                canvas.Children.Add(element);
            }
        }

        protected static System.Windows.Media.Brush GetBackgroundBrush(Canvas canvas)
        {
            // If background is not explicitly set, fall back to Window background.
            return canvas.Background
                   ?? (Application.Current?.MainWindow?.Background)
                   ?? System.Windows.Media.Brushes.White;
        }
    }
}
