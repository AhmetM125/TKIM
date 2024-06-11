using MediatR;
using TKIM.Api.Controllers.Base;

namespace TKIM.Api.Controllers;

public class PeopleController : BaseController
{
    public PeopleController(IMediator mediator) : base(mediator)
    {
    }
}
