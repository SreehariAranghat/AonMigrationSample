using Autofac;
using Library.Bussiness.Contracts;
using Library.Data.Container;
using Library.Data.Contracts;
using Library.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Library.Access
{
    public class RentalService : IRentalService
    {
        IBookAccessService dataAccessService = DbContainer
                                             .Container
                                             .Resolve<IBookAccessService>();

        IRentalDataAccess rentalDataAccess = DbContainer.Container.Resolve<IRentalDataAccess>();


       
        public List<Book> GetAvailableBooks()
        {
            return dataAccessService.GetBooks();
        }

        public RentalRecord RentBook(int bookId,int userId)
        {
            if(rentalDataAccess.HasPendingReturns(userId))
            {
                throw new Exception("There are still pending books");
            }

            return rentalDataAccess.NewRental(bookId, userId);
        }
    }
}
