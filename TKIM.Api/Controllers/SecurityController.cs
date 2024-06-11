using MediatR;
using TKIM.Api.Controllers.Base;

namespace TKIM.Api.Controllers;

public class SecurityController : BaseController
{
    public SecurityController(IMediator mediator) : base(mediator)
    {
    }
}
