using Application.Interfaces;
using Application.Queries;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Text;
using Entities.Enums;

namespace Application.Handlers
{
    public class GetInvoicesHandler : IRequestHandler<GetInvoicesQuery, IEnumerable<UploadFileResponseDTO>>
    {
        private readonly IRepositoryContext _repository;
        private readonly IMapper _mapper;
        public GetInvoicesHandler(IRepositoryContext repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;   
        }

        public async Task<IEnumerable<UploadFileResponseDTO>> Handle(GetInvoicesQuery request, CancellationToken cancellationToken)
        {
            var invoices = await _repository.AppFiles.Where(e => e.FileType == FileType.Invoice)
                .ToListAsync(cancellationToken);
            var invoicedtos = _mapper.Map<IEnumerable<UploadFileResponseDTO>>(invoices);
            return invoicedtos;
        }
    }
}
