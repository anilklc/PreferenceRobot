using MediatR;
using PreferenceRobot.Application.Interfaces.Repositories.University;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreferenceRobot.Application.Features.Commands.University.RemoveUniversity
{
    public class RemoveUniversityCommandHandler : IRequestHandler<RemoveUniversityCommandRequest, RemoveUniversityCommandResponse>
    {
        private readonly IUniversityWriteRepository _universityWriteRepository;

        public RemoveUniversityCommandHandler(IUniversityWriteRepository universityWriteRepository)
        {
            _universityWriteRepository = universityWriteRepository;
        }

        public async Task<RemoveUniversityCommandResponse> Handle(RemoveUniversityCommandRequest request, CancellationToken cancellationToken)
        {
            await _universityWriteRepository.RemoveAsync(request.Id);
            await _universityWriteRepository.SaveAsync();
            return new();
        }
    }
}
