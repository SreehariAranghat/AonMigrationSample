using Library.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Bussiness.Contracts
{
    public interface IUserService
    {
        List<User> GetActiveUsers();

        User AddUser(Hashtable userData);
    }
}
