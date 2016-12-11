using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using onetruejones.Domain;

namespace onetruejones.FractalRenderer.Model
{
    public class FractalModel : IFractalModel
    {
        private readonly IEscapeCalculator calculator;

        public FractalModel(IEscapeCalculator calculator)
        {
            this.calculator = calculator;
        }

        public List<int> Iterate(List<PointD> inputList, int maxIterations)
        {
            var results = inputList.Select(pointF => calculator.Iterations(pointF, maxIterations)).ToList();
            return results;
        }
    }
}