using MediatR;
using PreferenceRobot.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreferenceRobot.Application.Features.Queries.City.GetAllCity
{
    public class GetAllCityQueryHandler : IRequestHandler<GetAllCityQueryRequest, GetAllCityQueryResponse>
    {
        private readonly ICityReadRepository _cityReadRepository;

        public GetAllCityQueryHandler(ICityReadRepository cityReadRepository)
        {
            _cityReadRepository = cityReadRepository;
        }

        public async Task<GetAllCityQueryResponse> Handle(GetAllCityQueryRequest request, CancellationToken cancellationToken)
        {
            var cities = _cityReadRepository.GetAll(false).ToList();
            return new()
            { 
                Cities = cities,
            };
        }
    }
}
