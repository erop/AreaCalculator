using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using AreaCalculator;
using AreaCalculator.Shapes;

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
            if (!WantToProceed())
            {
                return;
            }

            var shapeInfo = ChooseShape(shapes);
            CalculateAreaForChosenShape(shapeInfo);
        }

        private static void CalculateAreaForChosenShape(ShapeInfo chosenShape)
        {
            var shapeName = chosenShape.Name;
            var ctorInfos = chosenShape.ConstructorInfos;
            Console.WriteLine($"You choose {shapeName}");
            Console.WriteLine($"There are {ctorInfos.Length} variant(s) of parameters of the {shapeName}");
            // var ctorArgs = DisplayAndSelectConstructorArguments(ctorInfos);
            IShape shape = InitializeShapeWithArguments(chosenShape.FullName, ctorArgs);
            Console.WriteLine("Congratulations!!!");
            Console.WriteLine($"The area of the {shapeName} equals to {Calculator.Area(shape)}");
        }

        private static IShape InitializeShapeWithArguments(string shapeFullName, object ctorArgs)
        {
            var shapeType = Type.GetType(shapeFullName);
            if (null == shapeType)
            {
                throw new ArgumentException($"Could not determine the type of '{shapeFullName}'");
            }

            try
            {
                var shape = Activator.CreateInstance(shapeType, ctorArgs);
                if (null == shape)
                {
                    throw new Exception($"Could not instantiate and object of type '{shapeFullName}'");
                }

                return (IShape) shape;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        // private static DisplayAndSelectConstructorArguments(ConstructorInfo[] ctorInfos)
        // {
        //     while (true)
        //     {
        //         foreach (var info in ctorInfos)
        //         {
        //         }
        //     }
        // }

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
                    continue;
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
            int counter = 0;
            foreach (var shape in shapes)
            {
                Console.WriteLine($"{++counter} {shape.Name}");
            }
        }

        private static void DisplayGreeting()
        {
            Console.WriteLine("Hi! This is the shape area calculator");
        }
    }
    // {
    //     var running = true;
    //     var calculator = new Calculator();
    //     var shapes = calculator.AvailableShapes();
    //     Console.WriteLine("This is The Area Calculator for co");
    //     while (running)
    //     {
    //         Console.WriteLine($"There are {shapes.Count} shapes in Calculator");
    //         var counter = 1;
    //         foreach (var shape in shapes)
    //         {
    //             Console.WriteLine($"{counter}: {shape.Name}");
    //             counter++;
    //         }
    //
    //         Console.WriteLine("Choose the number of the shape which area you would like to calculate...");
    //         var index = Convert.ToInt16(Console.ReadLine()) - 1;
    //         if (!Enumerable.Range(0, shapes.Count).Contains(index))
    //         {
    //             Console.WriteLine("You choose the wrong number. Repeat please...");
    //             continue;
    //         }
    //
    //         var chosen = shapes[index];
    //         var nameOfChosen = chosen.Name;
    //         var ctors = chosen.ConstructorInfos;
    //         if (ctors.Length > 1)
    //         {
    //             Console.WriteLine("Chosen shape has the following constructors: ");
    //             for (var i = 0; i < ctors.Length; i++)
    //             {
    //                 Console.WriteLine($"{i + 1}: {ctors[i].DeclaringType}");
    //             }
    //         }
    //         else
    //         {
    //             Console.WriteLine("Chosen shape has constructor with the following parameters: ");
    //             var parameterInfo = ctors[0].GetParameters()[0];
    //             Console.WriteLine(StringifyParameterInfo(parameterInfo));
    //             Console.WriteLine("Enter value for parameter: " + parameterInfo.Name);
    //             var param = Convert.ToDouble(Console.ReadLine());
    //             var instantiated = Activator.CreateInstance(chosen.FullName);
    //             Console.WriteLine("The result is : {0}", calculator.Area());
    //         }
    //
    //
    //         // running = false;
    //     }
    // }
}