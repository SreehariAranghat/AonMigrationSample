using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CommonUtilityCore
{
    public class ContextAccessService : IContextService
    {
        private IHttpContextAccessor contextAccessor;

        public ContextAccessService(IHttpContextAccessor contextAccessor)
        {
            this.contextAccessor = contextAccessor;
        }

        public int GetCurrentUser()
        {
            return int.Parse(this.contextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
        }
    }
}
