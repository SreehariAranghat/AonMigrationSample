using Autofac;
using Library.Bussiness.Contracts;
using Library.Data.Container;
using Library.Data.Contracts;
using Library.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Access
{
    public class UserService : IUserService
    {
        IUserDataAccess dataAccessService = DbContainer
                                              .Container
                                              .Resolve<IUserDataAccess>();

        public User AddUser(Hashtable userData)
        {
            var email = (string)userData["Email"];
            if (dataAccessService.Exist(email))
             {
                CommonUtility.Log.Error($"Email {email} already exist");
                throw new Exception($"User with the same email address exist {email}");
             }

            return dataAccessService.InsertUser(userData);
        }

        public List<User> GetActiveUsers()
        {
            return dataAccessService.GetUsers();
        }
    }
}
