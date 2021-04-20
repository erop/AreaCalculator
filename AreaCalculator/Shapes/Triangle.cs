using System;

namespace AreaCalculator.Shapes
{
    public class Triangle : IShape
    {
        private readonly double _a;
        private readonly double _b;
        private readonly double _c;
        public Triangle(double a, double b, double c)
        {
            _a = a;
            _b = b;
            _c = c;
            GuardAgainstInvalid();
        }
        public Triangle(double a, double b): this(a, a, b)
        {
        }
        
        public Triangle(double a): this(a, a)
        {
        }
        
        private void GuardAgainstInvalid()
        {
            if (_a + _b < _c || _b + _c < _a || _c + _a < _b)
            {
                throw new InvalidOperationException("Given sides can not form a valid triangle");
            }
        }
        public double Area()
        {
            var hp = (_a + _b + _c) / 2; // half of perimeter
            return Math.Sqrt(hp * (hp - _a) * (hp - _b) * (hp - _c));
        }
    }
}