using BasketService.Domain.Entities;
using BasketService.Infrastructure.Persistence.Repositories.Interfaces;

namespace BasketService.Infrastructure.Persistence.Repositories
{
    public class BasketRepository : BaseRepository<AppDbContext, Basket>,IBasketRepository
    {
        public BasketRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
