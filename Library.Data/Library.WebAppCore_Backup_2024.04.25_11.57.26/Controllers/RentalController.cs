using Autofac;
using Library.Business.Container;
using Library.Bussiness.Contracts;
using Library.Entities;
using Library.WebApp.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Library.WebAppCore;
using Microsoft.AspNetCore.Authorization;

namespace Library.WebApp.Controllers
{
    [Authorize]
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
                var userId = HttpContext.GetUserId();
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