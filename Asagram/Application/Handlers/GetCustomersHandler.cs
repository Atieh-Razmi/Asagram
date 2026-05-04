
using Application.Interfaces;
using Application.Queries;
using AutoMapper;
using Entities.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Handlers
{
    public class GetCustomersHandler : IRequestHandler<GetCustomersQuery,IEnumerable<CustomerDTO>>
    {
        private readonly IRepositoryContext _repository;
        private readonly IMapper _mapper;
        public GetCustomersHandler(IRepositoryContext repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CustomerDTO>> Handle(GetCustomersQuery request, CancellationToken cancellationToken)
        {
            var customers = await _repository.Customers.Include(c=>c.PhoneNumbers).ToListAsync(cancellationToken);
            var customerdto = _mapper.Map<IEnumerable<CustomerDTO>>(customers);
            return customerdto;
        }
    }
}
