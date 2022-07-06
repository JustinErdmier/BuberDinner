using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Entities;

namespace BuberDinner.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    private readonly IUserRepository _userRepository;

    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository    = userRepository;
    }

    /// <inheritdoc />
    public AuthenticationResult Register(string firstName, string lastName, string email, string password)
    {
        // Check if user already exists.
        if (_userRepository.GetUserByEmail(email) is not null)
        {
            throw new Exception("User with given email already exists.");
        }

        // Create user.
        var user = new User { FirstName = firstName, LastName = lastName, Email = email, Password = password };

        _userRepository.Add(user);

        // Create JWT token.
        string token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(user, token);
    }

    /// <inheritdoc />
    public AuthenticationResult Login(string email, string password)
    {
        // Check if user exists.
        if (_userRepository.GetUserByEmail(email) is not { } user)
        {
            throw new Exception("User with given email does not exist.");
        }

        // Validate password is correct.
        if (user.Password != password)
        {
            throw new Exception("Invalid password.");
        }

        // Create JWT token.
        string token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(user, token);
    }
}
