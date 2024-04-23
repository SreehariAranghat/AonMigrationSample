using Library.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Data.Contracts
{
    public interface IBookAccessService : ICommonDataAccess
    {
        List<Book> GetBooks();
        Book GetBook(int id);

        Book InsertBook(Hashtable book);

        void DeleteBook(int id);
    }
}
