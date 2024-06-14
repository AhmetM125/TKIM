using FluentValidation;
using FluentValidation.Results;
using TKIM.Application.Core.CQRS.CommandHandling;
using TKIM.Infastracture.DA.Abstract;

namespace TKIM.Application.Company;

public record class CompanyUpdateCommand : Command<Guid>
{
    public CompanyUpdateCommand(Guid id, string name, string description, string address,
               string phoneNumber, string number, string email)
    {
        Id = id;
        Name = name;
        Description = description;
        Address = address;
        PhoneNumber = phoneNumber;
        Number = number;
        Email = email;
    }

    public Guid Id { get; }
    public string Name { get; }
    public string Description { get; }
    public string Address { get; }
    public string PhoneNumber { get; }
    public string Number { get; }
    public string Email { get; }

    public override ValidationResult Validate()
    {
        return new CompanyUpdateValidator().Validate(this);
    }

}

public class CompanyUpdateHandler : CommandHandler<CompanyUpdateCommand, Guid>
{
    private readonly ICompanyService _companyService;

    public CompanyUpdateHandler(ICompanyService companyService)
    {
        _companyService = companyService;
    }

    public override async Task<Guid> ExecuteCommand(CompanyUpdateCommand command, CancellationToken cancellationToken = default)
    {
        var response = await _companyService.UpdateAsync(new Entity.Entity.Company
        {
            ID = command.Id,
            NAME = command.Name,
            DESCRIPTION = command.Description,
            ADDRESS = command.Address,
            PHONE_NUMBER = command.PhoneNumber,
            NUMBER = command.Number,
            EMAIL = command.Email
        });

        return response;
    }
}

public class CompanyUpdateValidator : AbstractValidator<CompanyUpdateCommand>
{
    public CompanyUpdateValidator()
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


public record class CompanyUpdateVM(Guid Id, string Name, string? Description, string? Address,
    string? PhoneNumber, string? Number, string? Email)
{}
