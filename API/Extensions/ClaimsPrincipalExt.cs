using System.Security.Claims;

namespace API.Extensions
{
    public static class ClaimsPrincipalExt
    {
        public static string RetrieveEmailFromPrincipal(this ClaimsPrincipal user)
        {
            return user.FindFirstValue(ClaimTypes.Email);
        }
    }
}