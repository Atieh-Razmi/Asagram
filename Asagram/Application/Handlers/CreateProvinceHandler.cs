using Application.Commands;
using Application.Interfaces;
using AutoMapper;
using Entities.Exceptions;
using Entities.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Handlers
{
    public class CreateProvinceHandler: IRequestHandler<CreateProvinceCommand, MediatR.Unit>
    {
        private readonly IRepositoryContext _repository;
        private readonly IMapper _mapper;
        public CreateProvinceHandler(IRepositoryContext repository, IMapper mapper)
        {
         _repository = repository;
            _mapper = mapper;   
        }

        public async Task<MediatR.Unit> Handle(CreateProvinceCommand request, CancellationToken cancellationToken)
        {
            var provinse = await _repository.Provinces.FirstOrDefaultAsync(c => c.Name == request.provinceDTO.Name);
            if(provinse != null)
            {
                throw new ProvinceExistException();
            }
            var province = _mapper.Map<Province>(request.provinceDTO);
            _repository.Provinces.Add(province);
            await _repository.SaveChangesAsync(cancellationToken);
            return MediatR.Unit.Value;
        }
    }
}
