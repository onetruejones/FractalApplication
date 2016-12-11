using System.Collections.Generic;
using System.Drawing;
using onetruejones.Domain;

namespace onetruejones.FractalRenderer.Model
{
    public interface IFractalModel
    {
        List<int> Iterate(List<PointD> inputList, int maxIterations);
    }
}