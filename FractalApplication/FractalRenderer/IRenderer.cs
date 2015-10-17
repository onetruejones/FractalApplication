namespace onetruejones.FractalRenderer
{
    using System.Drawing;
    using onetruejones.Domain;

    public interface IRenderer
    {
        void Render(Bitmap bitmap, CalculatedGrid calculatedGrid, ColourTable colourTable, int maximumIterations);
    }
}