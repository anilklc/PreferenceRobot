using MediatR;
using PreferenceRobot.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreferenceRobot.Application.Features.Commands.City.CreateCity
{
    public class CreateCityCommandHandler : IRequestHandler<CreateCityCommandRequest, CreateCityCommandResponse>
    {
        private readonly ICityWriteRepository _cityWriteRepository;

        public CreateCityCommandHandler(ICityWriteRepository cityWriteRepository)
        {
            _cityWriteRepository = cityWriteRepository;
        }

        public async Task<CreateCityCommandResponse> Handle(CreateCityCommandRequest request, CancellationToken cancellationToken)
        {
            await _cityWriteRepository.AddAsync(new()
            {
                CityName = request.CityName
            });
            await _cityWriteRepository.SaveAsync();
            return new();
        }
    }
}
