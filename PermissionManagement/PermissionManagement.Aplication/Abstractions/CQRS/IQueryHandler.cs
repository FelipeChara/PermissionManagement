using MediatR;
using PermissionManagement.Domain.Abstractions;

namespace PermissionManagement.Application.Abstractions.CQRS
{
    public interface IQueryHandler<TQuery, TResponse>
            : IRequestHandler<TQuery, Result<TResponse>>
            where TQuery : IQuery<TResponse>
    {

    }
}
