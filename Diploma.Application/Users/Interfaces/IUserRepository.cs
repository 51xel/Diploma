using Diploma.Domain.Users;

namespace Diploma.Application.Users.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetUserAsync(Guid id, CancellationToken cancellationToken);
        Task CreateUserAsync(User user, CancellationToken cancellationToken);
    }
}
