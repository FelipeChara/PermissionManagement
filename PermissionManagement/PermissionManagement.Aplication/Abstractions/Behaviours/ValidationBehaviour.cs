using FluentValidation;
using MediatR;
using PermissionManagement.Application.Exceptions;
using PermissionManagement.Application.Abstractions.CQRS;

namespace PermissionManagement.Application.Abstractions.Behaviours
{
    public class ValidationBehaviour<TRequest, TResponse>(IEnumerable<IValidator<TRequest>> validators)
       : IPipelineBehavior<TRequest, TResponse>
       where TRequest : IBaseCommand
    {

        private readonly IEnumerable<IValidator<TRequest>> _validators = validators;

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (!_validators.Any())
            {
                return await next();
            }

            var context = new ValidationContext<TRequest>(request);

            var validationErrors = _validators
            .Select(validators => validators.Validate(context))
            .Where(validationResult => validationResult.Errors.Count != 0)
            .SelectMany(validationResult => validationResult.Errors)
            .Select(validationFailure => new ValidationError(
                validationFailure.PropertyName,
                validationFailure.ErrorMessage
            )).ToList();

            if (validationErrors.Count != 0)
            {
                throw new Exceptions.ValidationException(validationErrors);
            }

            return await next();
        }
    }
}
