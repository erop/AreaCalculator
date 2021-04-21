using System;
using AreaCalculator;
using AreaCalculator.Shapes;
using NUnit.Framework;

namespace AreaCalculatorTest
{
    public class RectangleTests
    {
        private Rectangle _rectangle;

        [SetUp]
        public void Setup()
        {
            this._rectangle = new Rectangle(3, 4);
        }

        [Test]
        public void TestRectangleAreaCalculation()
        {
            var expected = (double) 3 * 4;
            var actual = Calculator.Area(_rectangle);
            Assert.AreEqual(expected, actual, 0.001);
        }
    }
}