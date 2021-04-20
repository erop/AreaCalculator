using System;

namespace AreaCalculator.Shapes
{
    public class Rectangle : IShape
    {
        public readonly double SideA;
        public readonly double SideB;
        public readonly bool IsSquare = false;
        public Rectangle(double sideA, double sideB)
        {
            this.SideA = sideA;
            this.SideB = sideB;
        }
        public Rectangle(double sideA)
        {
            SideA = sideA;
            SideB = sideA; // second side is equal to first one
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
            return SideA * SideB;
        }
    }
}