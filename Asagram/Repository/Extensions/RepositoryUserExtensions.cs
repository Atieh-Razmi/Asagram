using Entities.Models;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Extensions
{
    public static class RepositoryUserExtensions
    {
        public static IQueryable<User> Search(this IQueryable<User> users, string seachTerm)
        {
            if (string.IsNullOrWhiteSpace(seachTerm))
                return users;

            var lowerCaseTerm = seachTerm.Trim().ToLower();
            return users.Where(e => e.FirstName.ToLower().Contains(lowerCaseTerm) ||
                                    e.LastName.ToLower().Contains(lowerCaseTerm) ||
                                    e.UserName.ToLower().Contains(lowerCaseTerm) ||
                                    e.PhoneNumber.ToLower().Contains(lowerCaseTerm) ||
                                    e.NationalCode.ToLower().Contains(lowerCaseTerm)
                                    );
        }

        public static IQueryable<User> FilterUser(this IQueryable<User> users, UserParameters parameters)
        {
            if (parameters.IsActive.HasValue)
            {
                users = users.Where(e => e.IsActive == parameters.IsActive);
            }

            if (parameters.Status.HasValue)
            {
                users = users.Where(e => e.Status == parameters.Status);
            }

            if(!string.IsNullOrWhiteSpace(parameters.Role))
            {
                users = users.Where(e => e.UserRoles.Any(r => r.Role.RoleName == parameters.Role));
            }
            return users;
        }
    }
}
