using FluentValidation;
using FluentValidation.Results;
using TKIM.Application.Core.CQRS.CommandHandling;
using TKIM.Application.Product;
using TKIM.Infastracture.DA.Abstract;

namespace TKIM.Application.Product
{
    public record class UpdateProductCommand : Command<Guid>
    {
        public UpdateProductCommand(Guid id, string name, string desc, int stock, string barkod, Guid? category,
            Guid? company, decimal kdv, decimal purchasePrice, decimal salePrice, decimal profit)
        {
            Id = id;
            Name = name;
            Desc = desc;
            Stock = stock;
            Barkod = barkod;
            Category = category;
            Company = company;
            Kdv = kdv;
            PurchasePrice = purchasePrice;
            SalePrice = salePrice;
            Profit = profit;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public int Stock { get; set; }
        public string Barkod { get; set; }
        public Guid? Category { get; set; }
        public Guid? Company { get; set; }
        public decimal Kdv { get; set; } = 0;
        public decimal PurchasePrice { get; set; } = 0;
        public decimal SalePrice { get; set; } = 0;
        public decimal Profit { get; set; } = 0;


        public override ValidationResult Validate()
        {
            return new UpdateProductCommandValidator().Validate(this);
        }
    }
}

public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
{
    public UpdateProductCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("Id is empty");
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name is empty");
        RuleFor(x => x.Desc).MaximumLength(200).WithMessage("Description max character limit exceed (200)");

        RuleFor(x => x.Barkod).MaximumLength(50).WithMessage("Barcode max  character limit exceed (50)");
    }
}
public class UpdateProductCommandHandler : CommandHandler<UpdateProductCommand, Guid>
{
    private readonly IProductService _productService;

    public UpdateProductCommandHandler(IProductService productService)
    {
        _productService = productService;
    }

    public override async Task<Guid> ExecuteCommand(UpdateProductCommand command, CancellationToken cancellationToken = default)
    {
        await _productService.UpdateProductAsync(new TKIM.Entity.Entity.Product
        {
            ID = command.Id,
            NAME = command.Name,
            DESCRIPTION = command.Desc,
            STOCK = command.Stock,
            BARCODE = command.Barkod,
            CATEGORY_ID = command.Category,
            COMPANY_ID = command.Company,
            KDV = command.Kdv,
            PURCHASE_PRICE = command.PurchasePrice,
            SALE_PRICE = command.SalePrice,
            PROFIT = command.Profit
        }, cancellationToken);

        return command.Id;
    }
}


public record UpdateProductRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string? Desc { get; set; }
    public int Stock { get; set; } = 0;
    public string? Barkod { get; set; }
    public Guid? Category { get; set; }
    public Guid? Company { get; set; }
    public decimal Kdv { get; set; } = 0;
    public decimal PurchasePrice { get; set; } = 0;
    public decimal SalePrice { get; set; } = 0;
    public decimal Profit { get; set; } = 0;
}



