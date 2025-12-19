using System.Windows;
using FiguresWpf.Figures;
using System.Windows.Media;

namespace FiguresWpf.Controls
{
    public partial class CircleControl : FigureControlBase
    {
        public CircleControl()
        {
            InitializeComponent();
        }

        public override string Title => "Circle";

        public override Figure CreateFigure(double centerX, double centerY)
        {
            double r = ParseDouble(RadiusBox.Text, 60);
            if (r <= 0) r = 60;
            var stroke = ParseBrush(ColorBox.Text, Brushes.White);
            return new Circle(centerX, centerY, r, stroke);
        }

        private void CreateBtn_Click(object sender, RoutedEventArgs e)
        {
            RaiseFigureCreated(CreateFigure(140, 180));
        }

        private void MoveUp_Click(object sender, RoutedEventArgs e) => RequestMove(0, -1);

        private void MoveDown_Click(object sender, RoutedEventArgs e) => RequestMove(0, 1);

        private void MoveLeft_Click(object sender, RoutedEventArgs e) => RequestMove(-1, 0);

        private void MoveRight_Click(object sender, RoutedEventArgs e) => RequestMove(1, 0);

        private void RequestMove(int directionX, int directionY)
        {
            int steps = ParseInt(StepsBox.Text, 80);
            double speed = ParseDouble(DxBox.Text, 2);
            RaiseMoveRequested(steps, speed * directionX, speed * directionY);
        }
    }
}
