using FluentValidation.Results;
using MediatR;

namespace TKIM.Application.Core.CQRS.QueryHandling;

public interface IQuery<out TResult> : IRequest<TResult>
{
    public abstract ValidationResult Validate();
}

/// <summary>
/// Abstract class to be inherited by Queries
/// </summary>
public abstract record class Query<TResult> : IQuery<QueryHandlerResult<TResult>>
{
    public ValidationResult ValidationResult { get; init; }

    public virtual ValidationResult Validate()
    {
        return ValidationResult;
    }
}