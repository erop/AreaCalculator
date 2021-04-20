using System;
using System.Collections.Generic;
using System.Linq;

namespace AreaCalculator
{
    public class Calculator
    {
        public static double Area(IShape shape)
        {
            return shape.Area();
        }

        public static List<ShapeInfo> GetAvailableShapes()
        {
            var shapes = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(t => t.GetTypes())
                .Where(t => typeof(IShape).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract)
                .ToList();

            return shapes.Select(shape => new ShapeInfo(shape.FullName, shape.Name, shape.GetConstructors())).ToList();
        }
    }
}