using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using PruebaTécnica.Application.Abstranctions.Behaviors;
using PruebaTécnica.Application.Abstranctions.Identification;
using PruebaTécnica.Domain.Motions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTécnica.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);

            configuration.AddOpenBehavior(typeof(LoggingBehavior<,>));

            configuration.AddOpenBehavior(typeof(ValidationBehavior<,>));
        });

        services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);

        services.AddTransient<WorthService>();

        return services;
    }
}
