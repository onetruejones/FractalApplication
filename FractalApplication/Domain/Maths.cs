namespace onetruejones.Domain
{
    using System.Collections.Generic;
    using System.Linq;

    public class Maths
    {
        public static IEnumerable<double> DoubleRange(int steps, double min, double max)
        {
            return Enumerable.Range(0, steps).Select(i => min + (max - min) * ((double)i / (steps - 1)));
        }

        public static IEnumerable<int> IntRange(int steps, int min, int max)
        {
            var range = Enumerable.Range(0, steps);

            var enumerable = range.Select(i => (int)(min + (max - min) * ((double)i / (steps - 1))));

            return enumerable;
        }
    }
}