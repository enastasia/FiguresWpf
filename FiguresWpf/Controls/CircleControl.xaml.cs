using System.Windows;
using FiguresWpf.Figures;

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
            return new Circle(centerX, centerY, r);
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
