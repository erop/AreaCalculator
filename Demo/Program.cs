using System;
using System.Linq;
using AreaCalculator;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            IShape shape = new Circle(5);
            Console.WriteLine(shape.Info().Name);
            var parameterInfos = shape.Info().ParameterInfos;
            if (parameterInfos?.Length > 0)
            {
                foreach (var param in parameterInfos)
                {
                    Console.WriteLine(param.Name);
                    Console.WriteLine(param.ParameterType);
                }
            }
        }
    }
}