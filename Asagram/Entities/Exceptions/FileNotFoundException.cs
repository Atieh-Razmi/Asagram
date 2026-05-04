using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Exceptions
{
    public class FileNotFoundException : NotFoundException
    {
        public FileNotFoundException() : base("فایل یافت نشد.")
        {
            
        }
    }
}
