using FluentValidation;
using FluentValidation.Results;
using TKIM.Application.Core.CQRS.QueryHandling;

namespace TKIM.Application.Category;

public record class CategoryModifyQuery : Query<CategoryModifyResponse>
{
    public CategoryModifyQuery(Guid id)
    {
        Id = id;
    }
    public Guid Id { get; set; }

    public override ValidationResult Validate()
    {
        return new CategoryModifyValidator().Validate(this);
    }

}
public class CategoryModifyValidator : AbstractValidator<CategoryModifyQuery>
{
    public CategoryModifyValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required");
    }
}
public class CategoryModifyQueryHandler : QueryHandler<CategoryModifyQuery, CategoryModifyResponse>
{
    public override Task<CategoryModifyResponse> ExecuteQuery(CategoryModifyQuery query, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}

public record class CategoryModifyResponse
{

}
