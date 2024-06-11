using MediatR;
using TKIM.Api.Controllers.Base;

namespace TKIM.Api.Controllers;

public class CompanyController : BaseController
{
    public CompanyController(IMediator mediator) : base(mediator)
    {
    }
}
