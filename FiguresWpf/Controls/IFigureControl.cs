using FiguresWpf.Figures;

namespace FiguresWpf.Controls
{
    public interface IFigureControl
    {
        Figure CreateFigure(double centerX, double centerY);
        string Title { get; }
    }
}
