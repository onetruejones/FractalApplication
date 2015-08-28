using System.Drawing;
using FractalRenderer.Tests.Contexts;
using onetruejones.FractalRenderer;

namespace FractalRenderer.Tests.Steps
{
    using FluentAssertions;
    using onetruejones.Domain;
    using TechTalk.SpecFlow;

    [Binding]
    public class BitmapRendererSteps : Steps
    {
        private readonly BitmapRendererContext context;

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
            context.ColourTable = new ColourTable(colourTableSteps);
        }

        [Given(@"a start color of (.*), (.*), (.*) and an end color of (.*), (.*), (.*)")]
        public void GivenAStartColorOfAndAnEndColorOf(int startRed, int startGreen, int startBlue, int endRed, int endGreen, int endBlue)
        {
            context.ColourTable.StartColor = Color.FromArgb(startRed, startGreen, startBlue);
            context.ColourTable.EndColor = Color.FromArgb(endRed, endGreen, endBlue);
            context.ColourTable.SetupColourTable();
        }

        [Given(@"a calculated grid of width (.*) and height (.*)")]
        public void GivenACalculatedGridOfWidthAndHeight(int width, int height)
        {
            context.CalculatedGrid = new CalculatedGrid(width, height);
        }

        [Given(@"the calculated grid has a value of (.*) in position (.*), (.*)")]
        public void GivenTheCalculatedGridHasAValueOfInPosition(int gridValue, int x, int y)
        {
            context.CalculatedGrid[x, y] = gridValue;
        }

        [When(@"I render the bitmap from the grid data")]
        public void WhenIRenderTheBitmapFromTheGridData()
        {
            context.BitmapRenderer = new BitmapRenderer();
            context.BitmapRenderer.Render(context.Bitmap, context.CalculatedGrid, context.ColourTable);
        }

        [Then(@"the bitmap pixel at (.*), (.*) has the colour at position (.*) in the colour table")]
        public void ThenTheBitmapPixelAtHasTheColourAtPositionInTheColourTable(int x, int y, int colourIndex)
        {
            context.Bitmap.GetPixel(x, y).Should().Be(context.ColourTable[colourIndex]);
        }
    }
}