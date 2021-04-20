using System;

namespace AreaCalculator.Shapes
{
    public class Rectangle : IShape
    {
        private readonly double _sideA;
        private readonly double _sideB;
        private readonly bool _isSquare = false;
        public Rectangle(double sideA, double sideB)
        {
            this._sideA = sideA;
            this._sideB = sideB;
        }
        public Rectangle(double sideA)
        {
            _sideA = sideA;
            _sideB = sideA; // second side is equal to first one
            _isSquare = true;
        }
        public string Description()
        {
            if (_isSquare)
            {
                return "This rectangle is actually a square";
            }
            var pointer = (IShape) this;
            return pointer.Description();
        }
        public double Area()
        {
            return _sideA * _sideB;
        }
    }
}