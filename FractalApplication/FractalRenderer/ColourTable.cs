namespace onetruejones.FractalRenderer
{
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using onetruejones.Domain;

    public class ColourTable
    {
        public int Steps { get; private set; }
        private readonly List<Color> colorList;
        public Color StartColor { get; set; }
        public Color EndColor { get; set; }

        public ColourTable(int steps)
        {
            Steps = steps;
            colorList = new List<Color>();
        }

        public void SetupColourTable()
        {
            var redRange = Maths.IntRange(Steps, StartColor.R, EndColor.R).ToArray();
            var greenRange = Maths.IntRange(Steps, StartColor.R, EndColor.G).ToArray();
            var blueRange = Maths.IntRange(Steps, StartColor.R, EndColor.B).ToArray();
            for (var j = 0; j < Steps; j++)
            {
                colorList.Add(Color.FromArgb(redRange[j], blueRange[j], greenRange[j]));
            }
        }

        public Color this[int i]
        {
            get
            {
                return colorList[i];
            }
        }
    }
}