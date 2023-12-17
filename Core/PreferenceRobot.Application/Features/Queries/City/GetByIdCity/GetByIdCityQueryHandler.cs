using MediatR;
using PreferenceRobot.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreferenceRobot.Application.Features.Queries.City.GetByIdCity
{
    public class GetByIdCityQueryHandler : IRequestHandler<GetByIdCityQueryRequest, GetByIdCityQueryResponse>
    {
        private readonly ICityReadRepository _cityReadRepository;

        public GetByIdCityQueryHandler(ICityReadRepository cityReadRepository)
        {
            _cityReadRepository = cityReadRepository;
        }

        public async Task<GetByIdCityQueryResponse> Handle(GetByIdCityQueryRequest request, CancellationToken cancellationToken)
        {
            var city = await _cityReadRepository.GetByIdAsync(request.Id,false);
            return new()
            {
                City = city
            };
        }
    }
}
