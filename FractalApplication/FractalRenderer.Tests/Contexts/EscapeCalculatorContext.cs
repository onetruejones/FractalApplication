using onetruejones.Domain;
using onetruejones.FractalRenderer;

namespace FractalRenderer.Tests.Contexts
{
    public class EscapeCalculatorContext
    {
        public int MaximumIterations { get; set; }
        public PointD StartingPoint { get; set; }
        public EscapeCalculator EscapeCalculator { get; set; }
        public int Iterations { get; set; }

        public EscapeCalculatorContext(EscapeCalculator escapeCalculator)
        {
            EscapeCalculator = escapeCalculator;
        }
    }
}