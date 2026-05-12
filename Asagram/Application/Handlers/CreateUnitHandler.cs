using Application.Commands;
using Application.Interfaces;
using AutoMapper;
using Entities.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

//using Entities.Models;

namespace Application.Handlers
{
    public class CreateUnitHandler : IRequestHandler<CreateUnitCommand, Entities.Models.Unit>
    {
        private readonly IRepositoryContext _repository;
        private readonly IMapper _mapper;

        public CreateUnitHandler(IRepositoryContext repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;

        }
        public async Task<Entities.Models.Unit> Handle(CreateUnitCommand request, CancellationToken cancellationToken)
        {
            var unit = _mapper.Map<Entities.Models.Unit>(request.unit);
            _repository.Units.Add(unit);
            await _repository.SaveChangesAsync(cancellationToken);
            return unit;
        }
    }
}
