using AutoMapper;
using AutoMapper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AutoMapperCustomAttributesExample
{

    public class AutoMapperAttributeBuilder<T1>
                        : IMapperFactory<T1> where T1 : class
    {
        public AutoMapperAttributeBuilder()
        {
        }

        public IMapper BuildMapper(Type targetExplicit = null)
        {
            var types = Assembly.GetExecutingAssembly().GetTypes()
                .Union(Assembly.GetCallingAssembly().GetTypes()).AsQueryable();
            types = types.Where(t => t.IsClass && t.GetCustomAttributes<MapTargetAttribute>().Count() > 0)
            .Where(t => t.GetCustomAttribute<MapTargetAttribute>().Source == typeof(T1));
            if (targetExplicit != null)
                types = types.Where(e => e.GetType() == targetExplicit);
            if (types.Count() == 0)
                throw new InvalidOperationException("Target Type Not Found For given source");
            var target = types.FirstOrDefault();
            var map = new MapperConfiguration(x => x.CreateMap(typeof(T1), target));
            if (target.GetProperties().Any(p => p.GetCustomAttributes<MapFieldName>().Count() > 0))
            {
                var expression = new MapperConfigurationExpression();
                var exp = expression.CreateMap(typeof(T1), target);
                foreach (var pro in target.GetProperties().Where(p => p.GetCustomAttributes<MapFieldName>().Count() > 0))
                {
                    foreach (var attrDescriptor in pro.GetCustomAttributes<MapFieldName>())
                    {
                        var sourceField = attrDescriptor.From;
                        var targetField = attrDescriptor.Name;
                        exp.ForMember(targetField, m => m.MapFrom(sourceField));
                    }
                }
                map = new MapperConfiguration(expression);
            }
            return map.CreateMapper();
        }


    }

}
