﻿using MediatR;
using PreferenceRobot.Application.Features.Commands.City.Rules;
using PreferenceRobot.Application.Interfaces;
using PreferenceRobot.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreferenceRobot.Application.Features.Commands.City.UpdateCity
{
    public class UpdateCityCommandHandler : IRequestHandler<UpdateCityCommandRequest, UpdateCityCommandResponse>
    {
        private readonly ICityReadRepository _cityReadRepository;
        private readonly ICityWriteRepository _cityWriteRepository;
        private readonly CityRules _cityRules;

        public UpdateCityCommandHandler(ICityWriteRepository cityWriteRepository, ICityReadRepository cityReadRepository, CityRules cityRules)
        {
            _cityWriteRepository = cityWriteRepository;
            _cityReadRepository = cityReadRepository;
            _cityRules = cityRules;
        }

        public async Task<UpdateCityCommandResponse> Handle(UpdateCityCommandRequest request, CancellationToken cancellationToken)
        {
            var cities = _cityReadRepository.GetAll().ToList();
            await _cityRules.CityTitleMustNotBeSame(cities,request.CityName);
            Domain.Entities.City city = await _cityReadRepository.GetByIdAsync(request.Id);
            city.CityName= request.CityName;
            await _cityWriteRepository.SaveAsync();
            return new();
        }
    }
}
