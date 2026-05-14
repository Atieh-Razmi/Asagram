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
    public class CreateOverTimeHandler : IRequestHandler<CreateOverTimeCommand, OverTimeResponseDTO>
    {
        private readonly IRepositoryContext _repository;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;
        private readonly ILeaveService _leaveService;
        public CreateOverTimeHandler(IRepositoryContext repository, IMapper mapper, ICurrentUserService currentUserService,
            ILeaveService leaveService)
        {
            _repository = repository;
            _mapper = mapper;
            _currentUserService = currentUserService;
            _leaveService = leaveService;
        }
        public async Task<OverTimeResponseDTO> Handle(CreateOverTimeCommand request, CancellationToken cancellationToken)
        {
            var currentUser = _currentUserService.UserId;
            var user = await _repository.Users
              .Include(u => u.Unit)
              .ThenInclude(u => u.ParentUnit)
              .FirstOrDefaultAsync(u => u.Id == currentUser, cancellationToken);

            var overtime=_mapper.Map<OverTime>(request.overTimeDTO);
            overtime.UserId = currentUser;
            
            _repository.OverTimes.Add(overtime);

            var steps = await _leaveService.GenerateOverTimeStep(overtime);

            foreach (var step in steps)
                overtime.OverTimeSteps.Add(step);

            await _repository.SaveChangesAsync(cancellationToken);
            return _mapper.Map<OverTimeResponseDTO>(overtime);
        }
    }
}
