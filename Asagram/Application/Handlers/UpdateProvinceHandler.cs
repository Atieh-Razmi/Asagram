using Application.Commands;
using Application.Interfaces;
using AutoMapper;
using Entities.Exceptions;
using Entities.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Handlers
{
    public class UpdateProvinceHandler : IRequestHandler<UpdateProvinceCommand, Unit>
    {
        private readonly IRepositoryContext _repository;
        private readonly IMapper _mapper;
        public UpdateProvinceHandler(IRepositoryContext repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateProvinceCommand request, CancellationToken cancellationToken)
        {
            var province = await _repository.Provinces.FirstOrDefaultAsync(c => c.Id == request.id);
            if (province == null)
                throw new ProvinceNotFoundException();

            _mapper.Map(request.ProvinceDTO, province);
            await _repository.SaveChangesAsync(cancellationToken);
            return Unit.Value;

        }
    }
}
