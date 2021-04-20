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
            var ctors = GetType().GetConstructors();
            return new ShapeInfo(shapeName, ctors);
        }

        public double Area();
    }
}