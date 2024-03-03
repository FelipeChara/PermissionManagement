using MediatR;
using PermissionManagement.Domain.Abstractions;

namespace PermissionManagement.Application.Abstractions.CQRS
{
    public interface IQuery<TResponse> : IRequest<Result<TResponse>>
    {

    }
}
