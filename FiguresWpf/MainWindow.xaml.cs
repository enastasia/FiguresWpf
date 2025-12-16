using System.Windows;
using FiguresWpf.Controls;
using FiguresWpf.Figures;

namespace FiguresWpf
{
    public partial class MainWindow : Window
    {
        private Figure _active;

        public MainWindow()
        {
            InitializeComponent();

            Hook(CircleCtl);
            Hook(SquareCtl);
            Hook(RhombCtl);
        }

        private void Hook(FigureControlBase ctl)
        {
            ctl.FigureCreated += figure =>
            {
                _active = figure;
                _active.DrawBlack(DrawCanvas);
            };

            ctl.MoveRequested += (steps, dx) =>
            {
                if (_active == null)
                {
                    MessageBox.Show("Спочатку створіть фігуру...", "Нема фігури", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                _active.MoveRight(DrawCanvas, steps, dx);
            };
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            DrawCanvas.Children.Clear();
            _active = null;
        }
    }
}
