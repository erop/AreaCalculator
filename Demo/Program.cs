using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using AreaCalculator;

namespace Demo
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var shapes = Calculator.GetAvailableShapes();

            DisplayGreeting();
            DisplayShapesAvailable(shapes);
            if (!WantToProceed()) return;

            var shapeInfo = ChooseShape(shapes);
            try
            {
                var area = CalculateAreaForChosenShape(shapeInfo);
                Console.WriteLine("Congratulations!!!");
                Console.WriteLine($"The area of the {shapeInfo.Name} equals to {area}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Sorry, impossible to calculate area of {shapeInfo.Name} with data provided ");
                Console.WriteLine(e.Message);
            }
        }

        private static double CalculateAreaForChosenShape(ShapeInfo chosenShape)
        {
            var shapeName = chosenShape.Name;
            var ctorInfos = chosenShape.ConstructorInfos;
            Console.WriteLine($"You choose {shapeName}");
            Console.WriteLine($"There are {ctorInfos.Length} variant(s) of parameters of the {shapeName}");
            var ctorInfo = ChooseConstructor(ctorInfos);
            var ctorArgs = BuildConstructorArguments(ctorInfo);
            var s = ctorInfo.Invoke(ctorArgs);
            var shape = (IShape) s;
            Console.WriteLine("Congratulations!!!");
            Console.WriteLine($"The area of the {shapeName} equals to {Calculator.Area(shape)}");
        }

        private static object[] BuildConstructorArguments(ConstructorInfo ctorInfo)
        {
            var list = new List<object>();
            foreach (var param in ctorInfo.GetParameters())
            {
                var paramType = param.ParameterType;
                Console.WriteLine($"Enter the value of type '{paramType}'");
                var entered = Console.ReadLine();
                if (null == entered) throw new ArgumentException("Could not get a string from console");

                var value = Convert.ChangeType(entered, paramType);
                if (null == value)
                    throw new ArgumentException(
                        $"Could not convert provided string '{entered}' to value of type {paramType}");

                list.Add(value);
            }

            return list.ToArray();
        }

        private static ConstructorInfo ChooseConstructor(ConstructorInfo[] ctorInfos)
        {
            var ctorInfosLength = ctorInfos.Length;
            while (true)
            {
                for (var i = 0; i < ctorInfosLength; i++)
                {
                    var ctorInfo = ctorInfos[i];
                    var parameterInfos = ctorInfo.GetParameters();
                    var sb = new StringBuilder();
                    foreach (var param in parameterInfos) sb.Append($"{param.ParameterType} {param.Name}, ");

                    Console.WriteLine($"{i + 1} {sb.ToString().TrimEnd(',', ' ')}");
                }

                if (1 == ctorInfos.Length)
                {
                    return ctorInfos[0];
                }

                Console.WriteLine("Which one you choose?");
                var choice = Convert.ToInt16(Console.ReadLine());
                try
                {
                    return ctorInfos[choice - 1];
                }
                catch (IndexOutOfRangeException e)
                {
                    // ignored
                }
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
                catch (IndexOutOfRangeException e)
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