using FluentValidation;

namespace TKIM.Panel.ViewModels.Company;

public record CompanyInsertRequest
{
    public string Name { get; set; }
    public string? Address { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Number { get; set; }
    public string? Email { get; set; }
    public string? Description { get; set; }
}
public class CompanyInsertRequestValidator : AbstractValidator<CompanyInsertRequest>
{
    public CompanyInsertRequestValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Isim Girilmesi Zorunludur.");
        RuleFor(x => x.Name).MaximumLength(100).WithMessage("Isim Karakter Sayısı Maksimum 100 Olmalı.");
        RuleFor(x => x.Description).MaximumLength(200).WithMessage("Açıklama Karakter Sayısı Maksimum 200 Olmalı.");
        RuleFor(x => x.Address).MaximumLength(100).WithMessage("Adres Karakter Sayısı Maksimum 100 Olmalı.");
        RuleFor(x => x.Description).MaximumLength(200).WithMessage("Açıklama Karakter Sayısı Maksimum 200 Olmalı.");
        RuleFor(x => x.PhoneNumber).MaximumLength(30).WithMessage("Telefon Numarası Karakter Sayısı Maksimum 30 Olmalı.");
        RuleFor(x => x.Number).MaximumLength(30).WithMessage("Numara Karakter Sayısı Maksimum 30 Olmalı.");
    }
}
