using Diploma.Application.Users.Interfaces;
using Diploma.Dal.EntityFramework.Common;
using Diploma.Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace Diploma.Dal.EntityFramework.Users
{
    class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public UserRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task CreateUserAsync(User user, CancellationToken cancellationToken)
        {
            _applicationDbContext.Users.Add(user);
            await _applicationDbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<User?> GetUserAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _applicationDbContext.Users.FirstOrDefaultAsync(user => user.Id == id, cancellationToken);
        }
    }
}
