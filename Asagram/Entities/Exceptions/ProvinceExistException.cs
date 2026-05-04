using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Exceptions
{
    public class ProvinceExistException : NotFoundException
    {
        public ProvinceExistException() : base("استان وجود دارد.")
        {
            
        }
    }
}
