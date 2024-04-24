using Autofac;
using Library.Bussiness.Contracts;
using Library.Data.Container;
using Library.Data.Contracts;
using Library.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;
using CommonUtility;

namespace Library.Access
{
    public class FormAutenticationService : IAuthService
    {
        IUserDataAccess dataAccessService = DbContainer
                                                .Container
                                                .Resolve<IUserDataAccess>();
        public User Login(string email, string password)
        {
            CommonUtility.Log.Info($"Attempt to login with {email} and {password}");

           var user = dataAccessService.GetUserByEmail(email);

            if (user == null || user.Password != password)
            {
                CommonUtility.Log.Error($"Authentication failed for user {email}");
                throw new AuthenticationException();
            }

            return user;
        }
    }
}
