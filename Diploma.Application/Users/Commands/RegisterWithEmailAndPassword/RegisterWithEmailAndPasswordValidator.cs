using FluentValidation;

namespace Diploma.Application.Users.Commands.RegisterWithEmailAndPassword
{
    class RegisterWithEmailAndPasswordValidator : AbstractValidator<RegisterWithEmailAndPasswordCommand>
    {
        public RegisterWithEmailAndPasswordValidator()
        {
            RuleFor(command => command.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Email must be a valid email address.")
                .MaximumLength(255).WithMessage("Email must not exceed 255 characters."); ;

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required.")
                .MinimumLength(8).WithMessage("Password must be at least 8 characters long.")
                .MaximumLength(20).WithMessage("Email must not exceed 20 characters.")
                .Matches(@"[A-Z]").WithMessage("Password must contain at least one uppercase letter.")
                .Matches(@"[a-z]").WithMessage("Password must contain at least one lowercase letter.")
                .Matches(@"\d").WithMessage("Password must contain at least one number.");
        }
    }
}
