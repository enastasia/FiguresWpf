using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace FiguresWpf.Figures
{
    public abstract class Figure
    {
        protected Figure(double centerX, double centerY, Brush strokeBrush)
        {
            CenterX = centerX;
            CenterY = centerY;
            StrokeBrush = strokeBrush ?? Brushes.White;
        }

        protected double CenterX;
        protected double CenterY;
        
        protected Brush StrokeBrush { get; }

        public double X => CenterX;
        public double Y => CenterY;

        public abstract void DrawBlack(Canvas canvas);
        public abstract void HideDrawingBackGround(Canvas canvas);

        
        public void Move(Canvas canvas, int steps = 50, double dx = 0, double dy = 0)
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
                    CenterY += dy;
                }

                // Final draw, so the figure remains visible at the last position.
                Application.Current.Dispatcher.Invoke(() => DrawBlack(canvas));
            });
        }

        public void MoveRight(Canvas canvas, int steps = 50, double dx = 2) => Move(canvas, steps, dx, 0);

        public void MoveLeft(Canvas canvas, int steps = 50, double dx = 2) => Move(canvas, steps, -dx, 0);

        public void MoveUp(Canvas canvas, int steps = 50, double dy = 2) => Move(canvas, steps, 0, -dy);

        public void MoveDown(Canvas canvas, int steps = 50, double dy = 2) => Move(canvas, steps, 0, dy);
       
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
            
            return canvas.Background
                   ?? (Application.Current?.MainWindow?.Background)
                   ?? System.Windows.Media.Brushes.White;
        }
    }
}
