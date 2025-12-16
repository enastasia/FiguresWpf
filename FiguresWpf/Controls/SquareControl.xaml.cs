using System.Windows;
using FiguresWpf.Figures;

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
            return new Square(centerX, centerY, side);
        }

        private void CreateBtn_Click(object sender, RoutedEventArgs e)
        {
            RaiseFigureCreated(CreateFigure(140, 180));
        }

        private void MoveBtn_Click(object sender, RoutedEventArgs e)
        {
            int steps = ParseInt(StepsBox.Text, 80);
            double dx = ParseDouble(DxBox.Text, 2);
            RaiseMoveRequested(steps, dx);
        }
    }
}
