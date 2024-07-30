namespace Application.Abstractions.Authentication;

public interface IUserContext
{
    /*
     * Returns the user id from the claims principal.
     */
    string IdentityId { get; }
}
