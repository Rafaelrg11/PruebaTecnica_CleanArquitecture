using MediatR;
using Microsoft.Extensions.Logging;
using PruebaTécnica.Application.Abstranctions.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTécnica.Application.Abstranctions.Behaviors;

public class LoggingBehavior<TRequest, TREsponse>
    : IPipelineBehavior<TRequest, TREsponse>
    where TRequest : IBaseCommand
{
    private readonly ILogger<TRequest> _logger;

    public LoggingBehavior(ILogger<TRequest> logger)
    {
        _logger = logger;
    }

    public  async Task<TREsponse> Handle(TRequest request, 
        RequestHandlerDelegate<TREsponse> next, 
        CancellationToken cancellationToken)
    {
        var name = request.GetType().Name;

        try
        {
            _logger.LogInformation("Executing request {Request}", name);

            var result = await next();

            _logger.LogInformation("Request {Request} processed successfully", name);
            
            return result;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Request {Request} processing failed", name);

            throw;
        }
    }
}

