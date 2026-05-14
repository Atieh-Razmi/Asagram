using Application.Commands;
using Application.Interfaces;
using AutoMapper;
using Entities.Enums;
using Entities.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Application.Handlers
{
    public class CreateLeaveHandler : IRequestHandler<CreateLeaveCommand, LeaveResponseDTO>
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryContext _repository;
        private readonly ILeaveService _leaveService;
        private readonly ICurrentUserService _currentUserService;
        public CreateLeaveHandler(IMapper mapper, IRepositoryContext repository, ILeaveService leaveService,
            ICurrentUserService currentUserService)
        {
            _mapper = mapper;
            _repository = repository;
            _leaveService = leaveService;
            _currentUserService = currentUserService;
        }
        public async Task<LeaveResponseDTO> Handle(CreateLeaveCommand request, CancellationToken cancellationToken)
        {
            var currentUser = _currentUserService.UserId;
            var user = await _repository.Users
               .Include(u => u.Unit)
               .ThenInclude(u => u.ParentUnit)
               .FirstOrDefaultAsync(u => u.Id == currentUser, cancellationToken);

            var leave = _mapper.Map<Leave>(request.leaveDTO);
            leave.UserId = currentUser;
            

            if (leave.LeaveTime == LeaveTime.Hour)

                leave.Duration = (decimal)(leave.ToDate - leave.FromDate).TotalHours;
            else
                leave.Duration = (decimal)(leave.ToDate - leave.FromDate).TotalDays + 1;

            _repository.Leaves.Add(leave);

            var steps = await _leaveService.GenerateLeaveStep(leave);

            foreach (var step in steps)
                leave.LeaveSteps.Add(step);




            await _repository.SaveChangesAsync(cancellationToken);
            return _mapper.Map<LeaveResponseDTO>(leave);
        }
    }
}
