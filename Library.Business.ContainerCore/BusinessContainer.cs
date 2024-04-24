using Autofac;
using Library.Access;
using Library.Bussiness.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Business.Container
{
    public static class BusinessContainer
    {
        public static IContainer Container { get; private set; }

        static BusinessContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<FormAutenticationService>().As<IAuthService>();
            builder.RegisterType<UserService>().As<IUserService>();
            builder.RegisterType<RentalService>().As<IRentalService>();

            Container = builder.Build();
        }
    }
}
