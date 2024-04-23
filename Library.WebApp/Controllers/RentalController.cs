using Autofac;
using Library.Business.Container;
using Library.Bussiness.Contracts;
using Library.Entities;
using Library.WebApp.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Library.WebApp.Controllers
{
    [LibAuthFilter]
    public class RentalController : Controller
    {
        private readonly IRentalService _rentalService
                        = BusinessContainer.Container.Resolve<IRentalService>();

        // GET: Rental
        [HttpGet()]
        public ActionResult Index(int id)
        {
            try
            {
                var userId = (int)Session["id"];
                var rent = _rentalService.RentBook(id, userId);

                ViewBag.Message = "Book is not all yours";
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
            }

            return View();
        }

      
    }
}