using System;

namespace AreaCalculator.Shapes
{
    public class Triangle : IShape
    {
        public double A;
        public double B;
        public double C;
        public Triangle(double a, double b, double c)
        {
            A = a;
            B = b;
            C = c;
            GuardAgainstInvalid();
        }
        private void GuardAgainstInvalid()
        {
            if (A + B < C || B + C < A || C + A < B)
            {
                throw new InvalidOperationException("Given side lengths can not form a valid triangle");
            }
        }
        public double Area()
        {
            // half of perimeter
            var hp = (A + B + C) / 2;
            return Math.Sqrt(hp * (hp - A) * (hp - B) * (hp - C));
        }
    }
}