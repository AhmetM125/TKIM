using MediatR;
using TKIM.Api.Controllers.Base;

namespace TKIM.Api.Controllers;

public class CustomerController : BaseController
{
    public CustomerController(IMediator mediator) : base(mediator)
    {
    }
}
