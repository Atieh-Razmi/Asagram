using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Exceptions
{
    public sealed class UserNotFoundException: NotFoundException
    {
        public UserNotFoundException():
            base("نام کاربری یا رمز عبور اشتباه است.")
        {
            
        }
    }
}
