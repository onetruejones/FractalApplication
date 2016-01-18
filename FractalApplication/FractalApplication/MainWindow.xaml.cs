using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media;

namespace onetruejones.FractalApplication
{
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.IO;
    using System.Windows.Media.Imaging;
    using Domain;
    using FractalRenderer;
    using Color = System.Drawing.Color;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int width = 800;
        private int height = 600;
        private IIterator iterator;
        private int maximumIterations;
        private CalculatedGrid calculatedGrid;
        private ColourTable colourTable;

        public MainWindow()
        {
            InitializeComponent();
        }

        private async void BtnRender_Click(object sender, RoutedEventArgs e)
        {
            BtnRender.Content = "Rendering";
            BtnRender.IsEnabled = false;
//            height = (int)RenderTarget.ActualHeight;
//            width = (int) RenderTarget.ActualWidth;
//            var renderSize = GetElementPixelSize(RenderTarget);
//            width = (int)renderSize.Width;
//            height = (int) renderSize.Height;

            await RenderYeFractal();
        }

        public System.Windows.Size GetElementPixelSize(UIElement element)
        {
            Matrix transformToDevice;
            var source = PresentationSource.FromVisual(element);
            if (source != null)
                transformToDevice = source.CompositionTarget.TransformToDevice;
            else
                using (var newSource = new HwndSource(new HwndSourceParameters()))
                {
                    transformToDevice = newSource.CompositionTarget.TransformToDevice;
                }
                    

            if (element.DesiredSize == new System.Windows.Size())
                element.Measure(new System.Windows.Size(double.PositiveInfinity, double.PositiveInfinity));

            return (System.Windows.Size)transformToDevice.Transform((Vector)element.DesiredSize);
        }
        private async Task RenderYeFractal()
        {
            maximumIterations = int.Parse(TxtMaximumIterations.Text);
            await Task.Run(() =>
            {
                SetUpColourTable();

                iterator = GetIterator();
                iterator.IterateFractalPlane();

            });
            DisplayBitmap(RenderBitmap(), RenderTarget);

            BtnRender.Content = "Render";
            BtnRender.IsEnabled = true;
        }

        private Bitmap RenderBitmap()
        {
            var bitmap = new Bitmap(width, height);
            new BitmapRenderer().Render(bitmap, calculatedGrid, colourTable, maximumIterations);
            return bitmap;
        }

        private void SetUpColourTable()
        {
            colourTable = new ColourTable(maximumIterations)
            {
                StartColor = Color.Black,
                EndColor = Color.FromArgb(255, 255, 0, 255)
            };
            colourTable.SetupColourTable();
        }

        private IIterator GetIterator()
        {
//            return new TestIterator(new FractalPlane(width, height, topLeft, bottomRight), 25);   
            double ratio = (double)width / height;
            double planeLength = 0.9 + 2.1;
            double planeHeight = planeLength / ratio;

            var topLeft = new PointD(-2.2, -1.1);
            var bottomRight = new PointD(topLeft.X + planeLength, topLeft.Y + planeHeight);
            var fractalPlane = new FractalPlane(width, height, topLeft, bottomRight);
            calculatedGrid = new CalculatedGrid(fractalPlane.Width, fractalPlane.Height);
            return new FractalIterator(fractalPlane, maximumIterations, new EscapeCalculator(), calculatedGrid);
        }

        private void DisplayBitmap(Image bitmap, System.Windows.Controls.Image renderTarget)
        {
            using (var memory = new MemoryStream())
            {
                bitmap.Save(memory, ImageFormat.Bmp);
                memory.Position = 0;
                var bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = memory;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();
                renderTarget.Source = bitmapImage;
            }
        }

        private void RenderTarget_OnSizeChanged(object sender, SizeChangedEventArgs e)
        {
            var image = sender as System.Windows.Controls.Image;
            if (image == null)
            {
                return;
            }

            width = (int) image.ActualWidth;
            height = (int) image.ActualHeight;
        }
    }
}
