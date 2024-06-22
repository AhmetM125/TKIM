using MediatR;
using Microsoft.AspNetCore.Mvc;
using TKIM.Api.Controllers.Base;
using TKIM.Api.Models.Invoice;
using TKIM.Api.Utils;
using TKIM.Application.Product;

namespace TKIM.Api.Controllers;

public class ProductController : BaseController
{

    private readonly IRazorViewToStringRenderer _razorViewToStringRenderer;

    public ProductController(IMediator mediator, IRazorViewToStringRenderer razorViewToStringRenderer) : base(mediator)
    {
        _razorViewToStringRenderer = razorViewToStringRenderer;
    }

    [HttpPost("GenerateInvoice")]

    public async Task<IActionResult> GenerateInvoice()
    {
        var obj = new InvoiceVM()
        {
            Invoice = new Entity.Entity.Invoice
            {
                Company = new Entity.Entity.Company
                {
                    NAME = "Test Company",
                    ADDRESS = "Test Address",
                },
                NAME = "Test Invoice",
                INVOICE_DATE = DateTime.Now,
                COMPANY_ID = Guid.NewGuid(),
                Customer = new Entity.Entity.Customer
                {
                    NAME = "Test Customer",
                    ADDRESS = "Test Address",
                },
                INVOICE_NUMBER = "123456",
            }
        };
        var htmlContent = await _razorViewToStringRenderer.RenderViewToStringAsync("Invoice/Index", obj);
        return Content(htmlContent, "text/html"); // Return the HTML content
    }



    [HttpPost("Create")]
    public async Task<IActionResult> CreateProduct([FromBody] RequestProduct request)
     => await HandleResponse(new CreateProductCommand(request.Model, request.Files));

    [HttpGet("GetList")]
    [ProducesResponseType(typeof(List<ProductListResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<IActionResult> GetProductList()
     => await HandleResponse(new GetProductListQuery());

    [HttpGet("GetListForPos")]
    [ProducesResponseType(typeof(List<ProductListPosResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetProductListForPos([FromQuery] string? searchText, [FromQuery] int currentPage)
     => await HandleResponse(new GetProductListForPosQuery(searchText, currentPage));

    [HttpGet("GetById")]
    [ProducesResponseType(typeof(ProductModifyResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetProductById([FromQuery] Guid id)
     => await HandleResponse(new GetProductByIdQuery(id));

    [HttpPut("Update")]
    [ProducesResponseType(StatusCodes.Status202Accepted)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductRequest product)
     => await HandleResponse(new UpdateProductCommand(
         product.Id,
         product.Name,
         product.Desc,
         product.Stock,
         product.Barkod,
         product.Category,
         product.Company,
         product.Kdv,
         product.PurchasePrice,
         product.SalePrice,
         product.Profit
         ));



}
