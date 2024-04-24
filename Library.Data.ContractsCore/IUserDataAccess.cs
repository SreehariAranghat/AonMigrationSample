using Library.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Data.Contracts
{
    public interface IUserDataAccess : ICommonDataAccess
    {
        List<User> GetUsers();

        User GetUserByEmail(string email);

        User InsertUser(Hashtable user);

        void DeleteUser(int id);
    }
}
