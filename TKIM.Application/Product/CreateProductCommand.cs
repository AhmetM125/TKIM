using FluentValidation;
using FluentValidation.Results;
using TKIM.Application.Core.CQRS.CommandHandling;
using TKIM.Dto.File;
using TKIM.Infastracture.DA.Abstract;

namespace TKIM.Application.Product;

public record class CreateProductCommand : Command<Guid>
{
    public CreateProductCommand(ProductInsertRequest model, List<FileDetail> files)
    {
        Model = model;
        Files = files;
    }

    public ProductInsertRequest Model { get; }
    public List<FileDetail> Files { get; }

    public override ValidationResult Validate()
    {
        return new CreateProductValidator().Validate(this);
    }
}

public class CreateProductValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductValidator()
    {
        RuleFor(x => x.Model.Name).NotEmpty().WithMessage("Ürün adı boş bırakılamaz.");
        RuleFor(x => x.Model.Description).MaximumLength(200).WithMessage("Açıklama en fazla 200 karakter olabilir.");
    }
}

public class CreateProductCommandHandler : CommandHandler<CreateProductCommand, Guid>
{
    private readonly IProductService _productService;

    public CreateProductCommandHandler(IProductService productService)
    {
        _productService = productService;
    }

    public override async Task<Guid> ExecuteCommand(CreateProductCommand command, CancellationToken cancellationToken = default)
    {
        var model = command.Model;
        var response = await _productService.CreateAsync(new Entity.Entity.Product
        {
            NAME = model.Name,
            DESCRIPTION = model.Description,
            CATEGORY_ID = model.Category,
            BARCODE = model.Barcode,
            COMPANY_ID = model.Company,

        },command.Files,cancellationToken);

        return response;
    }
}

public record ProductInsertRequest
{
    public string Name { get; set; }
    public string? Description { get; init; }
    public Guid? Category { get; init; }
    public string? Barcode { get; init; }
    public Guid? Company { get; init; }
    public DateTime? BestBeforeDate { get; set; } = new DateTime(1, 1, 1, 1, 1, 1);
}

public class RequestProduct
{
    public ProductInsertRequest Model { get; init; }
    public List<FileDetail>? Files { get; init; }
}
