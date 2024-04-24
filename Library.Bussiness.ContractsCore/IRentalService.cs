using Library.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Bussiness.Contracts
{
    public interface IRentalService
    {
        RentalRecord RentBook(int bookId,int userId);

        List<Book> GetAvailableBooks();
    }
}
