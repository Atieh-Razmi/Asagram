using Application.Interfaces;
using Entities.Exceptions;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Update.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Repository;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;



namespace Asagram.Service
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly RepositoryContext _repository;
        private readonly IConfiguration _configuration;

        private User? _user;

        public AuthenticationService(RepositoryContext repository, IConfiguration configuration)
        {
            _configuration = configuration;
            _repository = repository;
        }


        public async Task<User> ValidateUser(UserForAuthenticationDTO user)
        {
            _user = await _repository.Users.Include(u => u.UserRoles)
                    .ThenInclude(ur => ur.Role)
                    .FirstOrDefaultAsync(u => u.UserName == user.UserName);
            if (_user == null)
            {
                throw new UserNotFoundException();
            }
            if (!VerifyPassword(user.Password, _user.Password))
                throw new UserNotFoundException();

            return _user;

        }

        private bool VerifyPassword(string password, string storedPassword)
        {
            var hash = HashPassword(password);
            return hash == storedPassword;
        }

        private string HashPassword(string password)
        {
            using var sha = SHA256.Create();
            var bytes = Encoding.UTF8.GetBytes(password);
            return Convert.ToBase64String(sha.ComputeHash(bytes));
        }


        public async Task<TokenDTO> CreateToken(bool populateExp)
        {
            if (_user == null)
                throw new UserNotFoundException();

            if (_user.IsActive == false)
                throw new NotActiveUserException();

            var signingCredentials = GetSigningCredentials();
            var claims = await GetClaims();
            var tokenOptions = GenerateTokenOptions(signingCredentials, claims);

            var refreshToken = GenerateRefreshToken();

            _user.RefreshToken = refreshToken;

            if (populateExp)
                _user.RefreshTokenExpiryTime = DateTime.Now.AddDays(7);

            await _repository.SaveChangesAsync();

            var accessToken = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
            return new TokenDTO(accessToken, refreshToken);

        }

        private SigningCredentials GetSigningCredentials()
        {
            var key = Encoding.UTF8.GetBytes(_configuration["JWT:Key"]);
            var secret = new SymmetricSecurityKey(key);
            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }

        private async Task<List<Claim>> GetClaims()
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, _user.UserName),
                new Claim(ClaimTypes.NameIdentifier, _user.Id.ToString())
            };

            foreach (var role in _user.UserRoles.Select(x => x.Role.RoleName))
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            return claims;

        }

        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
        {
            var jwtSettings = _configuration.GetSection("JWT");
            var tokenOptions = new JwtSecurityToken
                (
                    issuer: jwtSettings["validIssuer"],
                    audience: jwtSettings["validAudience"],
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(Convert.ToDouble(jwtSettings["expires"])),
                    signingCredentials: signingCredentials
                );
            return tokenOptions;

        }

        private string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }

        private ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {
            var jwtSettings = _configuration.GetSection("JWT");

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = true,
                ValidateIssuer = true,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(_configuration["JWT:Key"])),
                ValidateLifetime = true,
                ValidIssuer = jwtSettings["validIssuer"],
                ValidAudience = jwtSettings["validAudience"]
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken;
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out securityToken);

            var jwtSecurityToken = securityToken as JwtSecurityToken;
            if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256,
                StringComparison.InvariantCultureIgnoreCase))
            {
                throw new SecurityTokenException("Invalid token");
            }

            return principal;
        }

        //public async Task<TokenDTO> RefreshToken(TokenDTO tokenDto)
        //{
        //    var principal = GetPrincipalFromExpiredToken(tokenDto.AccessToken);

        //    var username = principal.Identity.Name;

        //    var user = await _repository.Users.FirstOrDefaultAsync(x => x.UserName == username);

        //    if (user == null ||
        //        user.RefreshToken != tokenDto.RefreshToken ||
        //        user.RefreshTokenExpiryTime <= DateTime.Now)
        //    {
        //        throw new Exception("Invalid refresh token");
        //    }

        //    _user = user;
        //    return await CreateToken(populateExp: false);
        //}

        public async Task<TokenDTO> RefreshToken(TokenDTO tokenDto)
        {
            var principal = GetPrincipalFromExpiredToken(tokenDto.AccessToken);

            var username = principal.Identity?.Name;

            if (string.IsNullOrWhiteSpace(username))
                throw new Exception("Invalid access token");

            var user = await _repository.Users
                .Include(u => u.UserRoles)
                .ThenInclude(ur => ur.Role)
                .FirstOrDefaultAsync(x => x.UserName == username);

            if (user == null ||
                user.RefreshToken != tokenDto.RefreshToken ||
                user.RefreshTokenExpiryTime <= DateTime.Now)
            {
                throw new Exception("Invalid refresh token");
            }

            _user = user;

            return await CreateToken(populateExp: false);
        }

        public async Task<UserForRegistrationDTO> RegisterUser(UserForRegistrationDTO user)
        {
            var registerUser = await _repository.Users.FirstOrDefaultAsync(u => u.UserName == user.UserName);
            if (registerUser != null)
                throw new UserNotFoundException();

            if (user.Password != user.ConfirmPassword)
                throw new NotEqualPasswordExeption();

            var hashPassword = HashPassword(user.Password);

            var newUser = new User
            {
                Id = Guid.NewGuid(),
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
                PhoneNumber = user.PhoneNumber,
                NationalCode = user.NationalCode,
                Password = hashPassword,
                UserUnit = user.UserUnit,
                Gender = user.Gender
            };
            //user.Id = newUser.Id;
            _repository.Users.Add(newUser);
            await _repository.SaveChangesAsync();

            var role = await _repository.Roles.FirstOrDefaultAsync(u=> u.RoleName == user.RoleName);
            if (role == null)
                throw new Exception("Invalid role name.");


            _repository.UserRoles.Add(new UserRole
            {
                UserId = newUser.Id,
                RoleId = role.Id
            });
            await _repository.SaveChangesAsync();


            return user;
        }
        
    }
}
