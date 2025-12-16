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

        private void MoveBtn_Click(object sender, RoutedEventArgs e)
        {
            int steps = ParseInt(StepsBox.Text, 80);
            double dx = ParseDouble(DxBox.Text, 2);
            RaiseMoveRequested(steps, dx);
        }
    }
}
