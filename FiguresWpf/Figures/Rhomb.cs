using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows;

namespace FiguresWpf.Figures
{
    public class Rhomb : Figure
    {
        public Rhomb(double centerX, double centerY, double diagonalHorizontal, double diagonalVertical, Brush strokeBrush)
            : base(centerX, centerY, strokeBrush)
        {
            DiagonalHorizontal = diagonalHorizontal;
            DiagonalVertical = diagonalVertical;
        }

        public double DiagonalHorizontal { get; set; }
        public double DiagonalVertical { get; set; }

        private Polygon _poly;

        public override void DrawBlack(Canvas canvas)
        {
            if (_poly == null)
            {
                _poly = new Polygon
                {
                    Stroke = StrokeBrush,
                    StrokeThickness = 2,
                    Fill = Brushes.Transparent,
                    StrokeLineJoin = PenLineJoin.Round
                };
            }

            double dx = DiagonalHorizontal / 2.0;
            double dy = DiagonalVertical / 2.0;

            _poly.Points = new PointCollection
            {
                new Point(CenterX - dx, CenterY),
                new Point(CenterX, CenterY - dy),
                new Point(CenterX + dx, CenterY),
                new Point(CenterX, CenterY + dy)
            };

            _poly.Stroke = StrokeBrush;
            _poly.Fill = Brushes.Transparent;

            EnsureOnCanvas(_poly, canvas);
        }

        public override void HideDrawingBackGround(Canvas canvas)
        {
            if (_poly == null) return;
            var bg = GetBackgroundBrush(canvas);
            _poly.Stroke = bg;
            _poly.Fill = bg;
        }
        protected override (double HalfWidth, double HalfHeight) GetHalfSize()
        {
            return (DiagonalHorizontal / 2.0, DiagonalVertical / 2.0);
        }
    }
}
