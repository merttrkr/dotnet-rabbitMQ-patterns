using Core.Persistence.Repositories;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace ProductService.Infrastructure.Persistence.Repositories.Interfaces;

public interface IBaseRepository<TEntity>
    where TEntity : Entity
{
    Task<TEntity> Add(TEntity entity);
    Task<TEntity?> Get(Expression<Func<TEntity, bool>> predicate,
                                            Func<IQueryable<TEntity>,IIncludableQueryable<TEntity,object>>? include = null,
                                            bool withDeleted = false,
                                            bool enableTracking = true,
                                            CancellationToken cancellationToken = default);

}
