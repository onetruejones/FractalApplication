using System.Collections.Generic;
using System.Linq;

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

        public void Render(Bitmap bitmap, List<int> data, ColourTable colourTable, int maximumIterations)
        {
            var width = bitmap.Width;
            var height = bitmap.Height;

            var min = data.Min();
            var iterationRange = maximumIterations - min;

            var histogram = new int[maximumIterations];

            SetUpHistogram(data, maximumIterations, histogram);

            var total = Total(maximumIterations, histogram);


            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    var pixelIterations = data[x*height + y];

                    double hue = 0.0;

                    for (int i = 0; i < pixelIterations; i++)
                    {
                        hue += (double)histogram[i]/total;
                    }


//                    int weightedColourIndex = (int)(((double)(pixelIterations - min)/iterationRange)*256);
                    var weightedColourIndex = (int)(hue*1024);


                    var color = pixelIterations < maximumIterations ? colourTable[weightedColourIndex] : Color.Black;
                    bitmap.SetPixel(x, y, color);
                }
            }
        }

        private static int Total(int maximumIterations, int[] histogram)
        {
            var total = 0;
            for (var i = 0; i < maximumIterations; i++)
            {
                total += histogram[i];
            }
            return total;
        }

        private static void SetUpHistogram(List<int> data, int maximumIterations, int[] histogram)
        {
            foreach (var t in data)
            {
                if (t < maximumIterations)
                {
                    histogram[t] += 1;
                }
            }
        }
    }
}
