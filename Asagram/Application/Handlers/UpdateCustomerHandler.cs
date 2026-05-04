using Application.Commands;
using Application.Interfaces;
using AutoMapper;
using Entities.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Handlers
{
    public class UpdateCustomerHandler : IRequestHandler<UpdateCustomerCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryContext _repository;
        public UpdateCustomerHandler(IMapper mapper, IRepositoryContext repository)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public async Task<Unit> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await _repository.Customers.Include(x=>x.PhoneNumbers).FirstOrDefaultAsync(c => c.Id == request.id);
            if (customer == null)
                throw new Exception("customer not found.");
            _mapper.Map(request.customer, customer);
            await _repository.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
