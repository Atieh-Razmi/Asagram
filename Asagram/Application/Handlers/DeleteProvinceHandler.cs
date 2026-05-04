using Application.Commands;
using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Handlers
{
    public class DeleteProvinceHandler : IRequestHandler<DeleteProvinceCommand>
    {
        private readonly IRepositoryContext _repository;
        public DeleteProvinceHandler(IRepositoryContext repository)
        {
            _repository = repository;
        }
        public async Task<Unit> Handle(DeleteProvinceCommand request, CancellationToken cancellationToken)
        {
            var province = await _repository.Provinces.FirstOrDefaultAsync(c => c.Id == request.id);
            if (province == null)
                throw new Exception();

            _repository.Provinces.Remove(province);
            await _repository.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
