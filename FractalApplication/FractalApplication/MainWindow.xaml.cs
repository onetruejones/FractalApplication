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
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnRender_Click(object sender, RoutedEventArgs e)
        {
            var colourTable = new ColourTable(124) { StartColor = Color.FromArgb(0, 0, 0, 255), EndColor = Color.FromArgb(255, 255, 255, 255)};
            colourTable.SetupColourTable();
            var calculatedGrid = new CalculatedGrid(124, 124);
            for (int i = 0; i < 124; i++)
            {
                for (int j = 0; j < 124; j++)
                {
                    calculatedGrid[i, j] = i;
                }
            }
            var bitmap = new Bitmap(124, 124);

            var bitmapRenderer = new BitmapRenderer();
            bitmapRenderer.Render(bitmap, calculatedGrid, colourTable);

            DisplayBitmap(bitmap);
        }

        private void DisplayBitmap(Bitmap bitmap)
        {
            using (MemoryStream memory = new MemoryStream())
            {
                bitmap.Save(memory, ImageFormat.Png);
                memory.Position = 0;
                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = memory;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();
                RenderTarget.Source = bitmapImage;
            }
        }
    }
}
