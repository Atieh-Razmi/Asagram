using Application.Interfaces;
using Entities.Exceptions;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using Repository.Extensions;


namespace Service
{
    public class UserService : IUserService
    {
        private readonly RepositoryContext _repository;
        
        public UserService(RepositoryContext repository)
        {
            _repository = repository;

        }

        public async Task<PagedList<User>> GetAllUsersAsync(UserParameters userParameters, bool TrackChanges)
        {
            var query = TrackChanges ? _repository.Users.Include(c => c.UserRoles).ThenInclude(c => c.Role)
                : _repository.Users.Include(c=>c.UserRoles).ThenInclude(c=>c.Role).AsNoTracking();
            query = query.FilterUser(userParameters).Search(userParameters.SearchTerm);
            var count = await query.CountAsync();
            var users = await query.Skip((userParameters.PageNumber - 1) * userParameters.PageSize)
                .Take(userParameters.PageSize)
                .ToListAsync();
            
            return new PagedList<User>(users, count,userParameters.PageNumber, userParameters.PageSize);

        }
        public async Task<User> SetPassword(Guid userId, PasswordDTO passwordDTO)
        {
            if (passwordDTO.NewPassword != passwordDTO.ConfirmNewPassword)
                throw new NotEqualPasswordExeption();

            var user = await _repository.Users.FirstOrDefaultAsync(u=>u.Id == userId);
            if (user == null)
                throw new UserNotFoundException();

            user.Password = HashPassword(passwordDTO.NewPassword);
            await _repository.SaveChangesAsync();
            return user;

        }
        public string HashPassword(string password)
        {
            using var sha = SHA256.Create();
            var bytes = Encoding.UTF8.GetBytes(password);
            return Convert.ToBase64String(sha.ComputeHash(bytes));
        }


        
    }
}
