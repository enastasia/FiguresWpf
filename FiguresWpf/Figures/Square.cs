using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows.Media;

namespace FiguresWpf.Figures
{
    public class Square : Figure
    {
        public Square(double centerX, double centerY, double side, Brush strokeBrush)
            : base(centerX, centerY, strokeBrush)
        {
            Side = side;
        }

        public double Side { get; set; }

        private Rectangle _rect;

        public override void DrawBlack(Canvas canvas)
        {
            if (_rect == null)
            {
                _rect = new Rectangle
                {
                    Stroke = StrokeBrush,
                    StrokeThickness = 2,
                    Fill = Brushes.Transparent,
                    RadiusX = 4,
                    RadiusY = 4
                };
            }

            _rect.Width = Side;
            _rect.Height = Side;

            Canvas.SetLeft(_rect, CenterX - Side / 2);
            Canvas.SetTop(_rect, CenterY - Side / 2);

              _rect.Stroke = StrokeBrush;
            _rect.Fill = Brushes.Transparent;

            EnsureOnCanvas(_rect, canvas);
        }

        public override void HideDrawingBackGround(Canvas canvas)
        {
            if (_rect == null) return;
            var bg = GetBackgroundBrush(canvas);
            _rect.Stroke = bg;
            _rect.Fill = bg;
        }
    }
}
