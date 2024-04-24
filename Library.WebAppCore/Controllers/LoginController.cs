using Autofac;
using Library.Business.Container;
using Library.Bussiness.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Text.Json;

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
        public async Task<ActionResult> Index(string email, string password)
        {
            try
            {
                var user = authService.Login(email, password);

                if (user != null)
                {

                    List<Claim> claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                        new Claim(ClaimTypes.Email, user.Email),
                        new Claim(ClaimTypes.Name, user.Name),
                        new Claim("Mobile","0000000"),
                        new Claim("User",JsonSerializer.Serialize(user)),
                    };

                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                    return  Redirect("/");
                    //FormsAuthentication.RedirectFromLoginPage($"{user.Id}|{user.Name}|{user.Email}", true);
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