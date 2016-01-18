using onetruejones.Domain;

namespace onetruejones.FractalRenderer
{
    public interface IEscapeCalculator
    {
        int Iterations(PointD start, int maximumIterations);
    }
}