using FluentValidation.Results;
using TKIM.Application.Core.CQRS.QueryHandling;

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
        return base.Validate();
    }
}

public class CompanyModifyQueryHandler : QueryHandler<CompanyModifyQuery, CompanyMofiyVM>
{
    public override Task<CompanyMofiyVM> ExecuteQuery(CompanyModifyQuery query, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}

public record class CompanyMofiyVM
{
    public Guid Id { get; init; }
    public string Name { get; init; }
    public string Description { get; init; }
    public string Address { get; init; }
    public string PhoneNumber { get; init; }
    public string Number { get; init; }

}
