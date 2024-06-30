using FluentValidation;
using FluentValidation.Results;
using TKIM.Application.Core.CQRS.QueryHandling;
using TKIM.Infastracture.DA.Abstract;

namespace TKIM.Application.Invoice;

public record class GetInvoiceHistoryQuery : Query<IEnumerable<InvoiceHistoryResponse>>
{
    public GetInvoiceHistoryQuery()
    {
    }

    public override ValidationResult Validate()
    {
        return new GetInvoiceHistoryQueryValidator().Validate(this);
    }
}

public class GetInvoiceHistoryQueryHandler : QueryHandler<GetInvoiceHistoryQuery, IEnumerable<InvoiceHistoryResponse>>
{
    private readonly IInvoiceService _invoiceService;

    public GetInvoiceHistoryQueryHandler(IInvoiceService invoiceService)
    {
        _invoiceService = invoiceService;
    }

    public override async Task<IEnumerable<InvoiceHistoryResponse>> ExecuteQuery(GetInvoiceHistoryQuery query, CancellationToken cancellationToken)
    {
        return (await _invoiceService.GetInvoiceHistoryList()).Select(x => new InvoiceHistoryResponse(x.ID, x.INVOICE_NUMBER, x.INVOICE_DATE, "", "", x.TOTAL));
    }
}

public class GetInvoiceHistoryQueryValidator : AbstractValidator<GetInvoiceHistoryQuery>
{
    public GetInvoiceHistoryQueryValidator()
    {
    }
}



public record class InvoiceHistoryResponse
{
    public InvoiceHistoryResponse(Guid invoiceId, string invoiceNumber, DateTime invoiceDate, string customerFullName, string companyName, decimal totalPayment)
    {
        InvoiceId = invoiceId;
        InvoiceNumber = invoiceNumber;
        InvoiceDate = invoiceDate;
        CustomerFullName = customerFullName;
        CompanyName = companyName;
        TotalPayment = totalPayment;
    }

    public Guid InvoiceId { get; set; }
    public string InvoiceNumber { get; set; }
    public DateTime InvoiceDate { get; set; }
    public string CustomerFullName { get; set; }
    public string CompanyName { get; set; }
    public decimal TotalPayment { get; set; }

}
