using MediatR;
using MediatR.Pipeline;
using PreferenceRobot.Application.Interfaces.Repositories.University;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreferenceRobot.Application.Features.Queries.University.GetByIdUniversity
{
    public class GetByIdUniversityQueryHandler : IRequestHandler<GetByIdUniversityQueryRequest, GetByIdUniversityQueryResponse>
    {
        private readonly IUniversityReadRepository _universityReadRepository;
        public GetByIdUniversityQueryHandler(IUniversityReadRepository universityReadRepository)
        {
            _universityReadRepository = universityReadRepository;            
        }
        public async Task<GetByIdUniversityQueryResponse> Handle(GetByIdUniversityQueryRequest request, CancellationToken cancellationToken)
        {
            var university = await  _universityReadRepository.GetByIdAsync(request.Id,false);
            return new()
            {
                UniversityName = university.UniversityName,
                CityId = university.CityId,
                Website = university.Website
            };

        }
    }
}
