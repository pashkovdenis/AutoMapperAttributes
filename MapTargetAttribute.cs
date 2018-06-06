using System;
using System.Collections.Generic;
using System.Text;

namespace AutoMapperCustomAttributesExample
{

    [AttributeUsage(AttributeTargets.Class)]
    public class MapTargetAttribute : Attribute
    {
        public Type Source;
        public MapTargetAttribute(Type source)
        {
            Source = source;
        }

    }

}
