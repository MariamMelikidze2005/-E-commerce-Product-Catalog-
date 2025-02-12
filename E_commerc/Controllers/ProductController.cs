using E_commerce_Product_Catalog.Service.Commands.ProductManagement;
using MediatR;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("add")]
    public async Task<IActionResult> AddProduct([FromBody] AddProductCommand command)
    {
        var product = await _mediator.Send(command);
        return Ok(product);
    }

    [HttpGet("category/{categoryId}")]
    public async Task<IActionResult> GetProductsByCategory(Guid categoryId)
    {
        var products = await _mediator.Send(new GetProductsByCategoryCommand(categoryId));
        return Ok(products);
    }

    [HttpPut("update")]
    public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductCommand command)
    {
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("remove/{productId}")]
    public async Task<IActionResult> RemoveProduct(Guid productId)
    {
        await _mediator.Send(new RemoveProductCommand(productId));
        return NoContent();
    }
}