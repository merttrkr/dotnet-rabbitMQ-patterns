using Core.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using ProductService.Infrastructure.Persistence.Repositories.Interfaces;

namespace ProductService.Infrastructure.Persistence.Repositories;

public class BaseRepository<TContext, TEntity> : IBaseRepository<TEntity>
    where TContext : DbContext
    where TEntity : Entity
{
    protected readonly TContext _context;
    public BaseRepository(TContext context)
    {
        _context = context;
    }
    public async Task<TEntity> Add(TEntity entity)
    {
        await _context.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }
}

