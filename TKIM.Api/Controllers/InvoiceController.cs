using MediatR;
using Microsoft.AspNetCore.Mvc;
using TKIM.Api.Controllers.Base;
using TKIM.Application.Invoice;
using TKIM.Application.Services.Abstract;
using TKIM.Dto.InvoiceGenerate;

namespace TKIM.Api.Controllers;

public class InvoiceController : BaseController
{
    private readonly IPdfGeneratorService _pdfGeneratorService;
    public InvoiceController(IMediator mediator, IPdfGeneratorService pdfGeneratorService) : base(mediator)
    {
        _pdfGeneratorService = pdfGeneratorService;
    }

    [HttpPost("GenerateInvoice")]
    [ProducesResponseType(typeof(byte[]), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<IActionResult> GenerateInvoice([FromBody] InvoiceGenerateDto invoiceGenerate)
    {
        var response = await _pdfGeneratorService.GenerateInvoiceForSale(invoiceGenerate);
        return File(response, "application/pdf");
    }

    [HttpGet("GetInvoiceHistory")]
    [ProducesResponseType(typeof(List<InvoiceHistoryResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetInvoiceHistory()
     => await HandleResponse(new GetInvoiceHistoryQuery());
}
