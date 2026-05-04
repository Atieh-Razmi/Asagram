using Application.Commands;
using Application.Interfaces;
using AutoMapper;
using Entities.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Handlers
{
    public class CreateProgramHandler : IRequestHandler<CreateProgramCommand, ProgramResponseDTO>
    {
        private readonly IRepositoryContext _repository;
        private readonly IMapper _mapper;
        public CreateProgramHandler(IRepositoryContext repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<ProgramResponseDTO> Handle(CreateProgramCommand request, CancellationToken cancellationToken)
        {
            var program = await _repository.Programs.FirstOrDefaultAsync(c => c.Title == request.program.Title);

            if (program != null)
                throw new Exception("program duplicate.");

           var result = _mapper.Map<ProgramEntity>(request.program);

            _repository.Programs.Add(result);
            await _repository.SaveChangesAsync();

            return _mapper.Map<ProgramResponseDTO>(result);
        }
    }
}
