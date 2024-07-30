using System.Security.Claims;

namespace Infrastructure.Authentication;

internal static class ClaimsPrincipalExtensions
{
    /*
     * Returns the user id from the claims principal. The sub exists in the token but the middleware
     * is mapping sub as the claim type string to http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier.
     */
    public static string GetIdentityId(this ClaimsPrincipal? principal)
    {
        return principal?.FindFirstValue(ClaimTypes.NameIdentifier) ??
               throw new ApplicationException("User identity is unavailable");
    }
}
