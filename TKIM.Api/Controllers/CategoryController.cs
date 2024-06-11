using MediatR;
using Microsoft.AspNetCore.Mvc;
using TKIM.Api.Controllers.Base;
using TKIM.Application.Category;

namespace TKIM.Api.Controllers;

public class CategoryController : BaseController
{
    public CategoryController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost("create")]
    [ProducesResponseType((int)StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryRequest command)
     => await HandleResponse(new CreateCategoryCommand(command.Name, command.Description));

    [HttpGet("get/modify")]
    [ProducesResponseType(typeof(CategoryModifyResponse), (int)StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetModifyCategory([FromQuery] Guid id)
     => await HandleResponse(new CategoryModifyQuery(id));

    [HttpGet("get/all")]
    [ProducesResponseType(typeof(List<CategoryResponse>), (int)StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetAllCategories()
     => await HandleResponse(new GetAllCategoriesQuery());


}
