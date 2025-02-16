using E_commerce_Product_Catalog.Service.Commands.ManageCategories;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace E_commerc.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoryController : ControllerBase
{
    private readonly IMediator _mediator;

    public CategoryController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> AddCategory([FromBody] AddCategoryCommand command)
    {
        var category = await _mediator.Send(command);
        return Ok(category);
    }

    [HttpGet]
    public async Task<IActionResult> GetCategories()
    {
        var categories = await _mediator.Send(new GetCategoriesQuery());
        return Ok(categories);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCategory(Guid id, [FromBody] string newCategoryName)
    {
        var command = new UpdateCategoryCommand(id, newCategoryName);
        var updatedCategory = await _mediator.Send(command);
        return Ok(updatedCategory);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> RemoveCategory(Guid id)
    {
        await _mediator.Send(new RemoveCategoryCommand(id));
        return NoContent();
    }
}