using MediatR;
using Microsoft.AspNetCore.Mvc;
using TKIM.Api.Controllers.Base;
using TKIM.Application.PaymentItems;

namespace TKIM.Api.Controllers;


public class PaymentItemsController : BaseController
{
    public PaymentItemsController(IMediator mediator) : base(mediator)
    {}


    [HttpGet("GetPaymentItemListByInvoiceId")]
    [ProducesResponseType(typeof(List<PaymentItemResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetProductsByInvoiceId([FromQuery] Guid invoiceId)
       => await HandleResponse(new GetPaymentItemsByInvoiceIdQuery(invoiceId));

}
