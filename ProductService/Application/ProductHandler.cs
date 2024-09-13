using Microsoft.AspNetCore.Mvc;
using ProductService.Application.Interfaces;
using ProductService.Domain.Entities;
using ProductService.Infrastructure.Persistence.Repositories.Interfaces;

namespace ProductService.Application
{
    public class ProductHandler : IProductHandler
    {
        private readonly IProductRepository _productRepository;
        public ProductHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task AddProduct(Product product)
        {
            await _productRepository.Add(product);
        }
    }
}
