using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Exceptions
{
    public sealed class NotEqualPasswordExeption: NotFoundException
    {
        public NotEqualPasswordExeption() : base("کلمه عبور و تکرار کلمه عبور یکسان نیستند.")
        {
            
        }
    }
}
