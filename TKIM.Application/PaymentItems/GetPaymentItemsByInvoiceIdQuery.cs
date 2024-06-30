using FluentValidation;
using FluentValidation.Results;
using TKIM.Application.Core.CQRS.QueryHandling;
using TKIM.Infastracture.DA.Abstract;

namespace TKIM.Application.PaymentItems;

public record class GetPaymentItemsByInvoiceIdQuery : Query<IEnumerable<PaymentItemResponse>>
{
    public GetPaymentItemsByInvoiceIdQuery(Guid invoiceId)
    {
        InvoiceId = invoiceId;
    }

    public Guid InvoiceId { get; set; }

    public override ValidationResult Validate()
    {
        return new GetPaymentItemsByInvoiceIdQueryValidator().Validate(this);
    }
}

public class GetPaymentItemsByInvoiceIdQueryHandler : QueryHandler<GetPaymentItemsByInvoiceIdQuery, IEnumerable<PaymentItemResponse>>
{
    private readonly IPaymentItemService _paymentItemService;

    public GetPaymentItemsByInvoiceIdQueryHandler(IPaymentItemService paymentItemService)
    {
        _paymentItemService = paymentItemService;
    }

    public override async Task<IEnumerable<PaymentItemResponse>> ExecuteQuery(GetPaymentItemsByInvoiceIdQuery query, CancellationToken cancellationToken)
    {
        var response =  (await _paymentItemService.GetPaymentItemListByInvoiceId(query.InvoiceId)).Select(x =>
        new PaymentItemResponse
        (new PaymentItemSaleRecord(x.SaleRecord.PRODUCT_ID, x.SaleRecord.QUANTITY_SOLD, x.SaleRecord.SALE_PRICE, x.SaleRecord.SALE_PRICE_EDITED, x.SaleRecord.TOTAL, x.SaleRecord.TOTAL_EDITED,
        new SaleRecordProduct(x.SaleRecord.Product.NAME))));

        return response;
    }
}

public class GetPaymentItemsByInvoiceIdQueryValidator : AbstractValidator<GetPaymentItemsByInvoiceIdQuery>
{
    public GetPaymentItemsByInvoiceIdQueryValidator()
    {
        RuleFor(x => x.InvoiceId).NotEmpty().WithMessage("InvoiceId is empty");
    }
}

public record class PaymentItemResponse
{
    public PaymentItemResponse(PaymentItemSaleRecord saleRecord)
    {
        SaleRecord = saleRecord;
    }

    public PaymentItemSaleRecord SaleRecord { get; set; }


}
public record class PaymentItemSaleRecord
{
    public PaymentItemSaleRecord(Guid productId, ushort quantitySold, decimal salePriceEdited, decimal salePrice, decimal total, decimal totalEdit, SaleRecordProduct product)
    {
        ProductId = productId;
        QuantitySold = quantitySold;
        SalePriceEdited = salePriceEdited;
        SalePrice = salePrice;
        Total = total;
        TotalEdit = totalEdit;
        Product = product;
    }

    public Guid ProductId { get; set; }
    public ushort QuantitySold { get; set; }
    public decimal SalePriceEdited { get; set; }
    public decimal SalePrice { get; set; }
    public decimal Total { get; set; }
    public decimal TotalEdit { get; set; }
    public SaleRecordProduct Product { get; set; }

}

public record class SaleRecordProduct
{
    public SaleRecordProduct(string name)
    {
        Name = name;
    }

    public string Name { get; set; }
}
