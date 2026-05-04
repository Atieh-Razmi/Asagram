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
    public class GetContactsHandler : IRequestHandler<GetContactsQuery, IEnumerable<ContactDTO>>
    {
        private readonly IRepositoryContext _repository;
        private readonly IMapper _mapper;
        public GetContactsHandler(IRepositoryContext repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public async Task<IEnumerable<ContactDTO>> Handle(GetContactsQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.Contacts.Include(c => c.PhoneNumbers)
                .ToListAsync(cancellationToken);
            var contactsDTO = _mapper.Map<IEnumerable<ContactDTO>>(result);
            return contactsDTO;
        }
    }
}
