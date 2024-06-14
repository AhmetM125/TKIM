using FluentValidation;
using FluentValidation.Results;
using TKIM.Application.Core.CQRS.CommandHandling;
using TKIM.Infastracture.DA.Abstract;

namespace TKIM.Application.Company;

public record class CompanyCreateCommand : Command<Guid>
{
    public CompanyCreateCommand(string name, string description, string address, string phoneNumber, string number, string email)
    {
        Name = name;
        Description = description;
        Address = address;
        PhoneNumber = phoneNumber;
        Number = number;
        Email = email;
    }

    public string Name { get; init; }
    public string Description { get; init; }
    public string Address { get; init; }
    public string PhoneNumber { get; init; }
    public string Number { get; init; }
    public string Email { get; init; }




    public override ValidationResult Validate()
    {
        return new CompanyCreateValidator().Validate(this);
    }
}
public class CompanyCreateValidator : AbstractValidator<CompanyCreateCommand>
{
    public CompanyCreateValidator()
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
public class CompanyCreateHandler : CommandHandler<CompanyCreateCommand, Guid>
{
    private readonly ICompanyService _companyService;

    public CompanyCreateHandler(ICompanyService companyService)
    {
        _companyService = companyService;
    }

    public override async Task<Guid> ExecuteCommand(CompanyCreateCommand command, CancellationToken cancellationToken = default)
    {
        var response = await _companyService.CreateAsync(new Entity.Entity.Company
        {
            NAME = command.Name,
            DESCRIPTION = command.Description,
            ADDRESS = command.Address,
            PHONE_NUMBER = command.PhoneNumber,
            NUMBER = command.Number
        });
        return response;
    }
}

public record class CompanyCreateVM
{
    public CompanyCreateVM(string name, string description, string address, string phoneNumber, string number, string email)
    {
        Name = name;
        Description = description;
        Address = address;
        PhoneNumber = phoneNumber;
        Number = number;
        Email = email;
    }

    public string Name { get; init; }
    public string? Address { get; init; }
    public string? PhoneNumber { get; init; }
    public string? Number { get; init; }
    public string? Email { get; init; }
    public string? Description { get; init; }
}
