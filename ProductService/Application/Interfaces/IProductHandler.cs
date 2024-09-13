using ProductService.Domain.Entities;

namespace ProductService.Application.Interfaces;

public interface IProductHandler
{
    Task CreateProduct(Product product);
    Task<Product> GetProduct(Guid id, CancellationToken cancellationToken);
    Task AddProductToBasket(Guid id, int quantity, CancellationToken cancellationToken);
}
