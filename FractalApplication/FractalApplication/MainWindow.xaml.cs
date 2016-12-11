using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using onetruejones.FractalRenderer.Model;
using onetruejones.FractalRenderer.ViewModel;

namespace onetruejones.FractalApplication
{
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.IO;
    using System.Windows.Media.Imaging;
    using Domain;
    using FractalRenderer;

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
        private readonly FractalViewModel viewModel;

        public MainWindow()
        {
            InitializeComponent();

            viewModel = new FractalViewModel(new FractalModel(new EscapeCalculator()), Application.Current.Dispatcher);
            
            DataContext = viewModel;
            RenderTarget.Width = width;
            RenderTarget.Height = height;
        }

        private void BtnRender_Click(object sender, RoutedEventArgs e)
        {
//            BtnRender.Content = "Rendering";
//            BtnRender.IsEnabled = false;
//            height = (int)RenderTarget.ActualHeight;
//            width = (int) RenderTarget.ActualWidth;
//            var renderSize = GetElementPixelSize(RenderTarget);
//            width = (int)renderSize.Width;
//            height = (int) renderSize.Height;

//            await RenderYeFractal();

            var bitmap = viewModel.Render();
            DisplayBitmap(bitmap, RenderTarget);

//            BtnRender.Content = "Render";
//            BtnRender.IsEnabled = true;
        }

        public System.Windows.Size GetElementPixelSize(UIElement element)
        {
            Matrix transformToDevice;
            var source = PresentationSource.FromVisual(element);
            if (source != null)
            {
                transformToDevice = source.CompositionTarget.TransformToDevice;
            }
            else
            {
                using (var newSource = new HwndSource(new HwndSourceParameters()))
                {
                    transformToDevice = newSource.CompositionTarget.TransformToDevice;
                }
            }

            if (element.DesiredSize == new System.Windows.Size())
            {
                element.Measure(new System.Windows.Size(double.PositiveInfinity, double.PositiveInfinity));
            }

            return (System.Windows.Size)transformToDevice.Transform((Vector)element.DesiredSize);
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

        private void RenderTarget_OnMouseUp(object sender, MouseButtonEventArgs e)
        {
            var mouseClickPointOnScreen = GetMouseClickPointOnScreen(e);
            var topLeft = RenderTarget.PointToScreen(new System.Windows.Point(0, 0));
            var point = new System.Windows.Point(mouseClickPointOnScreen.X - topLeft.X, mouseClickPointOnScreen.Y - topLeft.Y);
            var worldCoordinates = viewModel.GetWorldCoordinates(GetTargetWidth(), GetTargetHeight(), point);

            viewModel.ViewWidth = viewModel.ViewWidth/2;
            viewModel.ViewHeight = viewModel.ViewHeight/2;
            viewModel.Origin = worldCoordinates;

            var bitmap = viewModel.Render();
            DisplayBitmap(bitmap, RenderTarget);

        }

        private System.Windows.Point GetMouseClickPointOnScreen(MouseButtonEventArgs e)
        {
            var position = e.MouseDevice.GetPosition(RenderTarget);
            var mouseClickPointOnScreen = RenderTarget.PointToScreen(position);
            return mouseClickPointOnScreen;
        }

        private int GetTargetHeight()
        {
            var topLeft = RenderTarget.PointToScreen(new System.Windows.Point(0, 0));

            var bottomRight = RenderTarget.PointToScreen(new System.Windows.Point(RenderTarget.ActualWidth, RenderTarget.ActualHeight));

            return (int)bottomRight.Y - (int)topLeft.Y;
        }

        private int GetTargetWidth()
        {
            var topLeft = RenderTarget.PointToScreen(new System.Windows.Point(0, 0));

            var bottomRight = RenderTarget.PointToScreen(new System.Windows.Point(RenderTarget.ActualWidth, RenderTarget.ActualHeight));

            return (int)bottomRight.X - (int)topLeft.X;
        }

        private PointD ScreenPointToCoordinatePoint(System.Windows.Point screenPoint)
        {
            var topLeft = RenderTarget.PointToScreen(new System.Windows.Point(0, 0));

            var bottomRight = RenderTarget.PointToScreen(new System.Windows.Point(RenderTarget.ActualHeight, RenderTarget.ActualWidth));
            return new PointD();
        }
    }
}
