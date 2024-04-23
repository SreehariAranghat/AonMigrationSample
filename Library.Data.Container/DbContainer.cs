using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Autofac.Core;
using Library.Data.Contracts;

namespace Library.Data.Container
{
    public static class DbContainer
    {
        public static IContainer Container { get; private set; }

        static DbContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<UserDataAccess>().As<IUserDataAccess>();
            builder.RegisterType<BookDataAccess>().As<IBookAccessService>();
            builder.RegisterType<RentalDataAccess>().As<IRentalDataAccess>();

            Container = builder.Build(); 
        }
    }
}
