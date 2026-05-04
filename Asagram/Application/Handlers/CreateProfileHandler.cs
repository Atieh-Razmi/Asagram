using Application.Commands;
using Application.Interfaces;
using AutoMapper;
using Entities.Enums;
using Entities.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Application.Handlers
{
    public class CreateProfileHandler : IRequestHandler<CreateProfileCommand, ProfileDTO>
    {
        private readonly IRepositoryContext _repository;
        private readonly IMapper _mapper;
        
        public CreateProfileHandler(IRepositoryContext repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
            
        }
        public async Task<ProfileDTO> Handle(CreateProfileCommand request, CancellationToken cancellationToken)
        {
            var user = await _repository.Users.FirstOrDefaultAsync(c => c.Id == request.id);
             _mapper.Map(request.profile, user);

            //_repository.Users.Add(user);
            
            await _repository.SaveChangesAsync(cancellationToken);
            return _mapper.Map<ProfileDTO>(user);
        }
    }
}
