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
    public class UploadFileInvoiceHandler : IRequestHandler<UploadFileInvoiceCommand, UploadFileResponseDTO>
    {
        
        private readonly IfileService _fileService;
        public UploadFileInvoiceHandler( IfileService fileService)
        {
            
            _fileService = fileService;
        }
        public async Task<UploadFileResponseDTO> Handle(UploadFileInvoiceCommand request, CancellationToken cancellationToken)
        {
            var result = await _fileService.UploadFile(request.Name, request.ContentType, request.Data, request.FileType);

            return new UploadFileResponseDTO
            {
                Id = result.Id,
                Name = result.Name
            };
        }
    }
}
