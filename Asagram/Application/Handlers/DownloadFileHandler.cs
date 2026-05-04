using Application.Interfaces;
using Application.Queries;
using Entities.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Handlers
{
    public class DownloadFileHandler : IRequestHandler<DownloadFileQuery, AppFile>
    {
        private readonly IRepositoryContext _repository;
        public DownloadFileHandler(IRepositoryContext repository)
        {
            _repository = repository;
        }
        public async Task<AppFile> Handle(DownloadFileQuery request, CancellationToken cancellationToken)
        {
            var file = await _repository.AppFiles.FirstOrDefaultAsync(e => e.Id == request.id, cancellationToken);
            return file;
        }
    }
}
