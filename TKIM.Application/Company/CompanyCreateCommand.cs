using FluentValidation;
using FluentValidation.Results;
using TKIM.Application.Core.CQRS.CommandHandling;
using TKIM.Infastracture.DA.Abstract;

namespace TKIM.Application.Company;

public record class CompanyCreateCommand : Command<Guid>
{
    public CompanyCreateCommand(string name, string description, string address, string phoneNumber, string number)
    {
        Name = name;
        Description = description;
        Address = address;
        PhoneNumber = phoneNumber;
        Number = number;
    }

    public string Name { get; init; }
    public string Description { get; init; }
    public string Address { get; init; }
    public string PhoneNumber { get; init; }
    public string Number { get; init; }

    
    public override ValidationResult Validate()
    {
        return new CompanyCreateValidator().Validate(this);
    }
}
public class CompanyCreateValidator : AbstractValidator<CompanyCreateCommand>
{
    public CompanyCreateValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Şirket İsmi Gereklidir.").MaximumLength(100).WithMessage("Şirket ismi maksimum 100 karakter olabilir");
        RuleFor(x => x.Description).MaximumLength(200).WithMessage("Açıklama maksimum 200 karakter olabilir");
    }
}
public class CompanyCreateHandler : CommandHandler<CompanyCreateCommand, Guid>
{
    private readonly ICompanyService _companyService;

    public CompanyCreateHandler(ICompanyService companyService)
    {
        _companyService = companyService;
    }

    public override Task<Guid> ExecuteCommand(CompanyCreateCommand command, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}

public record CompanyCreateVM
{
    public CompanyCreateVM(string name, string description, string address, string phoneNumber, string number)
    {
        Name = name;
        Description = description;
        Address = address;
        PhoneNumber = phoneNumber;
        Number = number;
    }

    public string Name { get; init; }
    public string Description { get; init; }
    public string Address { get; init; }
    public string PhoneNumber { get; init; }
    public string Number { get; init; }
}
