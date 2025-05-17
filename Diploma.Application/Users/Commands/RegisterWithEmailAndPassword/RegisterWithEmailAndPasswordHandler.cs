using Diploma.Application.Users.Interfaces;
using Diploma.Domain.Users;
using Diploma.Domain.Users.AuthenticationTypes;
using ErrorOr;
using MediatR;

namespace Diploma.Application.Users.Commands.RegisterWithEmailAndPassword
{
    class RegisterWithEmailAndPasswordHandler : IRequestHandler<RegisterWithEmailAndPasswordCommand, ErrorOr<User>>
    {
        private readonly RegisterWithEmailAndPasswordValidator _validator;
        private readonly IUserRepository _userRepository;
        private readonly IAuthenticateWithEmailAndPasswordRepository _authenticateWithEmailAndPasswordRepository;
        private readonly IPasswordHasher _passwordHasher;

        public RegisterWithEmailAndPasswordHandler(
            IUserRepository userRepository,
            IAuthenticateWithEmailAndPasswordRepository authenticateWithEmailAndPasswordRepository,
            IPasswordHasher passwordHasher)
        {
            _validator = new RegisterWithEmailAndPasswordValidator();
            _userRepository = userRepository;
            _authenticateWithEmailAndPasswordRepository = authenticateWithEmailAndPasswordRepository;
            _passwordHasher = passwordHasher;
        }

        public async Task<ErrorOr<User>> Handle(RegisterWithEmailAndPasswordCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                return validationResult.Errors
                    .Select(error => Error.Validation(error.PropertyName, error.ErrorMessage))
                    .ToList();
            }

            var emailAndPasswordAuthType = await _authenticateWithEmailAndPasswordRepository.GetByEmailAsync(request.Email);

            if (emailAndPasswordAuthType is not null)
            {
                return Error.NotFound(description: "User with this email is already exists");
            }

            var hashedPassword = _passwordHasher.HashPassword(request.Password);

            var user = new User(string.Join("", request.Email.Take(20)), AuthenticationType.EmailAndPassword);

            emailAndPasswordAuthType = new EmailAndPasswordAuthType(user.Id, request.Email, hashedPassword);

            await _userRepository.CreateUserAsync(user, cancellationToken);
            await _authenticateWithEmailAndPasswordRepository.CreateAsync(emailAndPasswordAuthType);

            return user;
        }
    }
}
