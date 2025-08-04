using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;

namespace MachineFinder.Application.Behaviors
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
    {
        private readonly ILogger<ValidationBehavior<TRequest, TResponse>> _logger;
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehavior(ILogger<ValidationBehavior<TRequest, TResponse>> logger, IEnumerable<IValidator<TRequest>> validators)
        {
            _logger = logger;
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            _logger.LogInformation("Ejecutando validación para: {RequestType}", typeof(TRequest).Name);

            // Aquí podrías agregar validaciones con FluentValidation
            // var validationResult = await _validator.ValidateAsync(request);
            // if (!validationResult.IsValid) throw new ValidationException(validationResult.Errors);

            //var response = await next();
            if (_validators.Any())
            {
                var context = new ValidationContext<TRequest>(request);
                var validationResults = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken)));
                var failures = validationResults.SelectMany(r => r.Errors).Where(f => f != null).ToList();

                if (failures.Count != 0)
                {
                    throw new ValidationException(failures);
                }
            }

            _logger.LogInformation("Validación completada para: {RequestType}", typeof(TRequest).Name);

            return await next();
        }
    }
}
