using MediatR;
using TKIM.Api.Controllers.Base;

namespace TKIM.Api.Controllers;

public class InvoiceController : BaseController
{

    public InvoiceController(IMediator mediator) : base(mediator)
    {
    }


    
}
