using MediatR;
using Microsoft.EntityFrameworkCore;
using PruebaTécnica.Application.Exceptions;
using PruebaTécnica.Domain.Abstractions;
using PruebaTécnica.Domain.Clientes;
using PruebaTécnica.Domain.Cuenta;
using PruebaTécnica.Domain.Movimientos;
using PruebaTécnica.Domain.Persons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTécnica.Infraestructure;

public sealed class ApplicationDbContext : DbContext, IUnitOfWork
{
    private readonly IPublisher _publisher;
    public ApplicationDbContext(DbContextOptions options, IPublisher publisher)
        : base(options)
    {
        _publisher = publisher;
    }

    public DbSet<Client> Clients { get; set; }
    public DbSet<Account> Accounts { get; set; }
    public DbSet<Person> Persons { get; set; }
    public DbSet<Motion> Motions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            var result = await base.SaveChangesAsync(cancellationToken);

            await PublishDomainEvetnsAsync();

            return result;
        }
        catch (DbUpdateConcurrencyException ex)
        {
            throw new ConcurrencyException("Concurrency exception ocurred", ex);
        }
    }

    public void Add(Entity person)
    {
        base.Add(person);
    }

    private async Task PublishDomainEvetnsAsync()
    {
        var domainEvents = ChangeTracker
            .Entries<Entity>()
            .Select(entry => entry.Entity)
            .SelectMany(entity =>
            {
                var domainEvents = entity.GetDomainEvents();

                entity.ClearDomainEvent();

                return domainEvents;
            });

        foreach (var item in domainEvents)

            await _publisher.Publish(item);
    }
}
