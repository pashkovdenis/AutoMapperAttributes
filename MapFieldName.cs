using System;
using System.Collections.Generic;
using System.Text;

namespace AutoMapperCustomAttributesExample
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class MapFieldName : Attribute
    {

        public string Name { get; }


        public string From { get; }

        public MapFieldName(string ToField, string FromField)
        {
            Name = ToField;
            From = FromField;


        }
    }
}
