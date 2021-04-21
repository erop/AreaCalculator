namespace AreaCalculator.Shapes
{
    public class Rectangle : IShape
    {
        private readonly bool _isSquare;
        private readonly double _sideA;
        private readonly double _sideB;

        public Rectangle(double sideA, double sideB)
        {
            _sideA = sideA;
            _sideB = sideB;
        }

        public Rectangle(double sideA) : this(sideA, sideA)
        {
            _isSquare = true;
        }

        public string Description()
        {
            if (_isSquare) return "This rectangle is actually a square";
            var pointer = (IShape) this;
            return pointer.Description();
        }

        public double Area()
        {
            return _sideA * _sideB;
        }
    }
}