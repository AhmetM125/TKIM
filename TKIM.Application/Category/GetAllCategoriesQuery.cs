using FluentValidation;
using FluentValidation.Results;
using TKIM.Application.Core.CQRS.QueryHandling;

namespace TKIM.Application.Category;

public record class GetAllCategoriesQuery : Query<CategoryResponse>
{
    public override ValidationResult Validate()
    {
        return new GetAllCategoriesValidator().Validate(this);
    }


}
public class GetAllCategoriesValidator : AbstractValidator<GetAllCategoriesQuery>
{
    public GetAllCategoriesValidator()
    {
    }
}
public class GetAllCategoriesQueryHandler : QueryHandler<GetAllCategoriesQuery, CategoryResponse>
{
    public override Task<CategoryResponse> ExecuteQuery(GetAllCategoriesQuery query, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
public record class CategoryResponse
{
    public Guid Id { get; init; }
    public string Name { get; init; }
    public string Description { get; init; }
}
