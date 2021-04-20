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
            this.FullName = fullname;
            this.ConstructorInfos = ctors;
            this.Name = name;
        }
    }
}