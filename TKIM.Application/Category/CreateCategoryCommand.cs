using FluentValidation;
using FluentValidation.Results;
using TKIM.Application.Core.CQRS.CommandHandling;
using TKIM.Entity.Entity;
using TKIM.Infastracture.DA.Abstract;

namespace TKIM.Application.Category;

public record class CreateCategoryCommand : Command<Guid>
{
    public CreateCategoryCommand(string name, string description)
    {
        Name = name;
        Description = description;
    }
    public string Name { get; set; }
    public string Description { get; set; }

    public override ValidationResult Validate()
    {
        return new CreateCategoryValidator().Validate(this);
    }
}
public class CreateCategoryValidator : AbstractValidator<CreateCategoryCommand>
{
    public CreateCategoryValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
        RuleFor(x => x.Name).MaximumLength(100).WithMessage("Name must not exceed 100 characters");
        RuleFor(x => x.Description).MaximumLength(200).WithMessage("Description must not exceed 200 characters");
    }
}
public class CreateCategoryCommandHandler : CommandHandler<CreateCategoryCommand, Guid>
{
    private readonly ICategoryService _categoryService;

    public CreateCategoryCommandHandler(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    public override async Task<Guid> ExecuteCommand(CreateCategoryCommand command, CancellationToken cancellationToken = default)
    {
        try
        {
            var response = await _categoryService.CreateAsync(new Entity.Entity.Category
            {
                NAME = command.Name,
                DESCRIPTION = command.Description
            }, cancellationToken);
            return response;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw;
        }
    }
}


public record CreateCategoryRequest
{
    public string Name { get; init; }
    public string Description { get; init; }
}
