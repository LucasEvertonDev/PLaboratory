
using AutoMapper;
using PLaboratory.Core.Domain.Plugins.IMappers;

namespace PLaboratory.Plugins.AutoMapper;

public class Mapper : IMapperPlugin
{
    private readonly IMapper _mapper;

    public Mapper(IMapper mapper)
    {
        _mapper = mapper;
    }

    public TDestination Map<TDestination>(object source) where TDestination : class
    {
        return _mapper.Map<TDestination>(source);
    }

    public TDestination Map<TSource, TDestination>(TSource source, TDestination destination) where TDestination : class
    {
        return _mapper.Map(source, destination);
    }
}
