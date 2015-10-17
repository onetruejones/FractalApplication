using onetruejones.Domain;

namespace onetruejones.FractalRenderer
{
    public class TestIterator : IIterator
    {
        private readonly FractalPlane fractalPlane;
        private readonly int maximumIterations;

        public TestIterator(FractalPlane fractalPlane, int maximumIterations)
        {
            this.fractalPlane = fractalPlane;
            this.maximumIterations = maximumIterations;
        }

        public CalculatedGrid IterateFractalPlane()
        {
            var calculatedGrid = new CalculatedGrid(fractalPlane.Width, fractalPlane.Height);

            for (int x = 0; x < fractalPlane.Width; x++)
            {
                for (int y = 0; y < fractalPlane.Height; y++)
                {
                    calculatedGrid[x, y] = maximumIterations -1;
                }
            }

            return calculatedGrid;
        }
    }
}