using System.Reflection;
using static System.Reflection.BindingFlags;

namespace AreaCalculator
{
    public interface IShape
    {
        public string Description() => "The shape has no special description";

        public ShapeInfo Info()
        {
            return new ShapeInfo(
                GetType().FullName,
                GetType().Name,
                GetType().GetConstructors()
            );
        }

        public double Area();
    }
}