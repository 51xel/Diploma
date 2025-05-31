using Diploma.Application.Users.Interfaces;
using Diploma.Dal.EntityFramework.Common;
using Diploma.Domain.Users.AuthenticationTypes;
using Microsoft.EntityFrameworkCore;

namespace Diploma.Dal.EntityFramework.Users
{
    class AuthenticateWithEmailAndPasswordRepository : IAuthenticateWithEmailAndPasswordRepository
    {
        private readonly ApplicationDbContext applicationDbContext;

        public AuthenticateWithEmailAndPasswordRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public async Task CreateAsync(EmailAndPasswordAuthType emailAndPasswordAuthType)
        {
            applicationDbContext.EmailAndPasswordAuthTypes.Add(emailAndPasswordAuthType);
            await applicationDbContext.SaveChangesAsync();
        }

        public async Task<EmailAndPasswordAuthType?>GetByEmailAsync(string email)
        {
            return await applicationDbContext.EmailAndPasswordAuthTypes.FirstOrDefaultAsync(type => type.Email == email);
        }
    }
}
