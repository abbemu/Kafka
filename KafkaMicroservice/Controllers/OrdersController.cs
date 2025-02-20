
using KafkaMicroService.Services;
using Microsoft.AspNetCore.Mvc;

namespace KafkaMicroService.Controllers;

[Route("api/orders")]
[ApiController]
public class OrderController : Controller
{
    private readonly KafkaProducerService _producerService;

    public OrderController(KafkaProducerService producerService)
    {
        _producerService = producerService;
    }

    /// <summary>
    /// Publishs the OrderDTO to Kafka
    /// </summary>
    /// <param name="order">The order message to be published</param>
    /// <returns>BadRequest(HTTP 400) incase empty, OK(HTTP 200) if not empty.</returns>
    [HttpPost]
    public async Task<IActionResult> PublishOrder([FromBody] OrderDTO order)
    {
        if (string.IsNullOrEmpty(order.Message))
            return BadRequest("Order request cannot be empty");

        await _producerService.SendMessageAsync(order.Message);
        return Ok();
    }
}

public class OrderDTO
{
    public string Message { get; set; }
}
