namespace BuberDinner.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    /// <inheritdoc />
    public AuthenticationResult Register(string firstName, string lastName, string email, string password) =>
        new AuthenticationResult(Guid.NewGuid(), firstName, lastName, email, "token");

    /// <inheritdoc />
    public AuthenticationResult Login(string email, string password) =>
        new AuthenticationResult(Guid.NewGuid(), "firstName", "lastName", email, "token");
}
