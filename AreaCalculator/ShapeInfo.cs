using System.Reflection;

namespace AreaCalculator
{
    public class ShapeInfo
    {
        public string FullName { get;  }
        public string Name { get; }
        public ConstructorInfo[] ConstructorInfos { get; }
        public ShapeInfo(string fullname, string name, ConstructorInfo[] ctors)
        {
            FullName = fullname;
            ConstructorInfos = ctors;
            Name = name;
        }
    }
}