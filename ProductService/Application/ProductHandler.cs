using MassTransit;
using Microsoft.AspNetCore.Mvc;
using ProductService.Application.Events;
using ProductService.Application.Interfaces;
using ProductService.Domain.Entities;
using ProductService.Infrastructure.Persistence.Repositories.Interfaces;

namespace ProductService.Application
{
    public class ProductHandler : IProductHandler
    {
        private readonly IProductRepository _productRepository;
        private readonly IPublishEndpoint _publishEndpoint;
        public ProductHandler(IProductRepository productRepository, IPublishEndpoint publishEndpoint)
        {
            _productRepository = productRepository;
            _publishEndpoint = publishEndpoint;
        }

        public async Task AddProductToBasket(Guid id, int quantity, CancellationToken cancellationToken)
        {
            var product = await GetProduct(id, cancellationToken);
            if (product == null)
            {
                throw new ArgumentException("product not found");
            }
            var addedToBasketEvent = new AddedToBasketEvent(product.Id,product.Name,product.Price, quantity);
            await _publishEndpoint.Publish(addedToBasketEvent,cancellationToken);
        }

        public async Task CreateProduct(Product product)
        {
            await _productRepository.Add(product);
        }

        public async Task<Product> GetProduct(Guid id, CancellationToken cancellationToken)
        {
            Product? product = await _productRepository.Get(predicate: b=> b.Id == id,cancellationToken:cancellationToken);

            return product;
        }
    }
}
