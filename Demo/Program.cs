using System;
using System.Linq;
using AreaCalculator;
using AreaCalculator.Shapes;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            var calculator = new Calculator();
            var availableShapes = calculator.AvailableShapes();
            foreach (var shape in availableShapes)
            {
                Console.WriteLine(shape.Name);
            }
        }
    }
}