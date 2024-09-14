using BasketService.Domain.Entities;
using BasketService.Infrastructure.Persistence.Repositories.Interfaces;

namespace BasketService.Infrastructure.Persistence.Repositories
{
    public class BasketItemRepository : BaseRepository<AppDbContext, BasketItem>,IBasketItemRepository
    {
        public BasketItemRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
