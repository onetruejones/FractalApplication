using System.Drawing;
using onetruejones.FractalRenderer;

namespace FractalRenderer.Tests.Contexts
{
    using onetruejones.Domain;

    public class BitmapRendererContext
    {
        public Bitmap Bitmap { get; set; }
        public ColourTable ColourTable { get; set; }
        public CalculatedGrid CalculatedGrid { get; set; }
    }
}