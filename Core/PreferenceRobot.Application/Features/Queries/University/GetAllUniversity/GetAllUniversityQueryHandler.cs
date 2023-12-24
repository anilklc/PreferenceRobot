using AutoMapper;
using MediatR;
using MediatR.Pipeline;
using PreferenceRobot.Application.DTOs;
using PreferenceRobot.Application.Interfaces.Repositories.University;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreferenceRobot.Application.Features.Queries.University.GetAllUniversity
{
    public class GetAllUniversityQueryHandler : IRequestHandler<GetAllUniversityQueryRequest, GetAllUniversityQueryResponse>
    {
        //looger yapısı ilerde eklenecek
        private readonly IUniversityReadRepository _universityReadRepository;
        public GetAllUniversityQueryHandler(IUniversityReadRepository universityReadRepository)
        {
            _universityReadRepository = universityReadRepository;
        }

        public async Task<GetAllUniversityQueryResponse> Handle(GetAllUniversityQueryRequest request, CancellationToken cancellationToken)
        {
            var universitises = _universityReadRepository.GetAll(false).ToList();
            return new()
            {
                Universities = universitises

            };

        }
    }
}
