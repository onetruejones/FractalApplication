namespace onetruejones.FractalRenderer
{
    using onetruejones.Domain;

    public interface IRenderer
    {
        void Render(CalculatedGrid calculatedGrid);
    }
}