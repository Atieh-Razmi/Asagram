using Entities.Models;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces
{
    public interface IUserService
    {
        Task<PagedList<User>> GetAllUsersAsync(UserParameters userParameters, bool TrackChanges);
        Task<User> SetPassword(Guid userId, PasswordDTO passwordDTO);
        

    }
}
