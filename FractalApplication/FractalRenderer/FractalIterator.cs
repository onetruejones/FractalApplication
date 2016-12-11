namespace onetruejones.FractalRenderer
{
    using Domain;

    public class FractalIterator : IIterator
    {
        private readonly FractalPlane fractalPlane;
        private readonly int maximumIterations;
        private readonly IEscapeCalculator escapeCalculator;
        private readonly CalculatedGrid calculatedGrid;

        public FractalIterator(FractalPlane fractalPlane, int maximumIterations, IEscapeCalculator escapeCalculator, CalculatedGrid calculatedGrid)
        {
            this.fractalPlane = fractalPlane;
            this.maximumIterations = maximumIterations;
            this.escapeCalculator = escapeCalculator;
            this.calculatedGrid = calculatedGrid;
        }

        public CalculatedGrid IterateFractalPlane()
        {
            for (var x = 0; x < fractalPlane.Width; x++)
            {
                for (var y = 0; y < fractalPlane.Height; y++)
                {
                    calculatedGrid[x, y] = escapeCalculator.Iterations(fractalPlane[x, y], maximumIterations);
                }
            }

            return calculatedGrid;
        }
    }
}