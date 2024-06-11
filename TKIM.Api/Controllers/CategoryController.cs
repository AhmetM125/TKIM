using MediatR;
using TKIM.Api.Controllers.Base;

namespace TKIM.Api.Controllers;

public class CategoryController : BaseController
{
    public CategoryController(IMediator mediator) : base(mediator)
    {
    }

   
}
