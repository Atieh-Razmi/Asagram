using Application.Commands;
using Application.Interfaces;
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
    public class CreateCustomerHandler : IRequestHandler<CreateCustomerCommand, Customer>
    {
        private readonly IRepositoryContext _repository;
        private readonly IMapper _mapper;
        public CreateCustomerHandler(IRepositoryContext repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<Customer> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            //var customer = await _repository.Customers.FirstOrDefaultAsync(c => c.Title == request.customerForCreateDTO.Title);

            var customer = _mapper.Map<Customer>(request.customerForCreateDTO);
            _repository.Customers.Add(customer);
            await _repository.SaveChangesAsync(cancellationToken);
            return customer;
        }
    }
}
