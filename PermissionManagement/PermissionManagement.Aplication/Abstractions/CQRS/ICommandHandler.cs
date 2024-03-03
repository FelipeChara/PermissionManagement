using MediatR;
using PermissionManagement.Domain.Abstractions;

namespace PermissionManagement.Application.Abstractions.CQRS
{
    public interface ICommandHandler<TCommand, TResponse>
            : IRequestHandler<TCommand, Result<TResponse>>
            where TCommand : ICommand<TResponse>
    {

    }
}
