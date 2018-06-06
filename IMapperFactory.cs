using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoMapperCustomAttributesExample
{
    public interface IMapperFactory<T1>
    {
        IMapper BuildMapper(Type targetExplicit = null);

    }

}
