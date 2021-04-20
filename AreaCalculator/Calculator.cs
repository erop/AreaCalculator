using System;
using System.Collections.Generic;

namespace AreaCalculator
{
    public class Calculator
    {
        public double Area(IShape shape)
        {
            return shape.Area();
        }

        public List<ShapeInfo> AvailableShapes()
        {
            var result = new List<ShapeInfo>();
            // Get constructor params with reflection
            // get list of available shapes
            return result;
        }
    }
}