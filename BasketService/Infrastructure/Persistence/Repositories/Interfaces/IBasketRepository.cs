using BasketService.Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace BasketService.Infrastructure.Persistence.Repositories.Interfaces
{
    public interface IBasketRepository : IBaseRepository<Basket>
    {
     
    }
}
