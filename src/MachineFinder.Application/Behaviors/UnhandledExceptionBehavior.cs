using MediatR;
using Microsoft.Extensions.Logging;

namespace MachineFinder.Application.Behaviors
{
    public class UnhandledExceptionBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
    {
        public UnhandledExceptionBehavior()
        {
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            try
            {
                return await next();
            }
            catch (Exception ex)
            {
                var requestName = typeof(TRequest).Name;
                var message = $"Application Request: Sucedio una excepción para el request {requestName} {request}";

                throw;
            }
        }
    }
}
