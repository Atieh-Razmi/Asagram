using Application.Commands;
using Application.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Handlers
{
    public record UpdateContactHandler : IRequestHandler<UpdateContactCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryContext _repository;
        public UpdateContactHandler(IMapper mapper, IRepositoryContext repository)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public async Task<Unit> Handle(UpdateContactCommand request, CancellationToken cancellationToken)
        {
            var contact = await _repository.Contacts.Include(x => x.PhoneNumbers).FirstOrDefaultAsync(c => c.Id == request.id);
            if (contact == null)
                throw new Exception("contact not found.");
            _mapper.Map(request.contact, contact);
            await _repository.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
