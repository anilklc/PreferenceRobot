using MediatR;
using PreferenceRobot.Application.Features.Commands.University.Rules;
using PreferenceRobot.Application.Interfaces.Repositories.University;
using PreferenceRobot.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreferenceRobot.Application.Features.Commands.University.CreateUniversity
{
    public class CreateUniversityCommandHandler : IRequestHandler<CreateUniversityCommandRequest, CreateUniversityCommandResponse>
    {
        private readonly IUniversityWriteRepository _universityWriteRepository;
        private readonly IUniversityReadRepository _universityReadRepository;
        private readonly UniversityRules _universityRules;
        public CreateUniversityCommandHandler(IUniversityWriteRepository universityWriteRepository, UniversityRules universityRules, IUniversityReadRepository universityReadRepository)
        {
            _universityWriteRepository = universityWriteRepository;
            _universityRules = universityRules;
            _universityReadRepository = universityReadRepository;
        }
        public async Task<CreateUniversityCommandResponse> Handle(CreateUniversityCommandRequest request, CancellationToken cancellationToken)
        {
            var universities = _universityReadRepository.GetAll(false).ToList();
            await _universityRules.UniversityTitleMustNotBeSame(universities,request.UniversityName);
            await _universityWriteRepository.AddAsync(new()
            {
                UniversityName = request.UniversityName,
                CityId = request.CityId,
                Website = request.WebSite
            });
            await _universityWriteRepository.SaveAsync();
            return new();
        }
    }
}
