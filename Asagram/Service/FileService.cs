using Application.Interfaces;
using Azure.Core;
using Entities.Enums;
using Entities.Models;
using MediatR;
using Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service
{
    public class FileService : IfileService
    {
        private readonly RepositoryContext _repository;

        public FileService(RepositoryContext repository)
        {
            _repository = repository;

        }

        public async Task<(Guid Id, string Name)> UploadFile(string Name, string ContentType, byte[] Data, FileType fileType)
        {
            var fileEntity = new AppFile
            {
                Id = Guid.NewGuid(),
                Name = Name,
                ContentType = ContentType,
                Data = Data,
                FileType = fileType
            };



            _repository.AppFiles.Add(fileEntity);
            await _repository.SaveChangesAsync();

            return (fileEntity.Id, fileEntity.Name);

        }
    }
}
