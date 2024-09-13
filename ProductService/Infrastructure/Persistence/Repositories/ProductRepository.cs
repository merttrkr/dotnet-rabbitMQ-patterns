using ProductService.Domain.Entities;
using ProductService.Infrastructure.Persistence.Repositories.Interfaces;

namespace ProductService.Infrastructure.Persistence.Repositories
{
    public class ProductRepository : BaseRepository<AppDbContext, Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
        }
    }
}
