using FluentValidation;
using FluentValidation.Results;
using TKIM.Application.Core.CQRS.CommandHandling;
using TKIM.Infastracture.DA.Abstract;
using TKIM.Utils.Invoice;

namespace TKIM.Application.Payment;

public record class SubmitPaymentCommand : Command<Guid>
{
    public SubmitPaymentCommand(List<PaymentItemVM> basketItems, decimal totalPrice, decimal paymentAmount, decimal totalDiscount, decimal totalPriceAfterDiscount, decimal totalTax)
    {
        PaymentItems = basketItems;
        TotalPrice = totalPrice;
        PaymentAmount = paymentAmount;
        TotalDiscount = totalDiscount;
        TotalPriceAfterDiscount = totalPriceAfterDiscount;
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

        RuleFor(x => x.QuantityInCart)
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
    private readonly IPaymentService _paymentService;
    public SubmitPaymentCommandHandler(IPaymentService paymentService)
    {
        _paymentService = paymentService;
    }
    public override async Task<Guid> ExecuteCommand(SubmitPaymentCommand command, CancellationToken cancellationToken = default)
    {

        var saleRecord = Guid.NewGuid();


        await _paymentService.InsertPayment(new Entity.Entity.Payment
        {
            TOTAL_PRICE = command.TotalPrice,
            TOTAL_PAYMENT = command.PaymentAmount,
            TOTAL_DISCOUNT = command.TotalDiscount,
            TOTAL_TAX = command.TotalTax,
            ID = Guid.NewGuid(),
            BasketItems = command.PaymentItems.Select(x => new Entity.Entity.PaymentItems
            {
                ID = Guid.NewGuid(),
                SALE_RECORD_ID = Guid.NewGuid(), // Unique ID for each SaleRecord
                SaleRecord = new Entity.Entity.SaleRecord
                {
                    ID = Guid.NewGuid(), // Ensure this is unique
                    PRODUCT_ID = x.Id,
                    SALE_PRICE = x.SalePrice,
                    PROFIT_EDITED = x.Profit,
                    PURCHASE_PRICE = x.PurchasePrice,
                    QUANTITY_SOLD = (ushort)x.QuantityInCart,
                    QUANTITY_AFTER = (ushort)x.QuantityInCart,
                }
            }).ToList(),
            INVOICE_ID = Guid.NewGuid(),
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
    public decimal TotalPriceAfterDiscount { get; init; }
    public decimal TotalTax { get; init; }

}
public record PaymentItemVM
{
    public Guid Id { get; init; }
    public string Name { get; init; }
    public decimal SalePrice { get; init; }
    public decimal PurchasePrice { get; init; }
    public int Stock { get; init; }
    public int QuantityInCart { get; init; } = 0; // quantity that is in the cart
    public decimal TotalPrice { get; init; } = 0;
    public decimal Kdv { get; init; } = 0;
    public decimal Discount { get; init; } = 0;
    public decimal Profit { get; init; } = 1;

}