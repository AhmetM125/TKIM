using MediatR;
using Microsoft.AspNetCore.Mvc;
using TKIM.Api.Controllers.Base;
using TKIM.Application.Payment;

namespace TKIM.Api.Controllers;

public class PaymentController : BaseController
{
    public PaymentController(IMediator mediator) : base(mediator)
    {
    }

    [HttpPost("SubmitPayment")]
    public async Task<IActionResult> SubmitPayment([FromBody] PaymentRequest paymentTab)
    {
        return Ok(await HandleResponse(new SubmitPaymentCommand(
            paymentTab.BasketItems,
            paymentTab.TotalPrice,
            paymentTab.PaymentAmount,
            paymentTab.TotalDiscount,
            paymentTab.TotalPriceAfterDiscount,
            paymentTab.TotalTax
            )));
    }
}
