using Microsoft.AspNetCore.Mvc;
using ProductService.Application.Interfaces;
using ProductService.Domain.Entities;

namespace ProductService.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductHandler _productHandler;

    public ProductController(IProductHandler productHandler)
    {
        _productHandler = productHandler;
    }

    [HttpPost]
    public async Task<IActionResult> AddProduct([FromBody] Product product )
    {
        if (product == null)
        {
            return BadRequest("product is null");
        }
        await _productHandler.AddProduct(product);
        return Ok("Product added successfully");
    }
}
