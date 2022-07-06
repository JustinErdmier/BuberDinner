using BuberDinner.Application.Common.Interfaces.Authentication;

namespace BuberDinner.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator) => _jwtTokenGenerator = jwtTokenGenerator;

    /// <inheritdoc />
    public AuthenticationResult Register(string firstName, string lastName, string email, string password)
    {
        // Check if user already exists.

        // Create user (generate unique ID).
        var    userId    = Guid.NewGuid();
        string token = _jwtTokenGenerator.GenerateToken(userId, firstName, lastName);
            
        // Create JWT token.
        return new AuthenticationResult(userId, firstName, lastName, email, token);
    }

    /// <inheritdoc />
    public AuthenticationResult Login(string email, string password) => new AuthenticationResult(Guid.NewGuid(), "firstName", "lastName", email, "token");
}
