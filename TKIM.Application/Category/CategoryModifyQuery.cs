using FluentValidation;
using FluentValidation.Results;
using TKIM.Application.Core.CQRS.QueryHandling;
using TKIM.Infastracture.DA.Abstract;

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
    private readonly ICategoryService _categoryService;
    public CategoryModifyQueryHandler(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }
    public async override Task<CategoryModifyResponse> ExecuteQuery(CategoryModifyQuery query, CancellationToken cancellationToken = default)
    {
        var response = await _categoryService.GetAsync(query.Id, cancellationToken);

        return new CategoryModifyResponse(response.ID, response.NAME, response.DESCRIPTION);
    }

}

public record class CategoryModifyResponse
{
    public CategoryModifyResponse(Guid id, string name, string description)
    {
        Id = id;
        Name = name;
        Description = description;
    }

    public Guid Id { get; init; }
    public string Name { get; init; }
    public string Description { get; init; }

}
