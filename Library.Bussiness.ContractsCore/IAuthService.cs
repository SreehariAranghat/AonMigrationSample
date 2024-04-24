using Library.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Bussiness.Contracts
{
    public interface IAuthService
    {
        User Login(string email, string password); 
    }
}
