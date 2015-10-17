using onetruejones.Domain;

namespace onetruejones.FractalRenderer
{
    public interface IIterator
    {
        CalculatedGrid IterateFractalPlane();
    }
}