using System.Windows;
using FiguresWpf.Figures;

namespace FiguresWpf.Controls
{
    public partial class RhombControl : FigureControlBase
    {
        public RhombControl()
        {
            InitializeComponent();
        }

        public override string Title => "Rhomb";

        public override Figure CreateFigure(double centerX, double centerY)
        {
            double dh = ParseDouble(DHBox.Text, 160);
            double dv = ParseDouble(DVBox.Text, 100);
            if (dh <= 0) dh = 160;
            if (dv <= 0) dv = 100;
            return new Rhomb(centerX, centerY, dh, dv);
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
