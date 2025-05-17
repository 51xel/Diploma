using Diploma.Domain.Users;
using ErrorOr;
using MediatR;

namespace Diploma.Application.Users.Commands.RegisterWithEmailAndPassword
{
    public record RegisterWithEmailAndPasswordCommand(string Email, string Password) :
        IRequest<ErrorOr<User>>;
}
