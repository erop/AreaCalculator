using System.Reflection;
using static System.Reflection.BindingFlags;

namespace AreaCalculator
{
    public interface IShape
    {
        public string Description() => "The shape has no special description";

        public ShapeInfo Info()
        {
            var shapeName = GetType().Name;
            var ctorParams = GetType().GetConstructor(
                Instance | Public, null,
                new[] {typeof(double), typeof(float), typeof(int)},
                null)
                ?.GetParameters();
            return new ShapeInfo(shapeName, ctorParams);
        }

        public double Area();
    }
}