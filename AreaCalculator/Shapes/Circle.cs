using System;

namespace AreaCalculator.Shapes
{
    public class Circle : IShape
    {
        private readonly double _radius;

        public Circle(double radius)
        {
            _radius = radius;
        }
        
        public double Area()
        {
            return Math.PI * Math.Pow(_radius, 2);
        }
    }
}