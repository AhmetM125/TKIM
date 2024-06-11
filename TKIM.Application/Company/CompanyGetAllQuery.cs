using FluentValidation.Results;
using TKIM.Application.Core.CQRS.QueryHandling;

namespace TKIM.Application.Company;

public record class CompanyGetAllQuery : Query<List<CompanyResponse>>
{
    public CompanyGetAllQuery()
    {
        
    }
    public override ValidationResult Validate()
    {
        return base.Validate();
    }
}
public class CompanyGetAllQueryHandler : QueryHandler<CompanyGetAllQuery, List<CompanyResponse>>
{
    public async override Task<List<CompanyResponse>> ExecuteQuery(CompanyGetAllQuery query, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}

public record class CompanyResponse
{
    public Guid Id { get; init; }
    public string Name { get; init; }
    public string Description { get; init; }
    public string Address { get; init; }
    public string PhoneNumber { get; init; }
    public string Number { get; init; }
}
