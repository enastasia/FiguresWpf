using System.Windows;
using FiguresWpf.Figures;
using System.Windows.Media;

namespace FiguresWpf.Controls
{
    public partial class SquareControl : FigureControlBase
    {
        public SquareControl()
        {
            InitializeComponent();
        }

        public override string Title => "Square";

        public override Figure CreateFigure(double centerX, double centerY)
        {
            double side = ParseDouble(SideBox.Text, 120);
            if (side <= 0) side = 120;
            var stroke = ParseBrush(ColorBox.Text, Brushes.White);
            return new Square(centerX, centerY, side, stroke);
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
