using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows.Media;

namespace FiguresWpf.Figures
{
    public class Circle : Figure
    {
        public Circle(double centerX, double centerY, double radius)
            : base(centerX, centerY)
        {
            Radius = radius;
        }

        public double Radius { get; set; }

        private Ellipse _ellipse;

        public override void DrawBlack(Canvas canvas)
        {
            if (_ellipse == null)
            {
                _ellipse = new Ellipse
                {
                    Stroke = Brushes.Black,
                    StrokeThickness = 2,
                    Fill = Brushes.Transparent
                };
            }

            _ellipse.Width = Radius * 2;
            _ellipse.Height = Radius * 2;
            Canvas.SetLeft(_ellipse, CenterX - Radius);
            Canvas.SetTop(_ellipse, CenterY - Radius);

            _ellipse.Stroke = Brushes.Black;
            _ellipse.Fill = Brushes.Transparent;

            EnsureOnCanvas(_ellipse, canvas);
        }

        public override void HideDrawingBackGround(Canvas canvas)
        {
            if (_ellipse == null) return;
            var bg = GetBackgroundBrush(canvas);
            _ellipse.Stroke = bg;
            _ellipse.Fill = bg;
        }
    }
}
