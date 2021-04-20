using System.Reflection;

namespace AreaCalculator
{
    public class ShapeInfo
    {
        public ParameterInfo[] ParameterInfos { get; }
        public string Name { get; }

        public ShapeInfo(string name, ParameterInfo[] parameterInfos)
        {
            this.ParameterInfos = parameterInfos;
            this.Name = name;
        }
    }
}