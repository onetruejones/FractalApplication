using System.Windows;

namespace onetruejones.FractalApplication
{
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.IO;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using onetruejones.Domain;
    using onetruejones.FractalRenderer;
    using Color = System.Drawing.Color;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int width = 550;
        private int height = 400;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnRender_Click(object sender, RoutedEventArgs e)
        {
            var colourSteps = 25;
            double ratio = (double)width / height;
            var fractalIterator = new FractalIterator(new FractalPlane(width, height, new PointD(-2.1, -1.2), new PointD(0.9, 1.2)), 150);

            var grid = fractalIterator.IterateFractalPlane();

            var colourTable = new ColourTable(colourSteps) { StartColor = Color.FromArgb(0, 0, 0, 0), EndColor = Color.FromArgb(145, 255, 158, 0) };
            colourTable.SetupColourTable();

            var bitmap = new Bitmap(width, height);

            var bitmapRenderer = new BitmapRenderer();
            bitmapRenderer.Render(bitmap, grid, colourTable);

            DisplayBitmap(bitmap);
        }

        private void DisplayBitmap(Image bitmap)
        {
            using (var memory = new MemoryStream())
            {
                bitmap.Save(memory, ImageFormat.Png);
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
