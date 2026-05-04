using Application.Interfaces;
using Application.Queries;
using AutoMapper;
using Entities.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Handlers
{
    public class GetUserHandler : IRequestHandler<GetUserQuery, UserForUpdateDTO>
    {
        private readonly IRepositoryContext _repository;
        private readonly IMapper _mapper;
        public GetUserHandler(IRepositoryContext repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<UserForUpdateDTO> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _repository.Users.FirstOrDefaultAsync(c => c.Id == request.Id);
            if(user == null)
            {
                throw new Exception("user not found.");
            }
            var userDTO = _mapper.Map<UserForUpdateDTO>(user);
            return userDTO;
        }
    }
}
