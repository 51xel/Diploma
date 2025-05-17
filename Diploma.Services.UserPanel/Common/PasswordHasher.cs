using Diploma.Application.Users.Interfaces;
using Diploma.Domain.Users;
using Microsoft.AspNetCore.Identity;

namespace Diploma.Services.UserPanel.Common
{
    class PasswordHasher : IPasswordHasher
    {
        private readonly PasswordHasher<object> _identityPasswordHasher = new();

        public string HashPassword(string password)
        {
            return _identityPasswordHasher.HashPassword(null, password);
        }

        public bool VerifyPassword(string hashedPassword, string providedPassword)
        {
            var result = _identityPasswordHasher.VerifyHashedPassword(null, hashedPassword, providedPassword);
            return result == PasswordVerificationResult.Success;
        }
    }
}
