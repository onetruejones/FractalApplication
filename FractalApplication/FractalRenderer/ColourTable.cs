namespace onetruejones.FractalRenderer
{
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using onetruejones.Domain;

    public class ColourTable
    {
        private readonly int steps;
        private readonly List<Color> colorList;
        public Color StartColor { get; set; }
        public Color EndColor { get; set; }

        public ColourTable(int steps)
        {
            this.steps = steps;
            colorList = new List<Color>();
        }

        public void SetupColourTable()
        {
            var redRange = Maths.IntRange(steps, StartColor.R, EndColor.R).ToArray();
            var greenRange = Maths.IntRange(steps, StartColor.R, EndColor.G).ToArray();
            var blueRange = Maths.IntRange(steps, StartColor.R, EndColor.B).ToArray();
            var i = 0;
            foreach (var red in redRange)
            {
                colorList.Add(Color.FromArgb(redRange[i], blueRange[i], greenRange[i]));
                i++;
            }
        }
    }
}