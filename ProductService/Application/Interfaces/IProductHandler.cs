using ProductService.Domain.Entities;

namespace ProductService.Application.Interfaces;

public interface IProductHandler
{
     Task AddProduct(Product product);
}
