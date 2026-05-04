using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Exceptions
{
    public class BankNotFoundExeception : NotFoundException
    {
        public BankNotFoundExeception() : base("حساب بانکی یافت نشد.")
        {
            
        }
    }
}
