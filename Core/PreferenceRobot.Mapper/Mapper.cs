using AutoMapper;
using AutoMapper.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreferenceRobot.Mapper
{
    public class Mapper : Application.Interfaces.AutoMapper.IMapper
    {
        public static List<TypePair> typePairs = new();
        private  IMapper _mapper;
        public TDestination Map<TDestination, TSource>(TSource source)
        {
            Config<TDestination, TSource>(5);

            return _mapper.Map<TSource, TDestination>(source);
        }

        public IList<TDestination> Map<TDestination, TSource>(IList<TSource> source)
        {
            Config<TDestination, TSource>(5);

            return _mapper.Map<IList<TSource>, IList<TDestination>>(source);
        }

        public TDestination Map<TDestination>(object source)
        {
            Config<TDestination, object>(5);

            return _mapper.Map<TDestination>(source);
        }

        public IList<TDestination> Map<TDestination>(IList<object> source)
        {
            Config<TDestination, IList<object>>(5);

            return _mapper.Map<IList<TDestination>>(source);
        }

        protected void Config<TDestionation, TSource>(int depth = 5)
        {
            var typePair = new TypePair(typeof(TSource), typeof(TDestionation));

            if (typePairs.Any(a => a.DestinationType == typePair.DestinationType && a.SourceType == typePair.SourceType))
                return;

            typePairs.Add(typePair);

            var config = new MapperConfiguration(cfg =>
            {
                foreach (var item in typePairs)
                {
                        cfg.CreateMap(item.SourceType, item.DestinationType).MaxDepth(depth).ReverseMap();
                }
            });

            _mapper = config.CreateMapper();
        }
    }
}
