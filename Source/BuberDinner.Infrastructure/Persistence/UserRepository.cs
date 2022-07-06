using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Entities;

namespace BuberDinner.Infrastructure.Persistence;

public class UserRepository : IUserRepository
{
    private static readonly List<User> _users = new ();

    /// <inheritdoc />
    public User? GetUserByEmail(string email) => _users.SingleOrDefault(user => user.Email == email);

    /// <inheritdoc />
    public void Add(User user) => _users.Add(user);
}
