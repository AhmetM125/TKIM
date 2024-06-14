using FluentValidation;

namespace TKIM.Panel.ViewModels.Product;

public record ProductInsertRequest
{
    public string Name { get; set; }
    public string? Description { get; set; }
    public string? Category { get; set; }
    public string? Barcode { get; set; }
    public string? Company { get; set; }
    public DateTime? BestBeforeDate { get; set; } = new DateTime(1, 1, 1, 1, 1, 1);
}

public class ProductInsertValidator : AbstractValidator<ProductInsertRequest>
{
    public ProductInsertValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Ürün adı boş bırakılamaz.");
        RuleFor(x => x.Description).MaximumLength(200).WithMessage("Açıklama en fazla 200 karakter olabilir.");
    }

}

public class RequestProduct
{
    public ProductInsertRequest Model { get; set; }
    public List<string> Files { get; set; }
}
