using Application.Commands;
using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Handlers
{
    public class DeleteCustomerHandler : IRequestHandler<DeleteCustomerCommand, Unit>
    {
        private readonly IRepositoryContext _repository;
        public DeleteCustomerHandler(IRepositoryContext repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await _repository.Customers.FirstOrDefaultAsync(e => e.Id == request.id);
            if (customer == null)
            {
                throw new Exception("customer not found");
            }
            _repository.Customers.Remove(customer);
            await _repository.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
