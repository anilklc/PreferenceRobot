using MediatR;
using PreferenceRobot.Application.Features.Commands.University.Rules;
using PreferenceRobot.Application.Interfaces.Repositories.University;
using PreferenceRobot.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreferenceRobot.Application.Features.Commands.University.UpdateUniversity
{
    public class UpdateUniversityCommandHandler : IRequestHandler<UpdateUniversityCommandRequest, UpdateUniversityCommandResponse>
    {
        private readonly IUniversityWriteRepository _universityWriteRepository;
        private readonly IUniversityReadRepository _universityReadRepository;
        private readonly UniversityRules _universityRules;
        public UpdateUniversityCommandHandler(IUniversityWriteRepository universityWriteRepository, IUniversityReadRepository universityReadRepository = null, UniversityRules universityRules = null)
        {
            _universityWriteRepository = universityWriteRepository;
            _universityReadRepository = universityReadRepository;
            _universityRules = universityRules;
        }

        public async Task<UpdateUniversityCommandResponse> Handle(UpdateUniversityCommandRequest request, CancellationToken cancellationToken)
        {
            var cities = _universityReadRepository.GetAll(false).ToList();
            await _universityRules.UniversityTitleMustNotBeSame(cities,request.UniversityName);
            UniversityInfo universityInfo = await _universityReadRepository.GetByIdAsync(request.Id);
            universityInfo.UniversityName = request.UniversityName;
            universityInfo.CityId = Guid.Parse(request.CityId);
            universityInfo.Website = request.Website;
            await _universityWriteRepository.SaveAsync();
            return new();
        }
    }
}
