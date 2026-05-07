using Application.Commands;
using Application.Interfaces;
using AutoMapper;
using Entities.Models;
using MediatR;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Handlers
{
    public class CreateOverTimeHandler : IRequestHandler<CreateOverTimeCommand, OverTimeResponseDTO>
    {
        private readonly IRepositoryContext _repository;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;
        public CreateOverTimeHandler(IRepositoryContext repository, IMapper mapper, ICurrentUserService currentUserService)
        {
            _repository = repository;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }
        public async Task<OverTimeResponseDTO> Handle(CreateOverTimeCommand request, CancellationToken cancellationToken)
        {
            var overtime=_mapper.Map<OverTime>(request.overTimeDTO);
            overtime.UserId = _currentUserService.UserId;
            //overtime.UserId = Guid.Parse("9ac62c1a-52f5-49d9-b27e-3725095cef2a");
            _repository.OverTimes.Add(overtime);
            await _repository.SaveChangesAsync(cancellationToken);
            return _mapper.Map<OverTimeResponseDTO>(overtime);
        }
    }
}
