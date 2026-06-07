using Entities.Models;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces
{
    public interface IAuthenticationService
    {
        Task<User> RegisterUser(UserForRegistrationDTO user);
        Task<User> ValidateUser(UserForAuthenticationDTO user);
        Task<TokenDTO> CreateToken(bool populateExp);
        Task<TokenDTO> RefreshToken(TokenDTO token);
    }
}
