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
    public class CreateReportHandler : IRequestHandler<CreateReportCommand, ReportForCreateDTO>
    {
        private readonly IRepositoryContext _repository;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;
        public CreateReportHandler(IMapper mapper, IRepositoryContext repository, ICurrentUserService currentUserService)
        {
            _repository = repository;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }

        public async Task<ReportForCreateDTO> Handle(CreateReportCommand request, CancellationToken cancellationToken)
        {
            var userId = _currentUserService.UserId;
            var report = _mapper.Map<Report>(request.reportDTO);
            report.UserId = userId;
            _repository.Reports.Add(report);
            await _repository.SaveChangesAsync(cancellationToken);
            return _mapper.Map<ReportForCreateDTO>(report);
        }
    }
}
