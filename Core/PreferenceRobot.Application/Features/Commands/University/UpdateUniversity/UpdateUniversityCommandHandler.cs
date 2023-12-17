using MediatR;
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

        public UpdateUniversityCommandHandler(IUniversityWriteRepository universityWriteRepository, IUniversityReadRepository universityReadRepository = null)
        {
            _universityWriteRepository = universityWriteRepository;
            _universityReadRepository = universityReadRepository;
        }

        public async Task<UpdateUniversityCommandResponse> Handle(UpdateUniversityCommandRequest request, CancellationToken cancellationToken)
        {
            UniversityInfo universityInfo = await _universityReadRepository.GetByIdAsync(request.Id);
            universityInfo.UniversityName = request.UniversityName;
            universityInfo.CityId = Guid.Parse(request.CityId);
            universityInfo.Website = request.Website;
            await _universityWriteRepository.SaveAsync();
            return new();
        }
    }
}
