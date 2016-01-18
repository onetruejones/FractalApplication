namespace onetruejones.FractalRenderer
{
    using System.Drawing;
    using Domain;

    public class BitmapRenderer : IRenderer
    {
        public void Render(Bitmap bitmap, CalculatedGrid calculatedGrid, ColourTable colourTable, int maximumIterations)
        {
            for (int x = 0; x < calculatedGrid.Rows; x++)
            {
                for (int y = 0; y < calculatedGrid.Columns; y++)
                {
                    var i = calculatedGrid[x, y];
                    var color = i < maximumIterations ? colourTable[i] : Color.Black;
                    bitmap.SetPixel(x, y, color);
                }
            }
        }
    }
}
