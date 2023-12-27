using MediatR;
using PreferenceRobot.Application.Features.Commands.City.Rules;
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
        private readonly ICityReadRepository _cityReadRepository;
        private readonly CityRules _cityRules;

        public CreateCityCommandHandler(ICityWriteRepository cityWriteRepository, ICityReadRepository cityReadRepository, CityRules cityRules)
        {
            _cityWriteRepository = cityWriteRepository;
            _cityReadRepository = cityReadRepository;
            _cityRules = cityRules;
        }

        public async Task<CreateCityCommandResponse> Handle(CreateCityCommandRequest request, CancellationToken cancellationToken)
        {
            var cities = _cityReadRepository.GetAll().ToList();
            await _cityRules.CityTitleMustNotBeSame(cities,request.CityName);
            await _cityWriteRepository.AddAsync(new()
            {
                CityName = request.CityName
            });
            await _cityWriteRepository.SaveAsync();
            return new();
        }
    }
}
