using Application.Commands;
using Application.Interfaces;
using AutoMapper;
using Entities.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Handlers
{
    public class DeleteCityHandler: IRequestHandler<DeleteCityCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryContext _repository;
        public DeleteCityHandler(IMapper mapper, IRepositoryContext repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteCityCommand request, CancellationToken cancellationToken)
        {
            var city = await _repository.Cities.FirstOrDefaultAsync(e => e.Id == request.id);
            if (city == null)
                throw new CityNotFoundException();
            _repository.Cities.Remove(city);
            await _repository.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
