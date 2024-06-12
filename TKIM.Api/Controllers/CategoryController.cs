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

    [HttpPost("Create")]
    [ProducesResponseType((int)StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateCategory( CreateCategoryRequest command)
     => await HandleResponse(new CategoryCreateCommand(command.Name, command.Description));

    [HttpGet("get/modify/{id:guid}")]
    [ProducesResponseType(typeof(CategoryModifyResponse), (int)StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetModifyCategory( Guid id)
     => await HandleResponse(new CategoryModifyQuery(id));

    [HttpGet("get/all")]
    [ProducesResponseType(typeof(List<CategoryResponse>), (int)StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetAllCategories()
     => await HandleResponse(new CategoryGetAllQuery());

    [HttpPut("ChangeInUse/{id:guid}")]
    [ProducesResponseType((int)StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> ChangeCategoryStatus(Guid id)
     => await HandleResponse(new CategoryChangeStatusCommand(id));

    [HttpPut("Update")]
    [ProducesResponseType((int)StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdateCategory([FromBody]UpdateCategoryRequest command)
     => await HandleResponse(new CategoryUpdateCommand(command.Id, command.Name, command.Description));


}
