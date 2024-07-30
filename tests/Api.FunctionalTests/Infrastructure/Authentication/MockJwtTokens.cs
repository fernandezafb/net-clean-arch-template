using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Api.FunctionalTests.Infrastructure.Authentication;

public static class MockJwtTokens
{
    public static string Issuer { get; } = Guid.NewGuid().ToString();

    public static string Audience => "authenticated";

    public static string JwtSecret => "this is my custom secret key for authentication";

    private static SecurityKey SecurityKey { get; }

    private static SigningCredentials SigningCredentials { get; }

    private static readonly JwtSecurityTokenHandler TokenHandler = new();

    static MockJwtTokens()
    {
        SecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtSecret));
        SigningCredentials = new SigningCredentials(SecurityKey, SecurityAlgorithms.HmacSha256);
    }

    /*
     * Generates a JWT token for test purposes.
     * Uses the signing credentials with the faked security key.
     */
    public static string GenerateJwtToken(IEnumerable<Claim> claims)
    {
        return TokenHandler.WriteToken(new JwtSecurityToken(
            Issuer,
            Audience,
            claims,
            null,
            DateTime.UtcNow.AddMinutes(20),
            SigningCredentials)
        );
    }
}
