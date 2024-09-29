using Dapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PruebaTécnica.Application.Abstranctions.Clock;
using PruebaTécnica.Application.Abstranctions.Data;
using PruebaTécnica.Domain.Abstractions;
using PruebaTécnica.Domain.Clientes;
using PruebaTécnica.Domain.Cuentas;
using PruebaTécnica.Domain.Movimientos;
using PruebaTécnica.Domain.Persons;
using PruebaTécnica.Infraestructure.Clock;
using PruebaTécnica.Infraestructure.Data;
using PruebaTécnica.Infraestructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace PruebaTécnica.Infraestructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfraestructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddTransient<IDateTimeProvider, DateTimeProvider>();
        
        var connectionString =
            configuration.GetConnectionString("CadenaPostgre") ??
            throw new ArgumentNullException(nameof(configuration));

        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseNpgsql(connectionString).UseSnakeCaseNamingConvention();
        });

        services.AddScoped<IPersonRepository, PersonRepository>();

        services.AddScoped<IMotionRepository, MotionRepository>();

        services.AddScoped<IClientRepository, ClientRepository>();

        services.AddScoped<IAccountRepository, AccountRepository>();

        services.AddScoped<IUnitOfWork>(e => e.GetRequiredService<ApplicationDbContext>());

        services.AddSingleton<ISqlConnectionFactory>(_ =>
            new SqlConnectionFactory(connectionString));

        SqlMapper.AddTypeHandler(new DateOnlyTypeHandler());

        return services;
    }
}
