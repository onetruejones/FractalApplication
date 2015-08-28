namespace onetruejones.FractalRenderer
{
    using System.Drawing;
    using onetruejones.Domain;

    public class BitmapRenderer : IRenderer
    {
        public void Render(Bitmap bitmap, CalculatedGrid calculatedGrid, ColourTable colourTable)
        {
            for (int x = 0; x < calculatedGrid.Rows; x++)
            {
                for (int y = 0; y < calculatedGrid.Columns; y++)
                {
                    var color = colourTable[calculatedGrid[x, y]];
                    bitmap.SetPixel(x, y, color);
                }
            }
        }
    }
}
