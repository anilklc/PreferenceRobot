using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PreferenceRobot.Application.DTOs;
using PreferenceRobot.Application.Interfaces;
using PreferenceRobot.Application.Interfaces.Repositories.University;
using PreferenceRobot.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreferenceRobot.Application.Features.Queries.University.GetAllUniversityDto
{
    public class GetAllUniversityDtoQueryHandler : IRequestHandler<GetAllUniversityDtoQueryRequest, GetAllUniversityDtoQueryResponse>
    {
        private readonly IUniversityReadRepository _universityReadRepository;
        private readonly ICityReadRepository _cityReadRepository;
        private readonly IMapper _mapper;

        public GetAllUniversityDtoQueryHandler(IMapper mapper, IUniversityReadRepository universityReadRepository, ICityReadRepository cityReadRepository)
        {
            _mapper = mapper;
            _universityReadRepository = universityReadRepository;
            _cityReadRepository = cityReadRepository;
        }

        public async Task<GetAllUniversityDtoQueryResponse> Handle(GetAllUniversityDtoQueryRequest request, CancellationToken cancellationToken)
        {
            var universityInfos = _universityReadRepository.GetAll(false).ToList();
            var universityDtos = _mapper.Map<List<UniversityDto>>(universityInfos);

            foreach (var universityDto in universityDtos)
            {
                var city = _cityReadRepository.GetAll(false);
                universityDto.CityName = city.FirstOrDefault(c => c.Id == universityDto.CityId).CityName;

            }

            return new ()
            {
                UniversityDtos = universityDtos
            };
        }
    }
}
