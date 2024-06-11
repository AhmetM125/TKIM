using FluentValidation;
using FluentValidation.Results;
using TKIM.Application.Core.CQRS.QueryHandling;
using TKIM.Infastracture.DA.Abstract;

namespace TKIM.Application.Category;

public record class CategoryGetAllQuery : Query<List<CategoryResponse>>
{
    public override ValidationResult Validate()
    {
        return new GetAllCategoriesValidator().Validate(this);
    }
}
public class GetAllCategoriesValidator : AbstractValidator<CategoryGetAllQuery>
{
}
public class GetAllCategoriesQueryHandler : QueryHandler<CategoryGetAllQuery, List<CategoryResponse>>
{
    private readonly ICategoryService _categoryService;
    public GetAllCategoriesQueryHandler(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }
    public async override Task<List<CategoryResponse>> ExecuteQuery(CategoryGetAllQuery query, CancellationToken cancellationToken = default)
    {
        var response = await _categoryService.GetAllAsync(cancellationToken);

        return response.Select(x => new CategoryResponse
        {
            Description = x.DESCRIPTION,
            Id = x.ID,
            Name = x.NAME
        }).ToList();
    }
}
public record class CategoryResponse
{
    public Guid Id { get; init; }
    public string Name { get; init; }
    public string Description { get; init; }
}
