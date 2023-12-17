using MediatR;
using PreferenceRobot.Application.Interfaces.Repositories.University;
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
        public CreateUniversityCommandHandler(IUniversityWriteRepository universityWriteRepository)
        {
                _universityWriteRepository = universityWriteRepository;
        }
        public async Task<CreateUniversityCommandResponse> Handle(CreateUniversityCommandRequest request, CancellationToken cancellationToken)
        {
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
