using System;
using System.Collections.Generic;
using System.Linq;

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
            var shapes = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(t => t.GetTypes())
                .Where(x => typeof(IShape).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
                .ToList();
            foreach (var shape in shapes)
            {
                result.Add(new ShapeInfo(shape.Name, shape.GetConstructors()));
            }

            return result;
        }
    }
}