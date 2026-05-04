using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Exceptions
{
    public class ProvinceNotFoundException:NotFoundException
    {
        public ProvinceNotFoundException():base("استان مورد نظر یافت نشد.")
        {
            
        }
    }
}
