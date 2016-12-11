using System.Drawing;
using onetruejones.Domain;

namespace onetruejones.FractalRenderer
{
    public interface IEscapeCalculator
    {
        int Iterations(PointD start, int maximumIterations);
        int Iterations(PointF start, int maximumIterations);
    }
}