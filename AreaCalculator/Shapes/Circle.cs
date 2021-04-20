using System;

namespace AreaCalculator.Shapes
{
    public class Circle : IShape
    {
        public double Radius { get; }

        public Circle(double radius)
        {
            Radius = radius;
        }

        public double Area()
        {
            return Math.PI * Math.Pow(Radius, 2);
        }
    }
}