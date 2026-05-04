using Application.Commands;
using Application.Interfaces;
using AutoMapper;
using Entities.Exceptions;
using Entities.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Handlers
{
    public class UpdateUserHandler: IRequestHandler<UpdateUserCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryContext _repository;       
        public UpdateUserHandler(IMapper mapper, IRepositoryContext repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = _repository.Users.FirstOrDefault(u => u.Id == request.Id);

            if (user == null)
                throw new UserNotFoundException();

            _mapper.Map(request.UserForUpdate, user);
            await _repository.SaveChangesAsync(cancellationToken);
            return Unit.Value;
            
        }
    }
}
