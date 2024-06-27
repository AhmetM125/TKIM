using MediatR;
using Microsoft.AspNetCore.Mvc;
using TKIM.Api.Controllers.Base;
using TKIM.Application.Services.Abstract;

namespace TKIM.Api.Controllers;

public class InvoiceController : BaseController
{
    private readonly IPdfGeneratorService _pdfGeneratorService;
    public InvoiceController(IMediator mediator, IPdfGeneratorService pdfGeneratorService) : base(mediator)
    {
        _pdfGeneratorService = pdfGeneratorService;
    }

    [HttpPost("GenerateInvoice")]
    [ProducesResponseType(typeof(void), StatusCodes.Status200OK)]
    public IActionResult GenerateInvoice([FromBody] object value) // Payment Class or invoice class will be to change
    {
        var response = _pdfGeneratorService.GenerateInvoice(value);
        return File(response, "application/pdf");
    }

}
