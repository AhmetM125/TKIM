using MediatR;
using TKIM.Api.Controllers.Base;

namespace TKIM.Api.Controllers;

public class ProductController : BaseController
{
    public ProductController(IMediator mediator) : base(mediator)
    {
    }

    //[HttpPost("Create")]
    //public async Task<IActionResult> CreateProduct([FromBody] RequestProduct request)
    // => await HandleResponse(new CreateProductCommand(request.Model, request.Files));
}
