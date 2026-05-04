using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Exceptions
{
    public class NotActiveUserException : NotFoundException
    {
        public NotActiveUserException() : base("کاربر غیر فعال است.")
        {
            
        }
    }
}
