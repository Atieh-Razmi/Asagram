using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Exceptions
{
    public class CityNotFoundException :NotFoundException
    {
        public CityNotFoundException():base("شهرستان مورد نظر یافت نشد.")
        {
            
        }
    }
}
