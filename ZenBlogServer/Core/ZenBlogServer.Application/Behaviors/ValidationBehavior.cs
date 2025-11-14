using FluentValidation;
using MediatR;

namespace ZenBlogServer.Application.Behaviors;

public class ValidationBehavior<TRequest, TResponse>(IEnumerable<IValidator<TRequest>> validators) : IPipelineBehavior<TRequest, TResponse> where TRequest : class
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (validators.Any())
        {
            var context = new ValidationContext<TRequest>(request);

            var validationResult = await Task.WhenAll(
                validators.Select(x => x.ValidateAsync(context, cancellationToken)));
            
            var failures = validationResult
                .Where(r => r != null)
                .SelectMany(r => r.Errors ?? [])
                .Where(e => e != null)
                .ToList();

            if (failures.Any())
            {
                throw new ValidationException(failures);
            }
        }

        return await next(cancellationToken);
    }
}