using Microsoft.EntityFrameworkCore;
using PruebaTécnica.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTécnica.Infraestructure.Repository;

internal abstract class Repository<T>
    where T : Entity
{
    protected readonly ApplicationDbContext _context;
    protected Repository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<T?> GetByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default)
    {
        return await _context
            .Set<T>()
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }
    public virtual void Add(T entity)
    {
        _context.Add(entity);
    }
}
