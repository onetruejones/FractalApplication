namespace onetruejones.Domain
{
    using System.Linq;

    public class FractalPlane
    {
        private readonly PointD[,] doubleArray;

        public FractalPlane(int width, int height, PointD topLeft, PointD bottomRight)
        {
            doubleArray = new PointD[width, height];
            InitializeArray(topLeft, bottomRight);
        }

        public PointD this[int x, int y] => doubleArray[x, y];

        public int Width => doubleArray.GetUpperBound(0) + 1;

        public int Height => doubleArray.GetUpperBound(1) + 1;

        private void InitializeArray(PointD topLeft, PointD bottomRight)
        {
            var width = doubleArray.GetUpperBound(0) + 1;
            var xRange = Maths.DoubleRange(width, topLeft.X, bottomRight.X);
            var height = doubleArray.GetUpperBound(1) + 1;
            var yRange = Maths.DoubleRange(height, topLeft.Y, bottomRight.Y);

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    doubleArray[x, y] = new PointD(xRange.ElementAt(x), yRange.ElementAt(y));
                }
            }
        }
    }
}