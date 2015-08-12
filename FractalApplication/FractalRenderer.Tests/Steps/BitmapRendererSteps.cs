using System.Drawing;
using FractalRenderer.Tests.Contexts;
using onetruejones.FractalRenderer;

namespace FractalRenderer.Tests.Steps
{
    using TechTalk.SpecFlow;

    [Binding]
    public class BitmapRendererSteps : Steps
    {
        private BitmapRendererContext context;

        public BitmapRendererSteps(BitmapRendererContext context)
        {
            this.context = context;
        }

        [Given(@"I have a bitmap of width (.*) and height (.*)")]
        public void GivenIHaveABitmapOfWidthAndHeight(int width, int height)
        {
            context.Bitmap = new Bitmap(width, height);
        }

        [Given(@"a colour table of (.*) steps")]
        public void GivenAColourTableOfSteps(int colourTableSteps)
        {
            context.ColourTable = new ColourTable {Steps = colourTableSteps};
        }
    }
}