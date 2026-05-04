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
    public class UpdateProgramHandler : IRequestHandler<UpdateProgramCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryContext _repository;
        public UpdateProgramHandler(IMapper mapper, IRepositoryContext repository)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public async Task<Unit> Handle(UpdateProgramCommand request, CancellationToken cancellationToken)
        {
            var program = await _repository.Programs.FirstOrDefaultAsync(c => c.Id == request.id);
            if (program == null)
                throw new Exception("program not found.");

            _mapper.Map(request.program, program);
            await _repository.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
