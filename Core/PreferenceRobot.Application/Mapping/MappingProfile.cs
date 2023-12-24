using AutoMapper;
using PreferenceRobot.Application.DTOs;
using PreferenceRobot.Application.Features.Queries.University.GetAllUniversityDto;
using PreferenceRobot.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PreferenceRobot.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<City, UniversityDto>()
                .ForMember(dest => dest.CityName, opt => opt.MapFrom(src => src.CityName));

            CreateMap<UniversityInfo, UniversityDto>()
                .ForMember(dest => dest.CityName, opt => opt.MapFrom(src => src.CityId));
        }
    }
}
