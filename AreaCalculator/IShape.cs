namespace AreaCalculator
{
    public interface IShape
    {
        public string Description()
        {
            return "The shape has no special description";
        }

        public ShapeInfo Info()
        {
            return new(
                GetType().FullName,
                GetType().Name,
                GetType().GetConstructors()
            );
        }

        public double Area();
    }
}