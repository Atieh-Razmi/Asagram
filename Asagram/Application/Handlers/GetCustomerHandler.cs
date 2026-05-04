using Application.Interfaces;
using Application.Queries;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Handlers
{
    public class GetCustomerHandler : IRequestHandler<GetCustomerQuery, CustomerDTO>
    {
        private readonly IRepositoryContext _repository;
        private readonly IMapper _mapper;
        public GetCustomerHandler(IRepositoryContext repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public async Task<CustomerDTO> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
        {
            var customer = await _repository.Customers.Include(c => c.PhoneNumbers)
                .FirstOrDefaultAsync(x => x.Id == request.id);
            var customerdto = _mapper.Map<CustomerDTO>(customer);
            return customerdto;
        }
    }
}
