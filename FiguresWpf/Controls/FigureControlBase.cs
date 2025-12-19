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
        
        protected static bool TryParseDouble(string text, out double value)
        {
            if (double.TryParse(text, NumberStyles.Float, CultureInfo.InvariantCulture, out value))
            {
                return !double.IsNaN(value) && !double.IsInfinity(value);
            }
            if (double.TryParse(text, NumberStyles.Float, CultureInfo.CurrentCulture, out value))
            {
                return !double.IsNaN(value) && !double.IsInfinity(value);
            }
            return false;
        }

        protected static int ParseInt(string text, int fallback)
        {
            return int.TryParse(text, out var v) ? v : fallback;
        }
        
        protected static bool TryParseInt(string text, out int value)
        {
            return int.TryParse(text, out value);
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
        
        protected static bool TryParseBrush(string text, out Brush brush)
        {
            brush = null;
            if (string.IsNullOrWhiteSpace(text)) return false;

            try
            {
                var color = (Color)ColorConverter.ConvertFromString(text.Trim());
                brush = new SolidColorBrush(color);
                return true;
            }
            catch
            {
                return false;
            }
        }
        protected void Info(string message)
        {
            MessageBox.Show(message, "Info", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
