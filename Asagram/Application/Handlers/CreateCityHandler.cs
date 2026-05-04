using Application.Commands;
using Application.Interfaces;
using AutoMapper;
using Entities.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Handlers
{
    public class CreateCityHandler : IRequestHandler<CreateCityCommand, Unit>
    {
        private readonly IRepositoryContext _repository;
        private readonly IMapper _mapper;

        public CreateCityHandler(IRepositoryContext repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(CreateCityCommand request, CancellationToken cancellationToken)
        {
            //var province = await _repository.Provinces.FirstOrDefaultAsync(e => e.Id == request.cityDTO.ProvinceId);
            //if (province == null)
            //    throw new Exception();

            var city = await _repository.Cities.FirstOrDefaultAsync(c => c.Name == request.cityDTO.Name
                    && c.ProvinceId == request.cityDTO.ProvinceId);
            if (city != null)
            {
                throw new Exception();
            }
            
            city = _mapper.Map<City>(request.cityDTO);
            await _repository.Cities.AddAsync(city);
            await _repository.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }

       
    }
}
