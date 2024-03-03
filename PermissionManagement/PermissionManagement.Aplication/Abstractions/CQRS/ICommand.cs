using MediatR;
using PermissionManagement.Domain.Abstractions;

namespace PermissionManagement.Application.Abstractions.CQRS
{
    public interface ICommand<TResponse> : IRequest<Result<TResponse>>, IBaseCommand
    {

    }

    public interface IBaseCommand
    {

    }
}
