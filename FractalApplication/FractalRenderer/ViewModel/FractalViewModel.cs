using System.Collections.Generic;
using System.Drawing;
using System.Net.Mime;
using onetruejones.Domain;
using onetruejones.FractalRenderer.Model;
using System.Windows.Threading;
using System.Windows;

namespace onetruejones.FractalRenderer.ViewModel
{
    public class FractalViewModel
    {
        public int PixelWidth { get; set; }
        public int PixelHeight { get; set; }
        public int MaxIterations { get; set; }
        public PointD TopLeftCorner { get; set; }

        public PointD Origin
        {
            get { return origin; }
            set
            {
                origin = value;
                TopLeftCorner = GetUpdatedTopLeftCorner();
            }
        }
        public float ViewWidth { get; set; }
        public float ViewHeight { get; set; }
        public IFractalModel Model { get; }
        public Dispatcher CurrentDispatcher { get; private set; }

        private readonly BitmapRenderer bitmapRenderer = new BitmapRenderer();

        private PointD origin;

        public FractalViewModel(IFractalModel model, Dispatcher currentDispatcher)
        {
            Model = model;
            CurrentDispatcher = currentDispatcher;
            PixelHeight = 600;
            PixelWidth = 800;
            MaxIterations = 50;
            ViewWidth = 3.0f;
            ViewHeight = 2.25f;
            origin = new PointD(0, 0);
            TopLeftCorner = GetInitialTopLeftCorner();
        }

        private PointD GetInitialTopLeftCorner()
        {
            var x = ViewWidth*(2.1f/3f);
            var y = ViewHeight*(1.1f/2.25f);

            return new PointD(origin.X - x, origin.Y - y);
        }

        private PointD GetUpdatedTopLeftCorner()
        {
            var x = ViewWidth /2;
            var y = ViewHeight/2;

            return new PointD(Origin.X - x, Origin.Y - y);
        }

        public PointD GetWorldCoordinates(int width, int height, System.Windows.Point clickPoint)
        {
            var dX = ViewWidth/(width/(float)clickPoint.X);
            var dY = ViewHeight/(height/ (float)clickPoint.Y);
            return new PointD(TopLeftCorner.X + dX, TopLeftCorner.Y + dY);
        }

        public Bitmap Render()
        {
            var inputList = new List<PointD>(PixelHeight*PixelWidth);
            var xAxisValues = Maths.DoubleRange(PixelWidth, TopLeftCorner.X, TopLeftCorner.X + ViewWidth);
            var yAxisValues = Maths.DoubleRange(PixelHeight, TopLeftCorner.Y, TopLeftCorner.Y + ViewHeight);

            for (int x = 0; x < PixelWidth; x++)
            {
                for (int y = 0; y < PixelHeight; y++)
                {
                    inputList.Add(new PointD(xAxisValues[x], yAxisValues[y]));
                }
            }

            var output = Model.Iterate(inputList, MaxIterations);

            var colourTable = new ColourTable(1024){
                StartColor = Color.Black,
                EndColor = Color.FromArgb(255, 255, 0, 255)
            };
            colourTable.SetupColourTable();
            var bitmap = new Bitmap(PixelWidth, PixelHeight);
            bitmapRenderer.Render(bitmap, output, colourTable, MaxIterations);

            return bitmap;
        }
    }
}