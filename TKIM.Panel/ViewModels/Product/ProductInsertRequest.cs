using FluentValidation;

namespace TKIM.Panel.ViewModels.Product;

public record ProductInsertRequest
{
    public string Name { get; set; }
    public string? Description { get; set; }
    public Guid? Category { get; set; }
    public Guid? Company { get; set; }
    public string? Barcode { get; set; }
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
    public List<FileDetail>? Files { get; set; }
}

public class FileDetail
{
    public string? Base64 { get; set; }
    public string? Type { get; set; } // MIME type
    public long? Size { get; set; } // Size in bytes
    public string? Name { get; set; } // File name
}
