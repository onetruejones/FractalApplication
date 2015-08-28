namespace onetruejones.Domain
{
    using System;

    public class CalculatedGrid
    {
        private readonly int width;
        private readonly int height;
        private readonly int[,] iterationArray;

        public CalculatedGrid(int width, int height)
        {
            this.width = width;
            this.height = height;
            iterationArray = new int[this.width, this.height];
        }

        public int this[int x, int y]
        {
            set
            {
                iterationArray[x, y] = value;
            }
            get
            {
                return iterationArray[x, y];
            }
        }

        public int Rows
        {
            get
            {
                return iterationArray.GetUpperBound(0) + 1;
            }
        }

        public int Columns
        {
            get
            {
                return iterationArray.GetUpperBound(1) + 1;
            }
        }
    }
}