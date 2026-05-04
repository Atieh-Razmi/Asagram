using Application.Commands;
using Application.Interfaces;
using AutoMapper;
using Entities.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Handlers
{
    public class CreateProfileImageHandler : IRequestHandler<CreateProfileImageCommand, Unit>
    {
        private readonly IRepositoryContext _repository;
        private readonly IMapper _mapper;
        private readonly IfileService _fileService;
        public CreateProfileImageHandler(IRepositoryContext repository, IMapper mapper, IfileService fileService)
        {
            _repository = repository;
            _mapper = mapper;
            _fileService = fileService;
        }
        public async Task<Unit> Handle(CreateProfileImageCommand request, CancellationToken cancellationToken)
        {
            var user = await _repository.Users.FirstOrDefaultAsync(c => c.Id == request.id);
            
            if (request.uploadImage.File != null)
            {
                using var ms = new MemoryStream();
                await request.uploadImage.File.CopyToAsync(ms);


                var file = await _fileService.UploadFile(request.uploadImage.File.FileName, request.uploadImage.File.ContentType,
                    ms.ToArray(), FileType.ProfileImage);

                user.ProfileImageId = file.Id;
            }

            await _repository.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
