using Application.Commands;
using Application.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Handlers
{
    public class UpdateUnitHandler : IRequestHandler<UpdateUnitCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryContext _repository;
        public UpdateUnitHandler(IMapper mapper, IRepositoryContext repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateUnitCommand request, CancellationToken cancellationToken)
        {
            var unit = await _repository.Units.FirstOrDefaultAsync(c => c.Id == request.id);
            if (unit == null)
                throw new Exception("unit not found.");

            _mapper.Map<Entities.Models.Unit>(request.unitDTO);
            await _repository.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
