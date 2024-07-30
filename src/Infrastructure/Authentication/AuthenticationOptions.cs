namespace Infrastructure.Authentication;

public sealed class AuthenticationOptions
{
    public string JwtSecret { get; set; } = string.Empty;

    public string ValidIssuer { get; set; } = string.Empty;

    public string ValidAudience { get; set; } = string.Empty;
}
