using System.Reflection;

namespace AreaCalculator
{
    public class ShapeInfo
    {
        public string Name { get; }
        public ConstructorInfo[] ConstructorInfos { get; }
        public ShapeInfo(string name, ConstructorInfo[] ctors)
        {
            this.ConstructorInfos = ctors;
            this.Name = name;
        }
    }
}