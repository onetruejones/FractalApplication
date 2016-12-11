using System.Collections.Generic;

namespace onetruejones.FractalRenderer
{
    using System.Drawing;
    using Domain;

    public interface IRenderer
    {
        void Render(Bitmap bitmap, CalculatedGrid calculatedGrid, ColourTable colourTable, int maximumIterations);
        void Render(Bitmap bitmap, List<int> data, ColourTable colourTable, int maximumIterations);
    }
}