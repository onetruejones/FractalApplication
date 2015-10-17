using System.Windows;

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
        private int width = 550;
        private int height = 410;
        private IIterator iterator;
        private int maximumIterations = 150;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnRender_Click(object sender, RoutedEventArgs e)
        {
            double ratio = (double)width / height;

            double planeLength = 0.9 + 2.1;
            double planeHeight = planeLength / ratio;

            var topLeft = new PointD(-2.2, -1.1);
            var bottomRight = new PointD(topLeft.X + planeLength, topLeft.Y + planeHeight);
            iterator = GetIterator(topLeft, bottomRight);

            var grid = iterator.IterateFractalPlane();

            var colourTable = new ColourTable(maximumIterations) { StartColor = Color.Black, EndColor = Color.FromArgb(255, 255, 0, 255) };
            colourTable.SetupColourTable();

            var bitmap = new Bitmap(width, height);

            var bitmapRenderer = new BitmapRenderer();
            bitmapRenderer.Render(bitmap, grid, colourTable, maximumIterations);

            DisplayBitmap(bitmap);
        }

        private IIterator GetIterator(PointD topLeft, PointD bottomRight)
        {
//            return new TestIterator(new FractalPlane(width, height, topLeft, bottomRight), 25);   
            return new FractalIterator(new FractalPlane(width, height, topLeft, bottomRight), maximumIterations);
        }

        private void DisplayBitmap(Image bitmap)
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
                RenderTarget.Source = bitmapImage;
            }
        }
    }
}
