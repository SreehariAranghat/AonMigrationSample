using Autofac;
using Library.Business.Container;
using Library.Bussiness.Contracts;
using Library.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LibaryApi.Controllers
{
    public class BooksController : ApiController
    {
        IRentalService rentalService = BusinessContainer.Container.Resolve<IRentalService>();

        public IList<Book> Get()
        {
            var books = rentalService.GetAvailableBooks();
            return books;
        }
    }
}
