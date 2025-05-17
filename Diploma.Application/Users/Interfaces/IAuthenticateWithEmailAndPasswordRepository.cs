using Diploma.Domain.Users.AuthenticationTypes;

namespace Diploma.Application.Users.Interfaces
{
    public interface IAuthenticateWithEmailAndPasswordRepository
    {
        Task<EmailAndPasswordAuthType?> GetByEmailAsync(string email);
        Task CreateAsync(EmailAndPasswordAuthType emailAndPasswordAuthType);
    }
}
