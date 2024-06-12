using FluentValidation;
using FluentValidation.Results;
using TKIM.Application.Core.CQRS.CommandHandling;
using TKIM.Infastracture.DA.Abstract;

namespace TKIM.Application.Category;

public record class CategoryUpdateCommand : Command<Guid>
{
    public CategoryUpdateCommand(Guid id, string name, string description)
    {
        Id = id;
        Name = name;
        Description = description;
    }
    public Guid Id { get; init; }
    public string Name { get; init; }
    public string Description { get; init; }

    public override ValidationResult Validate()
    {
        return new UpdateCategoryValidator().Validate(this);
    }
}
public class UpdateCategoryCommandHandler : CommandHandler<CategoryUpdateCommand, Guid>
{
    private readonly ICategoryService _categoryService;

    public UpdateCategoryCommandHandler(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    public async override Task<Guid> ExecuteCommand(CategoryUpdateCommand command, CancellationToken cancellationToken = default)
    {
        await _categoryService.UpdateAsync(new Entity.Entity.Category
        {
            ID = command.Id,
            NAME = command.Name,
            DESCRIPTION = command.Description
        }, cancellationToken);
        return command.Id;
    }
}
public class UpdateCategoryValidator : AbstractValidator<CategoryUpdateCommand>
{
    public UpdateCategoryValidator()
    {
        RuleFor(x => x.Description).MaximumLength(200).WithMessage("Description must not exceed 200 characters");
        RuleFor(x => x.Name).MaximumLength(100).WithMessage("Name must not exceed 100 characters");
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
    }
}
public record class UpdateCategoryRequest
{
    public Guid Id { get; init; }
    public string Name { get; init; }
    public string Description { get; init; }
}

