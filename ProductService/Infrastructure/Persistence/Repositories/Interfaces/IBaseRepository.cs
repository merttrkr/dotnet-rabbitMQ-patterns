using Core.Persistence.Repositories;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace ProductService.Infrastructure.Persistence.Repositories.Interfaces;

public interface IBaseRepository<TEntity>
    where TEntity : Entity
{
    Task<TEntity> Add(TEntity entity);

}
