using Application.Commands;
using Application.Interfaces;
using MediatR;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Handlers
{
    public class UploadFileCommunicationHandler : IRequestHandler<UploadFileCommunicationCommand, UploadFileResponseDTO>
    {
        private readonly IfileService _fileService;
        public UploadFileCommunicationHandler(IfileService fileService)
        {

            _fileService = fileService;
        }
        public async Task<UploadFileResponseDTO> Handle(UploadFileCommunicationCommand request, CancellationToken cancellationToken)
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
