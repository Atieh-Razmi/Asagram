using Application.Commands;
using Application.Interfaces;
using AutoMapper;
using Entities.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Handlers
{
    public class CreateContactHandler : IRequestHandler<CreateContactCommand, Contact>
    {
        private readonly IRepositoryContext _repository;
        private readonly IMapper _mapper;
        public CreateContactHandler(IRepositoryContext repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public async Task<Contact> Handle(CreateContactCommand request, CancellationToken cancellationToken)
        {
            //if contact exist
            var contact = _mapper.Map<Contact>(request.ContactForCreateDTO);
            _repository.Contacts.Add(contact);
            await _repository.SaveChangesAsync(cancellationToken);
            return contact;
        }
    }
}
