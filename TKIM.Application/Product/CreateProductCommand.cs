using FluentValidation;
using FluentValidation.Results;
using TKIM.Application.Core.CQRS.CommandHandling;

namespace TKIM.Application.Product;

public record class CreateProductCommand : Command<Guid>
{
    public CreateProductCommand(ProductInsertRequest model, List<string> files)
    {
        Model = model;
        Files = files;
    }

    public ProductInsertRequest Model { get; }
    public List<string> Files { get; }

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
    public override Task<Guid> ExecuteCommand(CreateProductCommand command, CancellationToken cancellationToken = default)
    {
        return null;
    }
}

public record ProductInsertRequest
{
    public string Name { get; set; }
    public string? Description { get; init; }
    public string? Category { get; init; }
    public string? Barcode { get; init; }
    public string? Company { get; init; }
    public DateTime? BestBeforeDate { get; set; } = new DateTime(1, 1, 1, 1, 1, 1);
}

public class RequestProduct
{
    public ProductInsertRequest Model { get; init; }
    public List<string> Files { get; init; }
}