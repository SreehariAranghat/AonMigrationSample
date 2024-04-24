using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using static System.Net.WebRequestMethods;


namespace Library.WebApp.Filters
{

    
    public class LibAuthFilter : AuthorizeAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext httpContext)
        {
            var user = httpContext.HttpContext.User.Identity;
            if (user != null && user.IsAuthenticated)
            {
                var data = user.Name.Split('|');
                httpContext.HttpContext.Session.SetInt32("Id", int.Parse(data[0]));
                httpContext.HttpContext.Session.SetString("Name", data[1]);
                httpContext.HttpContext.Session.SetString("Email", data[2]);

              
            }

            httpContext.Result = new UnauthorizedResult();

            
        }

        /*protected override bool AuthorizeCore(HttpContextBase httpContext)
{
   var user = httpContext.User.Identity;
   if (user != null && user.IsAuthenticated)
   {
       var data = user.Name.Split('|');
       httpContext.Session["Id"] = int.Parse(data[0]);
       httpContext.Session["Name"] = data[1];
       httpContext.Session["Email"] = data[2];

       return true;
   }

   return false;

}*/

       
    }
}