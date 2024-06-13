using FluentValidation;
using FluentValidation.Results;
using TKIM.Application.Core.CQRS.QueryHandling;
using TKIM.Infastracture.DA.Abstract;

namespace TKIM.Application.Category;

public record class CategoryDropdownQuery : Query<IEnumerable<CategoryDropdownResponse>>
{
    public CategoryDropdownQuery()
    { }

    public override ValidationResult Validate()
    {
        return new CategoryDropdownQueryValidator().Validate(this);
    }

}
public class CategoryDropdownQueryValidator : AbstractValidator<CategoryDropdownQuery>
{
    public CategoryDropdownQueryValidator()
    {
    }
}

public class CategoryDropdownQueryHandler : QueryHandler<CategoryDropdownQuery, IEnumerable<CategoryDropdownResponse>>
{
    private readonly ICategoryService _categoryService;
    public CategoryDropdownQueryHandler(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    public override async Task<IEnumerable<CategoryDropdownResponse>> ExecuteQuery(CategoryDropdownQuery query, CancellationToken cancellationToken)
    {
        return (await _categoryService.GetCategoryForDropdown()).Select(x => new CategoryDropdownResponse(x.ID, x.NAME));
    }
}

public record class CategoryDropdownResponse
{
    public CategoryDropdownResponse(Guid id, string name)
    {
        ID = id;
        Name = name;
    }

    public Guid ID { get; set; }
    public string Name { get; set; }
}
