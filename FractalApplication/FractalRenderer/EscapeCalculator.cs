using onetruejones.Domain;

namespace onetruejones.FractalRenderer
{
    public class EscapeCalculator : IEscapeCalculator
    {
        public int Iterations(PointD start, int maximumIterations)
        {
            var x0 = start.X;
            var y0 = start.Y;
            var x = 0.0D;
            var y = 0.0D;
            var iteration = 0;

            while ((x * x + y * y < 4) && (iteration < maximumIterations))
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