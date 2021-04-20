using System;

namespace AreaCalculator
{
    public class Rectangle : IShape
    {
        public readonly bool IsSquare = false;
        public readonly double SideA;
        public readonly double SideB;

        public Rectangle(double sideA, double sideB)
        {
            this.SideA = sideA;
            this.SideB = sideB;
        }

        public Rectangle(double sideA)
        {
            SideA = sideA;
            IsSquare = true;
        }

        public string Description()
        {
            if (IsSquare)
            {
                return "This rectangle is actually a square";
            }

            var pointer = (IShape) this;
            return pointer.Description();
        }

        public double Area()
        {
            if (IsSquare)
            {
                return Math.Pow(SideA, 2);
            }

            return SideA * SideB;
        }
    }
}