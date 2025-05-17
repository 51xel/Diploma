using Diploma.Domain.Users;
using ErrorOr;
using MediatR;

namespace Diploma.Application.Users.Commands.AuthenticateWithEmailAndPassword
{
    public record AuthenticateWithEmailAndPasswordCommand(string Email, string Password) :
        IRequest<ErrorOr<User>>;
}
