using PruebaTécnica.Domain.Persons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTécnica.Domain.Abstractions;

public interface IUnitOfWork
{
    void Add(Entity person);
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
