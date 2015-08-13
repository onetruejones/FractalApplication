namespace onetruejones.Domain
{
    public class CalculatedGrid
    {
        private readonly int width;
        private readonly int height;
        private int[,] iterationArray;

        public CalculatedGrid(int width, int height)
        {
            this.width = width;
            this.height = height;
            iterationArray = new int[this.width, this.height];
        }
    }
}