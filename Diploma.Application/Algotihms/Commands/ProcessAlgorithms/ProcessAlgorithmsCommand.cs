using ErrorOr;
using MediatR;

namespace Diploma.Application.Algotihms.Commands.ProcessAlgorithm
{
    public record ProcessAlgorithmsCommand() :
        IRequest<ErrorOr<Success>>;
}
