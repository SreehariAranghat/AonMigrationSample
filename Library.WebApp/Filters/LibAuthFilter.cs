using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Library.WebApp.Filters
{

    public class GlobalFilters
    {
        public static GlobalFilterCollection Filters { get; private set; }

        static GlobalFilters()
        {
            Filters = new GlobalFilterCollection();
            Filters.Add(new LibAuthFilter());
        }
    }

    public class LibAuthFilter : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
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
           
        }
    }
}