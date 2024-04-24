using System.Security.Claims;

namespace Library.WebAppCore
{
    public static class HttpUserExten
    {
        public static int GetUserId(this HttpContext context)
        {
            return int.Parse(context.User.FindFirstValue(ClaimTypes.NameIdentifier));
        }
    }
}
