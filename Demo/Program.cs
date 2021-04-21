using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using AreaCalculator;

namespace Demo
{
    internal class Program
    {
        private static string StringifyParameterInfo(ParameterInfo info)
        {
            return $"Name: {info.Name}, Type: {info.ParameterType.Name}";
        }

        private static void Main(string[] args)
        {
            var shapes = Calculator.GetAvailableShapes();

            DisplayGreeting();
            DisplayShapesAvailable(shapes);
            if (!WantToProceed()) return;

            var shapeInfo = ChooseShape(shapes);
            CalculateAreaForChosenShape(shapeInfo);
        }

        private static void CalculateAreaForChosenShape(ShapeInfo chosenShape)
        {
            var shapeName = chosenShape.Name;
            var ctorInfos = chosenShape.ConstructorInfos;
            Console.WriteLine($"You choose {shapeName}");
            Console.WriteLine($"There are {ctorInfos.Length} variant(s) of parameters of the {shapeName}");
            var ctorArgs = DisplayAndSelectConstructorArguments(ctorInfos);
            var shape = InitializeShapeWithArguments(chosenShape.FullName, ctorArgs);
            Console.WriteLine("Congratulations!!!");
            Console.WriteLine($"The area of the {shapeName} equals to {Calculator.Area(shape)}");
        }

        private static object[] DisplayAndSelectConstructorArguments(ConstructorInfo[] ctorInfos)
        {
            var objects = Array.Empty<object>();
            while (true)
            {
                ConstructorInfo ctorInfo = ChooseConstructor(ctorInfos);
                Console.WriteLine("FINISH!");

                // int counter = 0;
                // foreach (var ctorInfo in ctorInfos)
                // {
                //     var ctorParams = ctorInfo.GetParameters();
                //     foreach (var ctorParam in ctorParams)
                //     {
                //     }
                // }
            }
        }

        private static ConstructorInfo ChooseConstructor(ConstructorInfo[] ctorInfos)
        {
            var ctorInfosLength = ctorInfos.Length;
            while (true)
            {
                Console.WriteLine($"There {ctorInfosLength} constructor(s) of chosen shape:");
                for (int i = 0; i < ctorInfosLength; i++)
                {
                    var ctorInfo = ctorInfos[i];
                    var parameterInfos = ctorInfo.GetParameters();
                    var sb = new StringBuilder();
                    foreach (var param in parameterInfos)
                    {
                        sb.Append($"{param.ParameterType} {param.Name}, ");
                    }

                    Console.WriteLine($"{i + 1} {sb.ToString().TrimEnd(new char[] {',', ' '})}");
                }

                Console.WriteLine("Which one you choose?");
                var choice = Convert.ToInt16(Console.ReadLine());
                try
                {
                    return ctorInfos[choice - 1];
                }
                catch (Exception e)
                {
                    continue;
                }
            }
        }

        private static IShape InitializeShapeWithArguments(string shapeFullName, object[] ctorArgs)
        {
            var shapeType = Type.GetType(shapeFullName);
            if (null == shapeType) throw new ArgumentException($"Could not determine the type of '{shapeFullName}'");

            try
            {
                var shape = Activator.CreateInstance(shapeType, ctorArgs);
                if (null == shape) throw new Exception($"Could not instantiate and object of type '{shapeFullName}'");

                return (IShape) shape;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private static ShapeInfo ChooseShape(List<ShapeInfo> shapes)
        {
            while (true)
            {
                DisplayShapesAvailable(shapes);
                Console.WriteLine("Please type one of the given numbers and press Enter...");
                var shapeNumber = Convert.ToInt16(Console.ReadLine());
                try
                {
                    return shapes[shapeNumber - 1];
                }
                catch (ArgumentOutOfRangeException e)
                {
                }
            }
        }

        private static bool WantToProceed()
        {
            Console.WriteLine("Do you want to calculate the area of the shape? (y/n)");
            var keyInfo = Console.ReadKey();
            if (keyInfo.KeyChar != 'y')
            {
                Console.WriteLine("\nBye-bye! See you later!");
                return false;
            }

            return true;
        }

        private static void DisplayShapesAvailable(List<ShapeInfo> shapes)
        {
            Console.WriteLine($"\nThere are {shapes.Count} shape(s) available:");
            var counter = 0;
            foreach (var shape in shapes) Console.WriteLine($"{++counter} {shape.Name}");
        }

        private static void DisplayGreeting()
        {
            Console.WriteLine("Hi! This is the shape area calculator");
        }
    }
}