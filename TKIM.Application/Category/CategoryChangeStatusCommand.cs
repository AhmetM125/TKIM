using FluentValidation;
using FluentValidation.Results;
using TKIM.Application.Core.CQRS.CommandHandling;
using TKIM.Infastracture.DA.Abstract;

namespace TKIM.Application.Category;

public record class CategoryChangeStatusCommand : Command<Guid>
{
    public CategoryChangeStatusCommand(Guid id)
    {
        Id = id;
    }
    public Guid Id { get; set; }

    public override ValidationResult Validate()
    {
        return new CategoryChangeStatusValidator().Validate(this);
    }
}
public class CategoryChangeStatusCommandHandler : CommandHandler<CategoryChangeStatusCommand, Guid>
{
    private readonly ICategoryService _categoryService;

    public CategoryChangeStatusCommandHandler(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    public async override Task<Guid> ExecuteCommand(CategoryChangeStatusCommand command, CancellationToken cancellationToken = default)
    {
        await _categoryService.ChangeCategoryStatus(command.Id);
        return command.Id;
    }
}
public class CategoryChangeStatusValidator : AbstractValidator<CategoryChangeStatusCommand>
{
    public CategoryChangeStatusValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required");
    }
}

