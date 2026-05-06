using Application.Commands;
using Application.Interfaces;
using AutoMapper;
using Entities.Enums;
using Entities.Models;
using MediatR;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Handlers
{
    public class CreateLeaveHandler : IRequestHandler<CreateLeaveCommand, LeaveResponseDTO>
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryContext _repository;
        public CreateLeaveHandler(IMapper mapper, IRepositoryContext repository)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public async Task<LeaveResponseDTO> Handle(CreateLeaveCommand request, CancellationToken cancellationToken)
        {
            var leave = _mapper.Map<Leave>(request.leaveDTO);
            if (leave.LeaveTime == LeaveTime.Hour)

                leave.Duration = (decimal)(leave.ToDate - leave.FromDate).TotalHours;
            else
                leave.Duration = (decimal)(leave.ToDate - leave.FromDate).TotalDays + 1;

            _repository.Leaves.Add(leave);
            await _repository.SaveChangesAsync(cancellationToken);
            return _mapper.Map<LeaveResponseDTO>(leave);
        }
    }
}
