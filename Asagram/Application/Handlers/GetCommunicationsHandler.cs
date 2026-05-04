using Application.Interfaces;
using Application.Queries;
using MediatR;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Text;
using Entities.Enums;


using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace Application.Handlers
{
    public class GetCommunicationsHandler : IRequestHandler<GetCommunicationsQuery, IEnumerable<UploadFileResponseDTO>>
    {
        private readonly IRepositoryContext _repository;
        private readonly IMapper _mapper;

        public GetCommunicationsHandler(IRepositoryContext repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<UploadFileResponseDTO>> Handle(GetCommunicationsQuery request, CancellationToken cancellationToken)
        {
            var communications = await _repository.AppFiles.Where(e => e.FileType == FileType.Communication)
                .ToListAsync(cancellationToken);

            var communicationDTOs = _mapper.Map<IEnumerable<UploadFileResponseDTO>>(communications);
            return communicationDTOs;
        }
    }
}
