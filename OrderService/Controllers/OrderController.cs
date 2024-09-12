using Microsoft.AspNetCore.Mvc;
using MassTransit;
using OrderService.Contracts;
namespace OrderService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;
        private readonly IPublishEndpoint _publishEndpoint;

        public OrderController(ILogger<OrderController> logger,IPublishEndpoint publishEndpoint)
        {
            _logger = logger;
            _publishEndpoint = publishEndpoint;
        }

        [HttpPost] 
        public async Task<IActionResult> CreateOrder([FromBody] Order order)
        {
            // Publish the order to RabbitMQ
            await _publishEndpoint.Publish(order);

            return Ok($"Order {order.Id} created at: {order.CreatedDate} and published to the message queue.");
        }
    }
}
