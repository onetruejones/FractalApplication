namespace onetruejones.FractalRenderer
{
    using System.Drawing;
    using onetruejones.Domain;

    public class BitmapRenderer : IRenderer
    {
        private readonly Bitmap bitmap;

        public BitmapRenderer(Bitmap bitmap)
        {
            this.bitmap = bitmap;
        }

        public void Render(CalculatedGrid calculatedGrid)
        {
            throw new System.NotImplementedException();
        }
    }
}
