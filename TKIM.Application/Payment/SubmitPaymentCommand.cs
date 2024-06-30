using FluentValidation;
using FluentValidation.Results;
using TKIM.Application.Core.CQRS.CommandHandling;
using TKIM.Application.Services.Abstract;
using TKIM.Dto.InvoiceGenerate;
using TKIM.Entity.Entity;
using TKIM.Infastracture.DA.Abstract;
using TKIM.Utils.Invoice;

namespace TKIM.Application.Payment;

public record class SubmitPaymentCommand : Command<Guid>
{
    public SubmitPaymentCommand(List<PaymentItemVM> basketItems, decimal totalPrice, decimal paymentAmount, decimal totalDiscount, decimal totalTax)
    {
        PaymentItems = basketItems;
        TotalPrice = totalPrice;
        PaymentAmount = paymentAmount;
        TotalDiscount = totalDiscount;
        TotalTax = totalTax;
    }
    public List<PaymentItemVM> PaymentItems { get; set; }
    public decimal TotalPrice { get; set; }
    public decimal PaymentAmount { get; set; }
    public decimal TotalDiscount { get; set; }
    public decimal TotalPriceAfterDiscount { get; set; }
    public decimal TotalTax { get; set; }


    public override ValidationResult Validate()
    {
        return new SubmitPaymentValidator().Validate(this);
    }
}
public class PaymentItemValidator : AbstractValidator<PaymentItemVM>
{
    public PaymentItemValidator()
    {
        RuleFor(x => x.Profit)
            .GreaterThanOrEqualTo(0).WithMessage("Profit must be greater than or equal to zero.");

        RuleFor(x => (int)x.QuantityInCart)
            .GreaterThanOrEqualTo(0).WithMessage("Quantity in cart must be greater than or equal to zero.");

        RuleFor(x => x.TotalPrice)
            .GreaterThanOrEqualTo(0).WithMessage("Total price must be greater than or equal to zero.");

        RuleFor(x => x.Discount)
            .GreaterThanOrEqualTo(0).WithMessage("Discount must be greater than or equal to zero.");

        RuleFor(x => x.Kdv)
            .GreaterThanOrEqualTo(0).WithMessage("Kdv must be greater than or equal to zero.");

        RuleFor(x => x.SalePrice)
            .GreaterThanOrEqualTo(0).WithMessage("Sale price must be greater than or equal to zero.");

        RuleFor(x => x.PurchasePrice)
            .GreaterThanOrEqualTo(0).WithMessage("Purchase price must be greater than or equal to zero.");

    }

}
public class SubmitPaymentValidator : AbstractValidator<SubmitPaymentCommand>
{
    public SubmitPaymentValidator()
    {
        RuleFor(command => command.PaymentItems)
          .NotNull().WithMessage("Basket items cannot be null.")
          .Must(basketItems => basketItems != null && basketItems.Any()).WithMessage("Basket must contain at least one item.");

        RuleForEach(command => command.PaymentItems)
           .SetValidator(new PaymentItemValidator());

        RuleFor(command => command.TotalPrice)
           .GreaterThanOrEqualTo(0).WithMessage("Total price must be greater than or equal to zero.");


        RuleFor(command => command.TotalDiscount)
            .GreaterThanOrEqualTo(0).WithMessage("Total discount must be greater than or equal to zero.")
            .LessThanOrEqualTo(command => command.TotalPrice).WithMessage("Total discount must be less than or equal to the total price.");


        RuleFor(command => command.TotalTax)
            .GreaterThanOrEqualTo(0).WithMessage("Total tax must be greater than or equal to zero.");

    }
}



public class SubmitPaymentCommandHandler : CommandHandler<SubmitPaymentCommand, Guid>
{
    private readonly IProductService _productService;
    private readonly IInvoiceService _invoiceService;
    private readonly IPdfGeneratorService _pdfGeneratorService;
    public SubmitPaymentCommandHandler(IProductService productService, IInvoiceService invoiceService, IPdfGeneratorService pdfGeneratorService)
    {
        _productService = productService;
        _invoiceService = invoiceService;
        _pdfGeneratorService = pdfGeneratorService;
    }
    public override async Task<Guid> ExecuteCommand(SubmitPaymentCommand command, CancellationToken cancellationToken = default)
    {

        var saleRecord = Guid.NewGuid();

        var productListDictionary = await _productService.GetProductListForPaymentSection(command.PaymentItems.Select(x => x.Id));

        var basketItems = new List<Entity.Entity.PaymentItems>();
        var paymentId = Guid.NewGuid();


        foreach (var item in command.PaymentItems)
        {
            var productId = item.Id;
            var productDetails = productListDictionary[productId];

            var paymentItem = new  Entity.Entity.PaymentItems
            {
                ID = Guid.NewGuid(),
                SALE_RECORD_ID = Guid.NewGuid(),
                PAYMENT_ID = paymentId,
                SaleRecord = new SaleRecord
                {
                    PRODUCT_ID = productDetails.ID,
                    SALE_PRICE = productDetails.SALE_PRICE,
                    SALE_PRICE_EDITED = item.SalePrice,
                    PROFIT_EDITED = productDetails.PROFIT,
                    QUANTITY_SOLD = item.QuantityInCart,
                    PROFIT = productDetails.PROFIT,
                    PURCHASE_PRICE = productDetails.PURCHASE_PRICE,
                    QUANTITY_CURRENT = (ushort)productDetails.STOCK,
                    TAX = productDetails.KDV,
                    TAX_EDITED = item.Kdv,
                    TOTAL = item.TotalPrice,
                    TOTAL_EDITED = item.TotalPrice,
                    QUANTITY_AFTER = (ushort)item.QuantityInCart,
                    ID = Guid.NewGuid() // Ensure this is unique
                }
            };
            basketItems.Add(paymentItem);
        }

        var invoiceGenerateDto = new InvoiceGenerateDto
        {
            BasketItems = command.PaymentItems
            .Select(x => new Dto.InvoiceGenerate.Product
            {
                Name = x.Name,
                QuantityInCart = x.QuantityInCart,
                SalePrice = x.SalePrice,
                TotalPrice = x.TotalPrice,
                Kdv = x.Kdv
            }).ToList(),
            TotalPrice = command.TotalPrice,
            TotalDiscount = command.TotalDiscount,
            TotalTax = command.TotalTax,
            PaymentAmount = command.PaymentAmount
        };


        var response = await _pdfGeneratorService.GenerateInvoiceForSale(invoiceGenerateDto);

        await _invoiceService.InsertInvoce(new Entity.Entity.Invoice()
        {
            DESCRIPTION = "EmptyForNow",
            Payment = new Entity.Entity.Payment
            {
                TOTAL_PRICE = command.TotalPrice,
                PAYMENT_DATE = DateTime.Now,
                TOTAL_PAYMENT = command.PaymentAmount,
                TOTAL_DISCOUNT = command.TotalDiscount,
                TOTAL_TAX = command.TotalTax,
                ID = paymentId,
                BasketItems = basketItems,
                INVOICE_ID = Guid.NewGuid(),

            },
            ID = Guid.NewGuid(),
            INVOICE_DATE = DateTime.Now,
            INVOICE_PDF = response,
            PAYMENT_ID = paymentId,
            INVOICE_NUMBER = ((await _invoiceService.InvoiceCount() + 1).ToString().PadLeft(6, '0')),
            TOTAL = command.TotalPrice,

        });



        return saleRecord;
    }
}

public record PaymentRequest
{
    public List<PaymentItemVM> BasketItems { get; set; } = new List<PaymentItemVM>();
    public decimal TotalPrice { get; init; }
    public decimal PaymentAmount { get; init; }
    public decimal TotalDiscount { get; init; }
    public decimal TotalTax { get; init; }

}
public record PaymentItemVM
{
    public Guid Id { get; init; }
    public string Name { get; init; }
    public decimal SalePrice { get; init; }
    public decimal PurchasePrice { get; init; }
    public int Stock { get; init; }
    public ushort QuantityInCart { get; init; } = 0; // quantity that is in the cart
    public decimal TotalPrice { get; init; } = 0;
    public decimal Kdv { get; init; } = 0;
    public decimal Discount { get; init; } = 0;
    public decimal Profit { get; init; } = 1;

}