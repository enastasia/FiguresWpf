using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using FiguresWpf.Figures;

namespace FiguresWpf.Controls
{
    public abstract class FigureControlBase : UserControl, IFigureControl
    {
        public abstract string Title { get; }
        public abstract Figure CreateFigure(double centerX, double centerY);

        public event Action<Figure> FigureCreated;
        public event Action<int, double, double> MoveRequested;


        protected void RaiseFigureCreated(Figure figure) => FigureCreated?.Invoke(figure);
        protected void RaiseMoveRequested(int steps, double dx, double dy) => MoveRequested?.Invoke(steps, dx, dy);

        protected static double ParseDouble(string text, double fallback)
        {
            if (double.TryParse(text, NumberStyles.Float, CultureInfo.InvariantCulture, out var v)) return v;
            if (double.TryParse(text, NumberStyles.Float, CultureInfo.CurrentCulture, out v)) return v;
            return fallback;
        }

        protected static int ParseInt(string text, int fallback)
        {
            return int.TryParse(text, out var v) ? v : fallback;
        }
        protected static Brush ParseBrush(string text, Brush fallback)
        {
            if (string.IsNullOrWhiteSpace(text)) return fallback;

            try
            {
                var color = (Color)ColorConverter.ConvertFromString(text.Trim());
                return new SolidColorBrush(color);
            }
            catch
            {
                return fallback;
            }
        }
        protected void Info(string message)
        {
            MessageBox.Show(message, "Info", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
