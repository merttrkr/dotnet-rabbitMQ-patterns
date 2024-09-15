using BasketService.Domain.Entities;
using BasketService.Infrastructure.Persistence.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace BasketService.Infrastructure.Persistence.Repositories;

public class BaseRepository<TDbContext, TEntity> : IBaseRepository<TEntity>
    where TEntity : Entity
    where TDbContext : AppDbContext
{
    private readonly TDbContext _dbContext;
    public BaseRepository(TDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<TEntity> AddAsync(TEntity entity)
    {
        await _dbContext.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
        return entity;
    }

    public async Task<TEntity> DeleteAsync(TEntity entity)
    {
        _dbContext.Remove(entity);
        await _dbContext.SaveChangesAsync();
        return entity;
    }

    public async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include, bool enableTracking, CancellationToken cancellationToken)
    {
        IQueryable<TEntity> query = _dbContext.Set<TEntity>();
        if (!enableTracking)
        {
            query = query.AsNoTracking();
        }
        if (include != null)
        {
            query = include(query);
        }
        
        return  await query.FirstOrDefaultAsync(predicate,cancellationToken);

    }
}
