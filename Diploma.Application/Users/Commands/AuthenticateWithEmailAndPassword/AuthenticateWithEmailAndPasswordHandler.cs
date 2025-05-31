using Diploma.Application.Users.Interfaces;
using Diploma.Domain.Users;
using ErrorOr;
using MediatR;

namespace Diploma.Application.Users.Commands.AuthenticateWithEmailAndPassword
{
    class AuthenticateWithEmailAndPasswordHandler : IRequestHandler<AuthenticateWithEmailAndPasswordCommand, ErrorOr<User>>
    {
        private readonly AuthenticateWithEmailAndPasswordValidator _validator;
        private readonly IAuthenticateWithEmailAndPasswordRepository _authenticateWithEmailAndPasswordRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IUserRepository _userRepository;

        public AuthenticateWithEmailAndPasswordHandler(
            IAuthenticateWithEmailAndPasswordRepository authenticateWithEmailAndPasswordRepository,
            IPasswordHasher passwordHasher,
            IUserRepository userRepository)
        {
            _validator = new AuthenticateWithEmailAndPasswordValidator();
            _authenticateWithEmailAndPasswordRepository = authenticateWithEmailAndPasswordRepository;
            _passwordHasher = passwordHasher;
            _userRepository = userRepository;
        }

        public async Task<ErrorOr<User>> Handle(AuthenticateWithEmailAndPasswordCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                return validationResult.Errors
                    .Select(error => Error.Validation(error.PropertyName, error.ErrorMessage))
                    .ToList();
            }

            var emailAndPasswordAuthType = await _authenticateWithEmailAndPasswordRepository.GetByEmailAsync(request.Email);

            if (emailAndPasswordAuthType is null || !_passwordHasher.VerifyPassword(emailAndPasswordAuthType.PasswordHash, request.Password))
            {
                return Error.NotFound(description: "Email or password is invalid");
            }

            var user = await _userRepository.GetUserAsync(emailAndPasswordAuthType.UserId, cancellationToken);

            if (user is null)
            {
                return Error.Failure(description: "Unexpected error occured");
            }

            return user;
        }
    }
}
