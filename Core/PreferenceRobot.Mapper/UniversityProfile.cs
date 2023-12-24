using AutoMapper;
using PreferenceRobot.Application.DTOs;
using PreferenceRobot.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityMapperLibrary
{
    public class UniversityProfile : Profile
    {
        public UniversityProfile()
        {
            CreateMap<City, CityDto>();
            CreateMap<UniversityInfo, UniversityDto>()
                .ForMember(dest => dest.CityName, opt => opt.MapFrom(src => src.City.CityName))
                .ForMember(dest => dest.CityId, opt => opt.MapFrom(src => src.City.Id));
        }
    }
}
