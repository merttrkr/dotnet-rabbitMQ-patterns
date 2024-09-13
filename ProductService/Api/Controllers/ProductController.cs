using Microsoft.AspNetCore.Mvc;
using ProductService.Application.Interfaces;
using ProductService.Domain.Entities;

namespace ProductService.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductHandler _productHandler;

    public ProductController(IProductHandler productHandler) { _productHandler = productHandler; }

    [HttpPost("{id}/add-to-basket")]
    public async Task<IActionResult> AddToBasket(
         Guid id,
        [FromQuery] int quantity,
        CancellationToken cancellationToken)
    {
        await _productHandler.AddProductToBasket(id, quantity, cancellationToken);
        return Ok("product added to basket");
    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromBody] Product product)
    {
        if(product == null)
        {
            return BadRequest("product is null");
        }
        await _productHandler.CreateProduct(product);
        return Ok("Product added successfully");
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProduct([FromRoute] Guid id, CancellationToken cancellationToken)
    { return Ok(await _productHandler.GetProduct(id, cancellationToken)); }
}
