using Autofac;
using Library.Business.Container;
using Library.Bussiness.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Library.WebApp.Controllers
{
    [Route("/login")]
    public class LoginController : Controller
    {
        IAuthService authService = BusinessContainer
                                        .Container
                                        .Resolve<IAuthService>(); 

        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string email, string password)
        {
            try
            {
                var user = authService.Login(email, password);

                if (user != null)
                {
                    FormsAuthentication.RedirectFromLoginPage($"{user.Id}|{user.Name}|{user.Email}", true);
                }
            }
            catch (AuthenticationException excp)
            {
                ViewBag.Error =excp.Message;
            }
            return View();
        }
    }
}