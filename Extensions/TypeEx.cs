using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoMapperCustomAttributesExample.Extensions
{
    public static class TypeEx
    {
         
        public static IMapper GetTypeMapper<T>(this Type type) where T : class
        {
            var builder = new AutoMapperAttributeBuilder<T>();
            var mapper = builder.BuildMapper();
            return mapper;
        }
  
    }
}
