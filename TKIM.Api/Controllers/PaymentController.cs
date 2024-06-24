using MediatR;
using Microsoft.AspNetCore.Mvc;
using TKIM.Api.Controllers.Base;

namespace TKIM.Api.Controllers;

public class PaymentController : BaseController
{
    public PaymentController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost("Payment/SubmitPayment")]
    public async Task<IActionResult> SubmitPayment([FromBody] PaymentTabVM paymentTab)
    {
        return Ok(await Mediator.Send(new SubmitPaymentCommand(paymentTab)));
    }
}
