using FluentValidation;
using FluentValidation.Results;
using TKIM.Application.Core.CQRS.QueryHandling;
using TKIM.Infastracture.DA.Abstract;

namespace TKIM.Application.Company;

public record class CompanyDropdownQuery : Query<IEnumerable<CompanyDropdownResponse>>
{
    public CompanyDropdownQuery()
    {
    }



    public override ValidationResult Validate()
    {
        return new CompanyDropdownValidator().Validate(this);
    }
}

public class CompanyDropdownValidator : AbstractValidator<CompanyDropdownQuery>
{
    public CompanyDropdownValidator()
    {
    }
}

public class CompanyDropdownQueryHandler : QueryHandler<CompanyDropdownQuery, IEnumerable<CompanyDropdownResponse>>
{
    private readonly ICompanyService _companyService;

    public CompanyDropdownQueryHandler(ICompanyService companyService)
    {
        _companyService = companyService;
    }

    public async override Task<IEnumerable<CompanyDropdownResponse>> ExecuteQuery(CompanyDropdownQuery query, CancellationToken cancellationToken)
    {
        var companyResponse = await _companyService.GetCompanyForDropdown(cancellationToken);

        return companyResponse.Select(x => new CompanyDropdownResponse(x.ID, x.NAME));
    }
}



public record class CompanyDropdownResponse
{
    public CompanyDropdownResponse(Guid id, string name)
    {
        Id = id;
        Name = name;
    }

    public Guid Id { get; init; }
    public string Name { get; init; }
}
