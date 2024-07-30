using System.Net.Http.Headers;
using System.Security.Claims;
using Microsoft.IdentityModel.JsonWebTokens;

namespace Api.FunctionalTests.Infrastructure.Authentication;

public static class MockAuthenticationExtensions
{
    public static HttpClient WithUserCredentials(this HttpClient client, string userId)
    {
        if (string.IsNullOrEmpty(userId))
        {
            return client;
        }

        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
            "Bearer",
            MockJwtTokens.GenerateJwtToken([
                new Claim(JwtRegisteredClaimNames.Sub, userId)
            ])
        );

        return client;
    }
}
