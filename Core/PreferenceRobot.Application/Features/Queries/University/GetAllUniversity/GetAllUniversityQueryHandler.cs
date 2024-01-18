using AutoMapper;
using MediatR;
using MediatR.Pipeline;
using Microsoft.Extensions.Logging;
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
        
        private readonly IUniversityReadRepository _universityReadRepository;
        private readonly ILogger<GetAllUniversityQueryHandler> _logger;
        public GetAllUniversityQueryHandler(IUniversityReadRepository universityReadRepository, ILogger<GetAllUniversityQueryHandler> logger = null)
        {
            _universityReadRepository = universityReadRepository;
            _logger = logger;
        }

        public async Task<GetAllUniversityQueryResponse> Handle(GetAllUniversityQueryRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Get All University");
            var universitises = _universityReadRepository.GetAll(false).ToList();
            return new()
            {
                Universities = universitises

            };

        }
    }
}
