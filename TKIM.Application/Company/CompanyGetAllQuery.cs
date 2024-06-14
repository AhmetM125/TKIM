using FluentValidation;
using FluentValidation.Results;
using TKIM.Application.Core.CQRS.QueryHandling;
using TKIM.Infastracture.DA.Abstract;

namespace TKIM.Application.Company;

public record class CompanyGetAllQuery : Query<IEnumerable<CompanyResponse>>
{
    public CompanyGetAllQuery()
    {

    }
    public override ValidationResult Validate()
    {
        return new CompanyGetAllValidator().Validate(this); 
    }
}
public class CompanyGetAllValidator : AbstractValidator<CompanyGetAllQuery>
{
    public CompanyGetAllValidator()
    {
    }
}
public class CompanyGetAllQueryHandler : QueryHandler<CompanyGetAllQuery, IEnumerable<CompanyResponse>>
{
    private readonly ICompanyService _companyService;

    public CompanyGetAllQueryHandler(ICompanyService companyService)
    {
        _companyService = companyService;
    }

    public async override Task<IEnumerable<CompanyResponse>> ExecuteQuery(CompanyGetAllQuery query, CancellationToken cancellationToken)
    {
        return (await _companyService.GetAllAsync(cancellationToken))
             .Select(x => new CompanyResponse
             (x.ID, x.NAME, x.DESCRIPTION, x.ADDRESS
             , x.PHONE_NUMBER, x.NUMBER,x.IS_ACTIVE));
    }
}

public record class CompanyResponse
{
    public CompanyResponse(Guid id, string name, string description, string address, string phoneNumber, string number, bool isActive)
    {
        Id = id;
        Name = name;
        Description = description;
        Address = address;
        PhoneNumber = phoneNumber;
        Number = number;
        IsActive = isActive;
    }

    public Guid Id { get; init; }
    public string Name { get; init; }
    public string Description { get; init; }
    public string Address { get; init; }
    public string PhoneNumber { get; init; }
    public string Number { get; init; }
    public bool IsActive { get; init; }


}
