using Autofac;
using Library.Business.Container;
using Library.Bussiness.Contracts;
using Library.Data.Contracts;
using Library.WebApp.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Library.WebApp.Controllers
{
    [LibAuthFilter]
    public class HomeController : Controller
    {
        IRentalService rentalService = BusinessContainer.Container.Resolve<IRentalService>(); 
        public ActionResult Index()
        {
            var books = rentalService.GetAvailableBooks();
            return View(books);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}