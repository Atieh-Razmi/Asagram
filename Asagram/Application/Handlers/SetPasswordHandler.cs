using Application.Commands;
using Application.Interfaces;
using AutoMapper;
using MediatR;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Handlers
{
    public class SetPasswordHandler : IRequestHandler<SetPasswordCommand, UserPasswordDTO>
    {
        private readonly IUserService _service;
        private readonly IMapper _mapper;

        public SetPasswordHandler(IUserService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task<UserPasswordDTO> Handle(SetPasswordCommand request, CancellationToken cancellationToken)
        {
            var updatePassword = await _service.SetPassword(request.UserId, request.PasswordDTO);
            var userPasswordDTO = _mapper.Map<UserPasswordDTO>(updatePassword);
            return userPasswordDTO;
            
        }
    }
}
