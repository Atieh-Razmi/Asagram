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
    public class GetContactHandler : IRequestHandler<GetContactQuery, ContactDTO>
    {
        private readonly IRepositoryContext _repository;
        private readonly IMapper _mapper;
        public GetContactHandler(IRepositoryContext repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public async Task<ContactDTO> Handle(GetContactQuery request, CancellationToken cancellationToken)
        {
            var contact = await _repository.Contacts.Include(c => c.PhoneNumbers)
                .FirstOrDefaultAsync(c => c.Id == request.id);
            return _mapper.Map<ContactDTO>(contact);
        }
    }
}
