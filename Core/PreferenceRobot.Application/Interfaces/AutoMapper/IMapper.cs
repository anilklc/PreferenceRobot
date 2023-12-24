using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreferenceRobot.Application.Interfaces.AutoMapper
{
    public interface IMapper
    {
        TDestination Map<TDestination,TSource>(TSource source);
        IList<TDestination> Map<TDestination,TSource>(IList<TSource> source);

        TDestination Map<TDestination>(object source);
        IList<TDestination> Map<TDestination>(IList<object> source);
    }
}
