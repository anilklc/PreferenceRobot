using MediatR;
using PreferenceRobot.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreferenceRobot.Application.Features.Commands.City.RemoveCity
{
    public class RemoveCityCommandHandler : IRequestHandler<RemoveCityCommandRequest, RemoveCityCommandResponse>
    {
        private readonly ICityWriteRepository _cityWriteRepository;

        public RemoveCityCommandHandler(ICityWriteRepository cityWriteRepository)
        {
            _cityWriteRepository = cityWriteRepository;
        }

        public async Task<RemoveCityCommandResponse> Handle(RemoveCityCommandRequest request, CancellationToken cancellationToken)
        {
            await _cityWriteRepository.RemoveAsync(request.Id);
            await _cityWriteRepository.SaveAsync();
            return new();
        }
    }
}
