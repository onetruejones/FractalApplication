namespace onetruejones.FractalRenderer
{
    using Domain;

    public class FractalIterator : IIterator
    {
        private readonly FractalPlane fractalPlane;
        private readonly int maximumIterations;

        public FractalIterator(FractalPlane fractalPlane, int maximumIterations)
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
                    calculatedGrid[x, y] = CalculateEscapeTime(fractalPlane[x, y]);
                }
            }

            return calculatedGrid;
        }

        private int CalculateEscapeTime(PointD pointD)
        {
            var x0 = pointD.X;
            var y0 = pointD.Y;
            var x = 0.0D;
            var y = 0.0D;
            var iteration = 0;

            while ((x*x + y*y < 4) && (iteration < maximumIterations))
            {
                var xtemp = x * x - y * y + x0;
                y = 2 * x * y + y0;
                x = xtemp;
                iteration++;
            }

            return iteration;
        }
    }
}