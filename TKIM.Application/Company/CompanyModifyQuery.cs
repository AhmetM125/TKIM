using FluentValidation;
using FluentValidation.Results;
using TKIM.Application.Core.CQRS.QueryHandling;
using TKIM.Infastracture.DA.Abstract;

namespace TKIM.Application.Company;

public record class CompanyModifyQuery : Query<CompanyMofiyVM>
{
    public Guid Id { get; set; }
    public CompanyModifyQuery(Guid id)
    {
        Id = id;
    }
    public override ValidationResult Validate()
    {
        return new CompanyModifyQueryValidator().Validate(this);
    }
}
public class CompanyModifyQueryValidator : AbstractValidator<CompanyModifyQuery>
{
    public CompanyModifyQueryValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
public class CompanyModifyQueryHandler : QueryHandler<CompanyModifyQuery, CompanyMofiyVM>
{
    private readonly ICompanyService _companyService;

    public CompanyModifyQueryHandler(ICompanyService companyService)
    {
        _companyService = companyService;
    }

    public override async Task<CompanyMofiyVM> ExecuteQuery(CompanyModifyQuery query, CancellationToken cancellationToken)
    {
        var companyResponse = await _companyService.GetCompanyForModify(query.Id);
        return new CompanyMofiyVM(companyResponse.ID, companyResponse.NAME, companyResponse.DESCRIPTION,
            companyResponse.ADDRESS, companyResponse.PHONE_NUMBER, companyResponse.NUMBER,companyResponse.EMAIL);
    }
}

public record class CompanyMofiyVM
{
    public CompanyMofiyVM(Guid id, string name, string description, string address, string phoneNumber, string number,string mail)
    {
        Id = id;
        Name = name;
        Description = description;
        Address = address;
        PhoneNumber = phoneNumber;
        Number = number;
        Mail = mail;
    }

    public Guid Id { get; init; }
    public string Name { get; init; }
    public string Description { get; init; }
    public string Address { get; init; }
    public string PhoneNumber { get; init; }
    public string Number { get; init; }
    public string Mail { get; init; }

}
