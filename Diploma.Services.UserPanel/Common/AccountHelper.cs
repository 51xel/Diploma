using Diploma.Domain.Users;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

namespace Diploma.Services.UserPanel.Common
{
    public class AccountHelper
    {
        private readonly HttpContext _httpContext;

        public AccountHelper(IHttpContextAccessor httpContextAccessor)
        {
            if (httpContextAccessor.HttpContext is null)
            {
                throw new InvalidOperationException();
            }

            _httpContext = httpContextAccessor.HttpContext;
        }

        public async Task SignInUserAsync(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            await _httpContext.SignInAsync(principal);
        }

        public async Task SignOutAsync()
        {
            if (_httpContext.User.Identity?.IsAuthenticated == true)
            {
                await _httpContext.SignOutAsync();
            }
        }

        public string? GetUserId()
        {
            return _httpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        }
    }
}
