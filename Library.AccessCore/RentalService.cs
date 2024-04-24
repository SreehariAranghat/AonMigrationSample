using Autofac;
using CommonUtilityCore;
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

        /*IContextService service;
        public RentalService(IContextService context)
        {
            this.service = context;
        }*/

        public List<Book> GetAvailableBooks()
        {
            return dataAccessService.GetBooks();
        }

        public RentalRecord RentBook(int bookId,int userId)
        {
            //int currentUser = service.GetCurrentUser();
            if(rentalDataAccess.HasPendingReturns(userId))
            {
                throw new Exception("There are still pending books");
            }

            return rentalDataAccess.NewRental(bookId, userId);
        }
    }
}
