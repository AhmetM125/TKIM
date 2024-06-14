using MediatR;
using Microsoft.AspNetCore.Mvc;
using TKIM.Api.Controllers.Base;
using TKIM.Application.Product;

namespace TKIM.Api.Controllers;

public class ProductController : BaseController
{
    public ProductController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost("Create")]
    public async Task<IActionResult> CreateProduct([FromBody] RequestProduct request)
     => await HandleResponse(new CreateProductCommand(request.Model, request.Files));
}
