using MediatR;
using TKIM.Api.Controllers.Base;

namespace TKIM.Api.Controllers;

public class ProductController : BaseController
{
    public ProductController(IMediator mediator) : base(mediator)
    {
    }
}
